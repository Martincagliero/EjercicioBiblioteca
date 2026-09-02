using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AccesoDatos.Migrations
{
    /// <inheritdoc />
    public partial class AgregoAtributosLibroCat : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Libro_Categoria_CategoriaId1",
                table: "Libro");

            migrationBuilder.DropIndex(
                name: "IX_Libro_CategoriaId1",
                table: "Libro");

            migrationBuilder.DropColumn(
                name: "CategoriaId1",
                table: "Libro");

            migrationBuilder.AlterColumn<int>(
                name: "CategoriaId",
                table: "Libro",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.CreateIndex(
                name: "IX_Libro_CategoriaId",
                table: "Libro",
                column: "CategoriaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Libro_Categoria_CategoriaId",
                table: "Libro",
                column: "CategoriaId",
                principalTable: "Categoria",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Libro_Categoria_CategoriaId",
                table: "Libro");

            migrationBuilder.DropIndex(
                name: "IX_Libro_CategoriaId",
                table: "Libro");

            migrationBuilder.AlterColumn<string>(
                name: "CategoriaId",
                table: "Libro",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddColumn<int>(
                name: "CategoriaId1",
                table: "Libro",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Libro_CategoriaId1",
                table: "Libro",
                column: "CategoriaId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Libro_Categoria_CategoriaId1",
                table: "Libro",
                column: "CategoriaId1",
                principalTable: "Categoria",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
