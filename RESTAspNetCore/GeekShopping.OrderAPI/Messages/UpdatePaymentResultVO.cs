namespace GeekShopping.OrderAPI.Messages
{
    public class UpdatePaymentResultVO
    {
        public int OrderId { get; set; }
        public string Email { get; set; }
        public bool Status { get; set; }
    }
}
