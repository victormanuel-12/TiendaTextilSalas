using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace proyectoTienda.Data.Migrations
{
    /// <inheritdoc />
    public partial class MigracionKeyPedido : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DetallesPedidos_Productos_IDProducto",
                table: "DetallesPedidos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DetallesPedidos",
                table: "DetallesPedidos");

            migrationBuilder.DropIndex(
                name: "IX_DetallesPedidos_IDProducto",
                table: "DetallesPedidos");

            migrationBuilder.AlterColumn<int>(
                name: "IDPedido",
                table: "DetallesPedidos",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_DetallesPedidos",
                table: "DetallesPedidos",
                columns: new[] { "IDPedido", "IDProducto" });

            migrationBuilder.AddForeignKey(
                name: "FK_DetallesPedidos_Productos_IDPedido",
                table: "DetallesPedidos",
                column: "IDPedido",
                principalTable: "Productos",
                principalColumn: "IDProducto",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DetallesPedidos_Productos_IDPedido",
                table: "DetallesPedidos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DetallesPedidos",
                table: "DetallesPedidos");

            migrationBuilder.AlterColumn<int>(
                name: "IDPedido",
                table: "DetallesPedidos",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_DetallesPedidos",
                table: "DetallesPedidos",
                column: "IDPedido");

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
    }
}
