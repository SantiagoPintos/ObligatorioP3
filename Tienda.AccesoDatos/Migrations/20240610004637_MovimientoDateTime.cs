using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tienda.AccesoDatos.Migrations
{
    /// <inheritdoc />
    public partial class MovimientoDateTime : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movimientos_Articulos_ArticuloId",
                table: "Movimientos");

            migrationBuilder.DropForeignKey(
                name: "FK_Movimientos_Usuarios_UsuarioId",
                table: "Movimientos");

            migrationBuilder.DropIndex(
                name: "IX_Movimientos_ArticuloId",
                table: "Movimientos");

            migrationBuilder.DropIndex(
                name: "IX_Movimientos_UsuarioId",
                table: "Movimientos");

            migrationBuilder.DropColumn(
                name: "Hora",
                table: "Movimientos");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Movimientos");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Fecha",
                table: "Movimientos",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date");

            migrationBuilder.AddColumn<string>(
                name: "Usuario",
                table: "Movimientos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Usuario",
                table: "Movimientos");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "Fecha",
                table: "Movimientos",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<TimeOnly>(
                name: "Hora",
                table: "Movimientos",
                type: "time",
                nullable: false,
                defaultValue: new TimeOnly(0, 0, 0));

            migrationBuilder.AddColumn<int>(
                name: "UsuarioId",
                table: "Movimientos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Movimientos_ArticuloId",
                table: "Movimientos",
                column: "ArticuloId");

            migrationBuilder.CreateIndex(
                name: "IX_Movimientos_UsuarioId",
                table: "Movimientos",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Movimientos_Articulos_ArticuloId",
                table: "Movimientos",
                column: "ArticuloId",
                principalTable: "Articulos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Movimientos_Usuarios_UsuarioId",
                table: "Movimientos",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
