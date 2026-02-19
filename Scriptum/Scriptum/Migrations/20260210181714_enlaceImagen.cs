using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Scriptum.Migrations
{
    /// <inheritdoc />
    public partial class enlaceImagen : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "enlaceImagen",
                table: "Libro",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "enlaceImagen",
                table: "Libro");
        }
    }
}
