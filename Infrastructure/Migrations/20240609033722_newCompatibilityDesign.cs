using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class newCompatibilityDesign : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Socket",
                table: "Compatibilities",
                newName: "SocketType");

            migrationBuilder.RenameColumn(
                name: "Series",
                table: "Compatibilities",
                newName: "RamType");

            migrationBuilder.RenameColumn(
                name: "Ram",
                table: "Compatibilities",
                newName: "PowerSupplyType");

            migrationBuilder.AddColumn<string>(
                name: "GpuType",
                table: "Compatibilities",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GpuType",
                table: "Compatibilities");

            migrationBuilder.RenameColumn(
                name: "SocketType",
                table: "Compatibilities",
                newName: "Socket");

            migrationBuilder.RenameColumn(
                name: "RamType",
                table: "Compatibilities",
                newName: "Series");

            migrationBuilder.RenameColumn(
                name: "PowerSupplyType",
                table: "Compatibilities",
                newName: "Ram");
        }
    }
}
