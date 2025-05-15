using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace proyectoTienda.Data.Migrations
{
    /// <inheritdoc />
    public partial class MigracionI : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DetallesPedidos_Productos_IDPedido",
                table: "DetallesPedidos");

            migrationBuilder.CreateIndex(
                name: "IX_DetallesPedidos_IDProducto",
                table: "DetallesPedidos",
                column: "IDProducto");

            migrationBuilder.AddForeignKey(
                name: "FK_DetallesPedidos_Productos_IDProducto",
                table: "DetallesPedidos",
                column: "IDProducto",
                principalTable: "Productos",
                principalColumn: "IDProducto",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DetallesPedidos_Productos_IDProducto",
                table: "DetallesPedidos");

            migrationBuilder.DropIndex(
                name: "IX_DetallesPedidos_IDProducto",
                table: "DetallesPedidos");

            migrationBuilder.AddForeignKey(
                name: "FK_DetallesPedidos_Productos_IDPedido",
                table: "DetallesPedidos",
                column: "IDPedido",
                principalTable: "Productos",
                principalColumn: "IDProducto",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
