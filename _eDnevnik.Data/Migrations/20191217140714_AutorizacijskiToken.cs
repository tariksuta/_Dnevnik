using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace _eDnevnik.Data.Migrations
{
    public partial class AutorizacijskiToken : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AutorizacijskiToken",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Vrijednost = table.Column<string>(nullable: true),
                    LoginID = table.Column<int>(nullable: false),
                    VrijemeEvidentiranja = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AutorizacijskiToken", x => x.ID);
                    table.ForeignKey(
                        name: "FK_AutorizacijskiToken_Login_LoginID",
                        column: x => x.LoginID,
                        principalTable: "Login",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AutorizacijskiToken_LoginID",
                table: "AutorizacijskiToken",
                column: "LoginID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AutorizacijskiToken");
        }
    }
}
