using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class removendoidItemVendavendas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ItemVendaId",
                table: "Venda");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ItemVendaId",
                table: "Venda",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
