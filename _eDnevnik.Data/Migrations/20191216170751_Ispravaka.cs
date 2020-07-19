using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace _eDnevnik.Data.Migrations
{
    public partial class Ispravaka : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sjednica_Zapisnik_ZapisnikID",
                table: "Sjednica");

            migrationBuilder.DropIndex(
                name: "IX_Sjednica_ZapisnikID",
                table: "Sjednica");

            migrationBuilder.DropColumn(
                name: "DatumRođenja",
                table: "Ucenik");

            migrationBuilder.DropColumn(
                name: "ZapisnikID",
                table: "Sjednica");

            migrationBuilder.DropColumn(
                name: "DatumRodjenaj",
                table: "Roditelj");

            migrationBuilder.DropColumn(
                name: "DatumRodjenaj",
                table: "Profesor");

            migrationBuilder.DropColumn(
                name: "IsPrebacenUViseOdjeljenje",
                table: "Odjeljenje");

            migrationBuilder.DropColumn(
                name: "Datum",
                table: "Ocjena");

            migrationBuilder.DropColumn(
                name: "Ime",
                table: "Login");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Login");

            migrationBuilder.DropColumn(
                name: "Prezime",
                table: "Login");

            migrationBuilder.DropColumn(
                name: "Username",
                table: "Login");

            migrationBuilder.DropColumn(
                name: "NastavanaJedinica",
                table: "Cas");

            migrationBuilder.DropColumn(
                name: "DatumRodjenaj",
                table: "Administrator");

            migrationBuilder.AddColumn<int>(
                name: "SjednicaID",
                table: "Zapisnik",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "DatumRodjenja",
                table: "Ucenik",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Spol",
                table: "Ucenik",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DatumRodjenja",
                table: "Roditelj",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Spol",
                table: "Roditelj",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DatumRodjenja",
                table: "Profesor",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Spol",
                table: "Profesor",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "PrebacenUViseOdjeljenje",
                table: "Odjeljenje",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "DatumUnosaOcjene",
                table: "Ocjena",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "KorisnickoIme",
                table: "Login",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Sifra",
                table: "Login",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "ZapamtiSifru",
                table: "Login",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "NastavnaJedinica",
                table: "Cas",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DatumRodjenja",
                table: "Administrator",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Spol",
                table: "Administrator",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Zapisnik_SjednicaID",
                table: "Zapisnik",
                column: "SjednicaID");

            migrationBuilder.AddForeignKey(
                name: "FK_Zapisnik_Sjednica_SjednicaID",
                table: "Zapisnik",
                column: "SjednicaID",
                principalTable: "Sjednica",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Zapisnik_Sjednica_SjednicaID",
                table: "Zapisnik");

            migrationBuilder.DropIndex(
                name: "IX_Zapisnik_SjednicaID",
                table: "Zapisnik");

            migrationBuilder.DropColumn(
                name: "SjednicaID",
                table: "Zapisnik");

            migrationBuilder.DropColumn(
                name: "DatumRodjenja",
                table: "Ucenik");

            migrationBuilder.DropColumn(
                name: "Spol",
                table: "Ucenik");

            migrationBuilder.DropColumn(
                name: "DatumRodjenja",
                table: "Roditelj");

            migrationBuilder.DropColumn(
                name: "Spol",
                table: "Roditelj");

            migrationBuilder.DropColumn(
                name: "DatumRodjenja",
                table: "Profesor");

            migrationBuilder.DropColumn(
                name: "Spol",
                table: "Profesor");

            migrationBuilder.DropColumn(
                name: "PrebacenUViseOdjeljenje",
                table: "Odjeljenje");

            migrationBuilder.DropColumn(
                name: "DatumUnosaOcjene",
                table: "Ocjena");

            migrationBuilder.DropColumn(
                name: "KorisnickoIme",
                table: "Login");

            migrationBuilder.DropColumn(
                name: "Sifra",
                table: "Login");

            migrationBuilder.DropColumn(
                name: "ZapamtiSifru",
                table: "Login");

            migrationBuilder.DropColumn(
                name: "NastavnaJedinica",
                table: "Cas");

            migrationBuilder.DropColumn(
                name: "DatumRodjenja",
                table: "Administrator");

            migrationBuilder.DropColumn(
                name: "Spol",
                table: "Administrator");

            migrationBuilder.AddColumn<DateTime>(
                name: "DatumRođenja",
                table: "Ucenik",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "ZapisnikID",
                table: "Sjednica",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "DatumRodjenaj",
                table: "Roditelj",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DatumRodjenaj",
                table: "Profesor",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsPrebacenUViseOdjeljenje",
                table: "Odjeljenje",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "Datum",
                table: "Ocjena",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Ime",
                table: "Login",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Login",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Prezime",
                table: "Login",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "Login",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NastavanaJedinica",
                table: "Cas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DatumRodjenaj",
                table: "Administrator",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_Sjednica_ZapisnikID",
                table: "Sjednica",
                column: "ZapisnikID");

            migrationBuilder.AddForeignKey(
                name: "FK_Sjednica_Zapisnik_ZapisnikID",
                table: "Sjednica",
                column: "ZapisnikID",
                principalTable: "Zapisnik",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
