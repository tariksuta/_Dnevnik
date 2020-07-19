using Microsoft.EntityFrameworkCore.Migrations;

namespace _eDnevnik.Data.Migrations
{
    public partial class NazivSlike : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NazivSlike",
                table: "Roditelj",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NazivSlike",
                table: "Profesor",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NazivSlike",
                table: "Administrator",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NazivSlike",
                table: "Roditelj");

            migrationBuilder.DropColumn(
                name: "NazivSlike",
                table: "Profesor");

            migrationBuilder.DropColumn(
                name: "NazivSlike",
                table: "Administrator");
        }
    }
}
