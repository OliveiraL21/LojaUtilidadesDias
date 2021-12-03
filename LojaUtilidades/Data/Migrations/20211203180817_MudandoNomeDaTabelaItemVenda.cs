using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class MudandoNomeDaTabelaItemVenda : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Item-Venda_Produto_ProdutoId",
                table: "Item-Venda");

            migrationBuilder.DropForeignKey(
                name: "FK_Item-Venda_Venda_VendaId",
                table: "Item-Venda");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Item-Venda",
                table: "Item-Venda");

            migrationBuilder.RenameTable(
                name: "Item-Venda",
                newName: "ItemVenda");

            migrationBuilder.RenameIndex(
                name: "IX_Item-Venda_VendaId",
                table: "ItemVenda",
                newName: "IX_ItemVenda_VendaId");

            migrationBuilder.RenameIndex(
                name: "IX_Item-Venda_ProdutoId",
                table: "ItemVenda",
                newName: "IX_ItemVenda_ProdutoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ItemVenda",
                table: "ItemVenda",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemVenda_Produto_ProdutoId",
                table: "ItemVenda",
                column: "ProdutoId",
                principalTable: "Produto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemVenda_Venda_VendaId",
                table: "ItemVenda",
                column: "VendaId",
                principalTable: "Venda",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemVenda_Produto_ProdutoId",
                table: "ItemVenda");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemVenda_Venda_VendaId",
                table: "ItemVenda");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ItemVenda",
                table: "ItemVenda");

            migrationBuilder.RenameTable(
                name: "ItemVenda",
                newName: "Item-Venda");

            migrationBuilder.RenameIndex(
                name: "IX_ItemVenda_VendaId",
                table: "Item-Venda",
                newName: "IX_Item-Venda_VendaId");

            migrationBuilder.RenameIndex(
                name: "IX_ItemVenda_ProdutoId",
                table: "Item-Venda",
                newName: "IX_Item-Venda_ProdutoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Item-Venda",
                table: "Item-Venda",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Item-Venda_Produto_ProdutoId",
                table: "Item-Venda",
                column: "ProdutoId",
                principalTable: "Produto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Item-Venda_Venda_VendaId",
                table: "Item-Venda",
                column: "VendaId",
                principalTable: "Venda",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
