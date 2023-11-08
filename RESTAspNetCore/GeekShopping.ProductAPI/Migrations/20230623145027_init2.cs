using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GeekShopping.ProductAPI.Migrations
{
    /// <inheritdoc />
    public partial class init2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "ImageURL",
                value: "/images\\12_gnu_linux.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "Descricao",
                value: "mascara doida do dart vader");

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Categoria", "Descricao", "ImageURL", "Nome", "Preco" },
                values: new object[] { 6, "moletom", "camisa preta com detalhes em vermelho e preto", "/images\\8_moletom_cobra_kay", "Cobra Kai", 55.90m });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "ImageURL",
                value: "/images\\gnu_linux.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "Descricao",
                value: "mascara legal");
        }
    }
}
