using GeekShopping.ProductAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace GeekShopping.ProductAPI.Context
{
    public class SQLServerContext : DbContext
    {
        public SQLServerContext() { }
        public SQLServerContext(DbContextOptions<SQLServerContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 1,
                Nome = "Dragon ball",
                Categoria = "t-shirt",
                Descricao="camisa legal",
                ImageURL= "ShoppingImages/13_dragon_ball.jpg",
                Preco = 15.90m
            });  modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 2,
                Nome = "occupy mars",
                Categoria = "t-shirt",
                Descricao="camisa legal",
                ImageURL= "ShoppingImages/12_gnu_linux.jpg",
                Preco = 17.90m
            });  modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 3,
                Nome = "GNU",
                Categoria = "t-shirt",
                Descricao="camisa legal",
                ImageURL= "ShoppingImages/12_gnu_linux.jpg",
                Preco = 18.95m
            });  modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 4,
                Nome = "Dart vader",
                Categoria = "mascara",
                Descricao="mascara legal",
                ImageURL= "ShoppingImages/3_vader.jpg",
                Preco = 32.90m
            });  modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 5,
                Nome = "SPACEX",
                Categoria = "t-shirt",
                Descricao="camisa legal",
                ImageURL= "ShoppingImages/6_spacex.jpg",
                Preco = 10.90m
            });
        }
    }
}
