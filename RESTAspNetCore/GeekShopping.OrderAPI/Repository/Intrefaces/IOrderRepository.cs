using GeekShopping.OrderAPI.Model;

namespace GeekShopping.CartAPI.Repository.Intrefaces
{
    public interface IOrderRepository
    {
        Task<bool> AddOrder(OrderHeader header);
        Task UpdateOrderPaymentStatus (long orderHeaderId, bool paid);
    }
}
