using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class javier3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Compatibilities",
                table: "Products");

            migrationBuilder.CreateTable(
                name: "Compatibility",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RamType = table.Column<string>(type: "TEXT", nullable: true),
                    SocketType = table.Column<string>(type: "TEXT", nullable: true),
                    ProductId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Compatibility", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Compatibility_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Compatibility_ProductId",
                table: "Compatibility",
                column: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Compatibility");

            migrationBuilder.AddColumn<string>(
                name: "Compatibilities",
                table: "Products",
                type: "TEXT",
                nullable: true);
        }
    }
}
