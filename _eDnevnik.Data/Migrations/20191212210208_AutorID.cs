using Microsoft.EntityFrameworkCore.Migrations;

namespace _eDnevnik.Data.Migrations
{
    public partial class AutorID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ucenik_Vladanje_VladnjeID",
                table: "Ucenik");

            migrationBuilder.DropForeignKey(
                name: "FK_Zapisnik_Administrator_AutorID",
                table: "Zapisnik");

            migrationBuilder.DropIndex(
                name: "IX_Ucenik_VladnjeID",
                table: "Ucenik");

            migrationBuilder.DropColumn(
                name: "AutrID",
                table: "Zapisnik");

            migrationBuilder.DropColumn(
                name: "VladnjeID",
                table: "Ucenik");

            migrationBuilder.AlterColumn<int>(
                name: "AutorID",
                table: "Zapisnik",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ucenik_VladanjeID",
                table: "Ucenik",
                column: "VladanjeID");

            migrationBuilder.AddForeignKey(
                name: "FK_Ucenik_Vladanje_VladanjeID",
                table: "Ucenik",
                column: "VladanjeID",
                principalTable: "Vladanje",
                principalColumn: "ID",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Zapisnik_Administrator_AutorID",
                table: "Zapisnik",
                column: "AutorID",
                principalTable: "Administrator",
                principalColumn: "ID",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ucenik_Vladanje_VladanjeID",
                table: "Ucenik");

            migrationBuilder.DropForeignKey(
                name: "FK_Zapisnik_Administrator_AutorID",
                table: "Zapisnik");

            migrationBuilder.DropIndex(
                name: "IX_Ucenik_VladanjeID",
                table: "Ucenik");

            migrationBuilder.AlterColumn<int>(
                name: "AutorID",
                table: "Zapisnik",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "AutrID",
                table: "Zapisnik",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "VladnjeID",
                table: "Ucenik",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ucenik_VladnjeID",
                table: "Ucenik",
                column: "VladnjeID");

            migrationBuilder.AddForeignKey(
                name: "FK_Ucenik_Vladanje_VladnjeID",
                table: "Ucenik",
                column: "VladnjeID",
                principalTable: "Vladanje",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Zapisnik_Administrator_AutorID",
                table: "Zapisnik",
                column: "AutorID",
                principalTable: "Administrator",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
