using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace _eDnevnik.Data.Migrations
{
    public partial class ZapisnikFile : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "RasporedFile",
                table: "Zapisnik",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "imefajla",
                table: "Zapisnik",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RasporedFile",
                table: "Zapisnik");

            migrationBuilder.DropColumn(
                name: "imefajla",
                table: "Zapisnik");
        }
    }
}
