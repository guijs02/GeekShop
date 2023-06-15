namespace GeekShopping.Web.Models
{
    public class ProductModel
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public decimal Preco { get; set; }

        public string Descricao { get; set; }

        public string Categoria { get; set; }

        public string ImageURL { get; set; }
    }
}
