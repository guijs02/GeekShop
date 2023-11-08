using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GeekShopping.ProductAPI.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Preco = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Categoria = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ImageURL = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Categoria", "Descricao", "ImageURL", "Nome", "Preco" },
                values: new object[,]
                {
                    { 1, "t-shirt", "camisa legal", "/images\\13_dragon_ball.jpg", "Dragon ball", 15.90m },
                    { 2, "t-shirt", "camisa legal", "/images\\11_mars.jpg", "occupy mars", 17.90m },
                    { 3, "t-shirt", "camisa legal", "/images\\gnu_linux.jpg", "GNU", 18.95m },
                    { 4, "mascara", "mascara legal", "/images\\3_vader.jpg", "Dart vader", 32.90m },
                    { 5, "t-shirt", "camisa legal", "/images\\6_spacex.jpg", "SPACEX", 10.90m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
