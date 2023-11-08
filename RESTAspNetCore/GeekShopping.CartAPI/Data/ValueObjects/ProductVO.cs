using GeekShopping.ProductAPI.Model.Base;
using System.ComponentModel.DataAnnotations;

namespace GeekShopping.CartAPI.Data.ValueObjects
{
    public class ProductVO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public string Descricao { get; set; }
        public string Categoria { get; set; }
        public string ImageURL { get; set; }

        [Range(1, 100)]
        public int Count { get; set; } = 1;

    }
}
