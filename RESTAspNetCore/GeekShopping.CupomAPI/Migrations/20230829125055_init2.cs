using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GeekShopping.CupomAPI.Migrations
{
    /// <inheritdoc />
    public partial class init2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Cupom",
                columns: new[] { "Id", "CupomCode", "Desconto" },
                values: new object[] { 1, "GUIRC_2023", 10m });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cupom",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
