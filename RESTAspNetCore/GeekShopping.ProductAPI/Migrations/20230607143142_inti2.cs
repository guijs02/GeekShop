using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GeekShopping.ProductAPI.Migrations
{
    /// <inheritdoc />
    public partial class inti2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Categoria", "Descricao", "ImageURL", "Nome", "Preco" },
                values: new object[,]
                {
                    { 1, "t-shirt", "camisa legal", "ShoppingImages/13_dragon_ball.jpg", "Dragon ball", 15.90m },
                    { 2, "t-shirt", "camisa legal", "ShoppingImages/12_gnu_linux.jpg", "occupy mars", 17.90m },
                    { 3, "t-shirt", "camisa legal", "ShoppingImages/12_gnu_linux.jpg", "GNU", 18.95m },
                    { 4, "mascara", "mascara legal", "ShoppingImages/3_vader.jpg", "Dart vader", 32.90m },
                    { 5, "t-shirt", "camisa legal", "ShoppingImages/6_spacex.jpg", "SPACEX", 10.90m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
