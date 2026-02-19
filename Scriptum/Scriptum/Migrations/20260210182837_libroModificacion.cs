using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Scriptum.Migrations
{
    /// <inheritdoc />
    public partial class libroModificacion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "enlaceImagen",
                table: "Libro",
                newName: "EnlaceImagen");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EnlaceImagen",
                table: "Libro",
                newName: "enlaceImagen");
        }
    }
}
