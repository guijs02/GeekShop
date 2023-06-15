using GeekShopping.ProductAPI.Model.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GeekShopping.ProductAPI.Model
{
    public class Product : BaseEntity
    {
        [Required]
        [StringLength(150)]
        public string Nome { get; set; }

        [Required]
        [Range(1,10000)]
        public decimal Preco { get; set; }

        [StringLength(500)]
        public string Descricao { get; set; }

        [StringLength(50)]
        public string Categoria { get; set; }

        [StringLength(300)]
        public string ImageURL { get; set; }

    }
}
