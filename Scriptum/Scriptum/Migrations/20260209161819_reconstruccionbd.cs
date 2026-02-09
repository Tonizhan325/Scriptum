using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Scriptum.Migrations
{
    /// <inheritdoc />
    public partial class reconstruccionbd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "GeneroId",
                table: "Libro",
                type: "text",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Libro_GeneroId",
                table: "Libro",
                column: "GeneroId");

            migrationBuilder.AddForeignKey(
                name: "FK_Libro_Género_GeneroId",
                table: "Libro",
                column: "GeneroId",
                principalTable: "Género",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Libro_Género_GeneroId",
                table: "Libro");

            migrationBuilder.DropIndex(
                name: "IX_Libro_GeneroId",
                table: "Libro");

            migrationBuilder.DropColumn(
                name: "GeneroId",
                table: "Libro");
        }
    }
}
