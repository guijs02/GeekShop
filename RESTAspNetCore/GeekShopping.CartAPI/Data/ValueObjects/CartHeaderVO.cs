namespace GeekShopping.CartAPI.Data.ValueObjects
{

    public class CartHeaderVO
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string? CupomCode { get; set; }
    }
}
