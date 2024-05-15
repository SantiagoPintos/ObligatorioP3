using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tienda.AccesoDatos.Migrations
{
    /// <inheritdoc />
    public partial class anulacionPedidos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "anulado",
                table: "Pedidos",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "anulado",
                table: "Pedidos");
        }
    }
}
