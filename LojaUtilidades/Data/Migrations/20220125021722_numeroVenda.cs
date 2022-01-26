using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class numeroVenda : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ItemVenda_ProdutoId",
                table: "ItemVenda");

            migrationBuilder.AddColumn<int>(
                name: "NumeroVenda",
                table: "Venda",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Venda_NumeroVenda",
                table: "Venda",
                column: "NumeroVenda",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ItemVenda_ProdutoId",
                table: "ItemVenda",
                column: "ProdutoId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Venda_NumeroVenda",
                table: "Venda");

            migrationBuilder.DropIndex(
                name: "IX_ItemVenda_ProdutoId",
                table: "ItemVenda");

            migrationBuilder.DropColumn(
                name: "NumeroVenda",
                table: "Venda");

            migrationBuilder.CreateIndex(
                name: "IX_ItemVenda_ProdutoId",
                table: "ItemVenda",
                column: "ProdutoId");
        }
    }
}
