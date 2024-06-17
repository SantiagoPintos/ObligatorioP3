using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tienda.AccesoDatos.Migrations
{
    /// <inheritdoc />
    public partial class eliminacionRepoToken : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tokens");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tokens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EncargadoId = table.Column<int>(type: "int", nullable: false),
                    TokenUsuario = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tokens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tokens_Encargado_EncargadoId",
                        column: x => x.EncargadoId,
                        principalTable: "Encargado",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tokens_EncargadoId",
                table: "Tokens",
                column: "EncargadoId");
        }
    }
}
