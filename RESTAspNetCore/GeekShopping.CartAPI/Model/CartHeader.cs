using GeekShopping.ProductAPI.Model.Base;

namespace GeekShopping.CartAPI.Model
{
    
    public class CartHeader : BaseEntity
    {
        public int UserId { get; set; }
        public string? CupomCode { get; set; }
    }
}
