using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class numeroVenda : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            

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

           
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Venda_NumeroVenda",
                table: "Venda");

           

            migrationBuilder.DropColumn(
                name: "NumeroVenda",
                table: "Venda");

           
        }
    }
}
