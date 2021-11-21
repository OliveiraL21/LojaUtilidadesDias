using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class chghr_vendatoTimeSpanHr_Venda : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<TimeSpan>(
                name: "Hora_Venda",
                table: "Venda",
                type: "time(6)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Hora_Venda",
                table: "Venda",
                type: "datetime(6)",
                nullable: false,
                oldClrType: typeof(TimeSpan),
                oldType: "time(6)");
        }
    }
}
