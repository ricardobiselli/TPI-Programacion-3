using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class OndeleteCascadeadded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Compatibilities_Products_ProductId",
                table: "Compatibilities");

            migrationBuilder.AddForeignKey(
                name: "FK_Compatibilities_Products_ProductId",
                table: "Compatibilities",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Compatibilities_Products_ProductId",
                table: "Compatibilities");

            migrationBuilder.AddForeignKey(
                name: "FK_Compatibilities_Products_ProductId",
                table: "Compatibilities",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id");
        }
    }
}
