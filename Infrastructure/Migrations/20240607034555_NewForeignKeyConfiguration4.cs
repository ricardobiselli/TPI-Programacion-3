using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class NewForeignKeyConfiguration4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClientId1",
                table: "Payments",
                type: "INTEGER",
                nullable: true);

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
    }
}
