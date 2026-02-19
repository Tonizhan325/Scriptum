using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Scriptum.Migrations
{
    /// <inheritdoc />
    public partial class URLVivo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "URL",
                table: "Libro",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "URL",
                table: "Libro");
        }
    }
}
