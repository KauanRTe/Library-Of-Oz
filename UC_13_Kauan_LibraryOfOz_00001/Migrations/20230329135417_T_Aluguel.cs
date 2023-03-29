using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UC_13_Kauan_LibraryOfOz_00001.Migrations
{
    public partial class T_Aluguel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Periodo",
                table: "Aluguel");

            migrationBuilder.AddColumn<DateTime>(
                name: "DataDevolucao",
                table: "Aluguel",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataDevolucao",
                table: "Aluguel");

            migrationBuilder.AddColumn<string>(
                name: "Periodo",
                table: "Aluguel",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
