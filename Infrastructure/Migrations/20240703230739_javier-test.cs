using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class javiertest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Compatibilities_Products_ProductId",
                table: "Compatibilities");

            migrationBuilder.DropIndex(
                name: "IX_Compatibilities_ProductId",
                table: "Compatibilities");

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "Compatibilities",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.CreateIndex(
                name: "IX_Compatibilities_ProductId",
                table: "Compatibilities",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Compatibilities_Products_ProductId",
                table: "Compatibilities",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Compatibilities_Products_ProductId",
                table: "Compatibilities");

            migrationBuilder.DropIndex(
                name: "IX_Compatibilities_ProductId",
                table: "Compatibilities");

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "Compatibilities",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Compatibilities_ProductId",
                table: "Compatibilities",
                column: "ProductId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Compatibilities_Products_ProductId",
                table: "Compatibilities",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
