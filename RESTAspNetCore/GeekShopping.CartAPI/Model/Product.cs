using GeekShopping.ProductAPI.Model.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GeekShopping.CartAPI.Model
{
    public class Product : BaseEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

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
