using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace _eDnevnik.Data.Migrations
{
    public partial class imefajla : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte[]>(
                name: "RasporedFile",
                table: "RasporedKonsultacija",
                nullable: true,
                oldClrType: typeof(byte),
                oldType: "tinyint");

            migrationBuilder.AddColumn<string>(
                name: "imefajla",
                table: "RasporedKonsultacija",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "imefajla",
                table: "RasporedKonsultacija");

            migrationBuilder.AlterColumn<byte>(
                name: "RasporedFile",
                table: "RasporedKonsultacija",
                type: "tinyint",
                nullable: false,
                oldClrType: typeof(byte[]),
                oldNullable: true);
        }
    }
}
