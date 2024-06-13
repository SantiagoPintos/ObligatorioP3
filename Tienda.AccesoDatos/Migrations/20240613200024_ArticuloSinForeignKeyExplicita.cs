using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tienda.AccesoDatos.Migrations
{
    /// <inheritdoc />
    public partial class ArticuloSinForeignKeyExplicita : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Movimientos_ArticuloId",
                table: "Movimientos",
                column: "ArticuloId");

            migrationBuilder.AddForeignKey(
                name: "FK_Movimientos_Articulos_ArticuloId",
                table: "Movimientos",
                column: "ArticuloId",
                principalTable: "Articulos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movimientos_Articulos_ArticuloId",
                table: "Movimientos");

            migrationBuilder.DropIndex(
                name: "IX_Movimientos_ArticuloId",
                table: "Movimientos");
        }
    }
}
