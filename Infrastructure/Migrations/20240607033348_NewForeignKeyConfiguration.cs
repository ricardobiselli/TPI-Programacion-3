using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class NewForeignKeyConfiguration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Orders_OrderId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_OrderId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "Products");

            migrationBuilder.AddColumn<int>(
                name: "ClientId1",
                table: "Payments",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "Compatibilities",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ClientId1",
                table: "Carts",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Payments_ClientId1",
                table: "Payments",
                column: "ClientId1");

            migrationBuilder.CreateIndex(
                name: "IX_Carts_ClientId1",
                table: "Carts",
                column: "ClientId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Carts_Users_ClientId1",
                table: "Carts",
                column: "ClientId1",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_Users_ClientId1",
                table: "Payments",
                column: "ClientId1",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carts_Users_ClientId1",
                table: "Carts");

            migrationBuilder.DropForeignKey(
                name: "FK_Payments_Users_ClientId1",
                table: "Payments");

            migrationBuilder.DropIndex(
                name: "IX_Payments_ClientId1",
                table: "Payments");

            migrationBuilder.DropIndex(
                name: "IX_Carts_ClientId1",
                table: "Carts");

            migrationBuilder.DropColumn(
                name: "ClientId1",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "ClientId1",
                table: "Carts");

            migrationBuilder.AddColumn<int>(
                name: "OrderId",
                table: "Products",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "Compatibilities",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.CreateIndex(
                name: "IX_Products_OrderId",
                table: "Products",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Orders_OrderId",
                table: "Products",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "OrderId");
        }
    }
}
