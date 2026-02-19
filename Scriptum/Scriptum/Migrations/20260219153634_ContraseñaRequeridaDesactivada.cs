using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Scriptum.Migrations
{
    /// <inheritdoc />
    public partial class ContraseñaRequeridaDesactivada : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "URL",
                table: "Libro");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "URL",
                table: "Libro",
                type: "text",
                nullable: true);
        }
    }
}
