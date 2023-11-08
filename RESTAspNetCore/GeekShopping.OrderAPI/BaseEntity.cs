using System.ComponentModel.DataAnnotations;

namespace GeekShopping.OrderAPI
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }



    }
}
