using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AccesoDatos.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Libro_Libro_LibroId",
                table: "Libro");

            migrationBuilder.DropIndex(
                name: "IX_Libro_LibroId",
                table: "Libro");

            migrationBuilder.DropColumn(
                name: "LibroId",
                table: "Libro");

            migrationBuilder.RenameColumn(
                name: "Año",
                table: "Libro",
                newName: "Anio");

            migrationBuilder.CreateIndex(
                name: "IX_Libro_AutorId",
                table: "Libro",
                column: "AutorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Libro_Autor_AutorId",
                table: "Libro",
                column: "AutorId",
                principalTable: "Autor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Libro_Autor_AutorId",
                table: "Libro");

            migrationBuilder.DropIndex(
                name: "IX_Libro_AutorId",
                table: "Libro");

            migrationBuilder.RenameColumn(
                name: "Anio",
                table: "Libro",
                newName: "Año");

            migrationBuilder.AddColumn<int>(
                name: "LibroId",
                table: "Libro",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Libro_LibroId",
                table: "Libro",
                column: "LibroId");

            migrationBuilder.AddForeignKey(
                name: "FK_Libro_Libro_LibroId",
                table: "Libro",
                column: "LibroId",
                principalTable: "Libro",
                principalColumn: "Id");
        }
    }
}
