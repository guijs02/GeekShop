using System;

namespace GeekShopping.Web.Models
{

    public class CartHeaderViewModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string CupomCode { get; set; }
        public decimal PurchaseAmount { get; set; }
        public decimal DescontoTotal { get; set; } = 1m;
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateTime { get; set; } = DateTime.Now;
        public string Phone { get; set; }
        public string Email { get; set; }
        public string CardNumber { get; set; }
        public string CVV { get; set; }
        public string ExpiryMonthYear { get; set; }
        //public int CartTotalItens { get; set; }

    }
}
