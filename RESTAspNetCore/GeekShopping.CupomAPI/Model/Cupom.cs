using GeekShopping.CupomAPI.Model.Base;
using System.ComponentModel.DataAnnotations;

namespace GeekShopping.CupomAPI.Model
{
    public class Cupom : BaseEntity
    {
        [Required]
        [StringLength(30)]
        public string CupomCode { get; set; }

        [Required]
        public decimal Desconto { get; set; }

    }
}
