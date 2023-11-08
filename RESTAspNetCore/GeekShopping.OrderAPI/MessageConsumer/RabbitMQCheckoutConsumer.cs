﻿using GeekShopping.OrderAPI.Messages;
using GeekShopping.OrderAPI.Model;
using GeekShopping.OrderAPI.RabbitMQSender;
using GeekShopping.OrderAPI.Repository;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Text.Json;

namespace GeekShopping.OrderAPI.MessageConsumer
{
    public class RabbitMQCheckoutConsumer : BackgroundService
    {
        private readonly OrderRepository _orderRepository;
        private IConnection _connection;
        private IModel _channel;
        private IRabbitMQMessageSender _rabbitMQMessageSender;

        public RabbitMQCheckoutConsumer(OrderRepository orderRepository, IRabbitMQMessageSender rabbitMQMessageSender)
        {
            _orderRepository = orderRepository;
            _rabbitMQMessageSender = rabbitMQMessageSender;

            var factory = new ConnectionFactory
            {
                HostName = "localhost",
                UserName = "guest",
                Password = "guest",
            };
            _connection = factory.CreateConnection();

            _channel = _connection.CreateModel();
            _channel.QueueDeclare(queue: "checkoutqueue", false, false, false, arguments: null);
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            stoppingToken.ThrowIfCancellationRequested();
            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += (chanel, evt) =>
            {
                var content = Encoding.UTF8.GetString(evt.Body.ToArray());
                CheckoutHeaderVO vo = JsonSerializer.Deserialize<CheckoutHeaderVO>(content);
                ProcessOrder(vo).GetAwaiter().GetResult();
                _channel.BasicAck(evt.DeliveryTag, false);
            };
            _channel.BasicConsume("checkoutqueue", false, consumer);
            return Task.CompletedTask;
        }

        private async Task ProcessOrder(CheckoutHeaderVO vo)
        {
            OrderHeader order = new()
            {
                UserId = vo.UserId,
                CardNumber = vo.CardNumber,
                CupomCode = vo.CupomCode,
                DateTime = vo.DateTime,
                OrderDetails = new List<OrderDetail>(),
                CartTotalItens = vo.CartTotalItens,
                CVV = vo.CVV,
                DescontoTotal = vo.DescontoTotal,
                Email = vo.Email,
                ExpiryMonthYear = vo.ExpiryMonthYear,
                FirstName = vo.FirstName,
                LastName = vo.LastName,
                Phone = vo.Phone,
                PurchaseAmount = vo.PurchaseAmount,
                OrderTime = DateTime.Now,
                PaymentStatus = false,

            };
            foreach (var item in vo.CartDetails)
            {
                OrderDetail detail = new()
                {
                    ProductId = item.ProductId,
                    Count = item.Count,
                    Price = item.Product.Preco,
                    ProductName = item.Product.Nome
                };
                order.CartTotalItens += detail.Count;
                order.OrderDetails.Add(detail);
            }
            await _orderRepository.AddOrder(order);

            PaymentVO payment = new()
            {
                Name = order.FirstName + "" + order.LastName,
                CardNumber = order.CardNumber,
                CVV = order.CVV,
                ExpiryMonthYear = order.ExpiryMonthYear,
                OrderId = order.Id,
                PurchaseAmount = order.PurchaseAmount,
                Email = order.Email,
            };

            try
            {
                _rabbitMQMessageSender.SendMessage(payment, "orderpaymentprocessqueue");
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
