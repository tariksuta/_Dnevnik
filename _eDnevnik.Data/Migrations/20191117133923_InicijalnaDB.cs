using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace _eDnevnik.Data.Migrations
{
    public partial class InicijalnaDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Drzava",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drzava", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Login",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Ime = table.Column<string>(nullable: true),
                    Prezime = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Login", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Predmet",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(nullable: true),
                    Oznaka = table.Column<string>(nullable: true),
                    Razred = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Predmet", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "SkolskaGodina",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(nullable: true),
                    DatumPocetka = table.Column<DateTime>(nullable: false),
                    DatumZavrsetka = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SkolskaGodina", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Smjer",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(nullable: true),
                    Stepen = table.Column<string>(nullable: true),
                    Zvanje = table.Column<string>(nullable: true),
                    Oznaka = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Smjer", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Vladanje",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VladanjeBrojcano = table.Column<int>(nullable: false),
                    VladanjeOpisno = table.Column<string>(nullable: true),
                    Napomena = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vladanje", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Grad",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(nullable: true),
                    DrzavaID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grad", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Grad_Drzava_DrzavaID",
                        column: x => x.DrzavaID,
                        principalTable: "Drzava",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RasporedKonsultacija",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Napomena = table.Column<string>(nullable: true),
                    RasporedFile = table.Column<byte>(nullable: false),
                    SkolskaGodinaID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RasporedKonsultacija", x => x.ID);
                    table.ForeignKey(
                        name: "FK_RasporedKonsultacija_SkolskaGodina_SkolskaGodinaID",
                        column: x => x.SkolskaGodinaID,
                        principalTable: "SkolskaGodina",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Opcina",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(nullable: true),
                    GradID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Opcina", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Opcina_Grad_GradID",
                        column: x => x.GradID,
                        principalTable: "Grad",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Administrator",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(nullable: true),
                    Prezime = table.Column<string>(nullable: true),
                    DatumRodjenaj = table.Column<DateTime>(nullable: false),
                    JMBG = table.Column<string>(nullable: true),
                    Telefon = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    OpcinaID = table.Column<int>(nullable: false),
                    LoginID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Administrator", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Administrator_Login_LoginID",
                        column: x => x.LoginID,
                        principalTable: "Login",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Administrator_Opcina_OpcinaID",
                        column: x => x.OpcinaID,
                        principalTable: "Opcina",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Profesor",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(nullable: true),
                    Prezime = table.Column<string>(nullable: true),
                    DatumRodjenaj = table.Column<DateTime>(nullable: false),
                    JMBG = table.Column<string>(nullable: true),
                    Telefon = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    OpcinaID = table.Column<int>(nullable: false),
                    RasporedKonsultacijaID = table.Column<int>(nullable: false),
                    LoginID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profesor", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Profesor_Login_LoginID",
                        column: x => x.LoginID,
                        principalTable: "Login",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Profesor_Opcina_OpcinaID",
                        column: x => x.OpcinaID,
                        principalTable: "Opcina",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Profesor_RasporedKonsultacija_RasporedKonsultacijaID",
                        column: x => x.RasporedKonsultacijaID,
                        principalTable: "RasporedKonsultacija",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Roditelj",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(nullable: true),
                    Prezime = table.Column<string>(nullable: true),
                    DatumRodjenaj = table.Column<DateTime>(nullable: false),
                    JMBG = table.Column<string>(nullable: true),
                    Telefon = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    OpcinaID = table.Column<int>(nullable: false),
                    LoginID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roditelj", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Roditelj_Login_LoginID",
                        column: x => x.LoginID,
                        principalTable: "Login",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Roditelj_Opcina_OpcinaID",
                        column: x => x.OpcinaID,
                        principalTable: "Opcina",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Zapisnik",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Sadrzaj = table.Column<string>(nullable: true),
                    Napomena = table.Column<string>(nullable: true),
                    AutorID = table.Column<int>(nullable: true),
                    AutrID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zapisnik", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Zapisnik_Administrator_AutorID",
                        column: x => x.AutorID,
                        principalTable: "Administrator",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Odjeljenje",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Razred = table.Column<int>(nullable: false),
                    Oznaka = table.Column<string>(nullable: true),
                    IsPrebacenUViseOdjeljenje = table.Column<bool>(nullable: false),
                    SkolskaGodinaID = table.Column<int>(nullable: false),
                    RazrednikID = table.Column<int>(nullable: false),
                    SmjerID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Odjeljenje", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Odjeljenje_Profesor_RazrednikID",
                        column: x => x.RazrednikID,
                        principalTable: "Profesor",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Odjeljenje_SkolskaGodina_SkolskaGodinaID",
                        column: x => x.SkolskaGodinaID,
                        principalTable: "SkolskaGodina",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Odjeljenje_Smjer_SmjerID",
                        column: x => x.SmjerID,
                        principalTable: "Smjer",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Sekcija",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(nullable: true),
                    Napomena = table.Column<string>(nullable: true),
                    KoordinatorID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sekcija", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Sekcija_Profesor_KoordinatorID",
                        column: x => x.KoordinatorID,
                        principalTable: "Profesor",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Ucenik",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(nullable: true),
                    Prezime = table.Column<string>(nullable: true),
                    DatumRođenja = table.Column<DateTime>(nullable: false),
                    JMBG = table.Column<string>(nullable: true),
                    RoditeljID = table.Column<int>(nullable: false),
                    VladnjeID = table.Column<int>(nullable: true),
                    VladanjeID = table.Column<int>(nullable: false),
                    OpcinaID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ucenik", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Ucenik_Opcina_OpcinaID",
                        column: x => x.OpcinaID,
                        principalTable: "Opcina",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Ucenik_Roditelj_RoditeljID",
                        column: x => x.RoditeljID,
                        principalTable: "Roditelj",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Ucenik_Vladanje_VladnjeID",
                        column: x => x.VladnjeID,
                        principalTable: "Vladanje",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Sjednica",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DatumOdrzavanja = table.Column<DateTime>(nullable: false),
                    Naziv = table.Column<string>(nullable: true),
                    SkolskaGodinaID = table.Column<int>(nullable: false),
                    ZapisnikID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sjednica", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Sjednica_SkolskaGodina_SkolskaGodinaID",
                        column: x => x.SkolskaGodinaID,
                        principalTable: "SkolskaGodina",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Sjednica_Zapisnik_ZapisnikID",
                        column: x => x.ZapisnikID,
                        principalTable: "Zapisnik",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Predaje",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProfesorID = table.Column<int>(nullable: false),
                    PredmetID = table.Column<int>(nullable: false),
                    OdjeljenjeID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Predaje", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Predaje_Odjeljenje_OdjeljenjeID",
                        column: x => x.OdjeljenjeID,
                        principalTable: "Odjeljenje",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Predaje_Predmet_PredmetID",
                        column: x => x.PredmetID,
                        principalTable: "Predmet",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Predaje_Profesor_ProfesorID",
                        column: x => x.ProfesorID,
                        principalTable: "Profesor",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "OdjeljenjeUcenik",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OdjeljenjeID = table.Column<int>(nullable: false),
                    UcenikID = table.Column<int>(nullable: false),
                    BrojUDnevniku = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OdjeljenjeUcenik", x => x.ID);
                    table.ForeignKey(
                        name: "FK_OdjeljenjeUcenik_Odjeljenje_OdjeljenjeID",
                        column: x => x.OdjeljenjeID,
                        principalTable: "Odjeljenje",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_OdjeljenjeUcenik_Ucenik_UcenikID",
                        column: x => x.UcenikID,
                        principalTable: "Ucenik",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "UcenikSekcije",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DatumUclanjenja = table.Column<DateTime>(nullable: false),
                    UcenikID = table.Column<int>(nullable: false),
                    SekcijaID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UcenikSekcije", x => x.ID);
                    table.ForeignKey(
                        name: "FK_UcenikSekcije_Sekcija_SekcijaID",
                        column: x => x.SekcijaID,
                        principalTable: "Sekcija",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_UcenikSekcije_Ucenik_UcenikID",
                        column: x => x.UcenikID,
                        principalTable: "Ucenik",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Cas",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrojCasa = table.Column<int>(nullable: false),
                    NastavanaJedinica = table.Column<string>(nullable: true),
                    DatumOdrzavanja = table.Column<DateTime>(nullable: false),
                    PredajeID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cas", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Cas_Predaje_PredajeID",
                        column: x => x.PredajeID,
                        principalTable: "Predaje",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "SlusaPredmet",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OdjeljenjeUcenikID = table.Column<int>(nullable: false),
                    PredajeID = table.Column<int>(nullable: false),
                    ZakljucnaOcjenaNaPolugodistu = table.Column<int>(nullable: false),
                    ZakljucnaOcjenaNaKraju = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SlusaPredmet", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SlusaPredmet_OdjeljenjeUcenik_OdjeljenjeUcenikID",
                        column: x => x.OdjeljenjeUcenikID,
                        principalTable: "OdjeljenjeUcenik",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_SlusaPredmet_Predaje_PredajeID",
                        column: x => x.PredajeID,
                        principalTable: "Predaje",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Izostanak",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Napomena = table.Column<string>(nullable: true),
                    DatumIzostanka = table.Column<DateTime>(nullable: false),
                    Opravdan = table.Column<bool>(nullable: false),
                    SlusaPredmetID = table.Column<int>(nullable: false),
                    CasID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Izostanak", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Izostanak_Cas_CasID",
                        column: x => x.CasID,
                        principalTable: "Cas",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Izostanak_SlusaPredmet_SlusaPredmetID",
                        column: x => x.SlusaPredmetID,
                        principalTable: "SlusaPredmet",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Ocjena",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OcjenaOpisno = table.Column<string>(nullable: true),
                    OcjenaBrojcano = table.Column<int>(nullable: false),
                    Datum = table.Column<DateTime>(nullable: false),
                    SlusaPredmetID = table.Column<int>(nullable: false),
                    CasID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ocjena", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Ocjena_Cas_CasID",
                        column: x => x.CasID,
                        principalTable: "Cas",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Ocjena_SlusaPredmet_SlusaPredmetID",
                        column: x => x.SlusaPredmetID,
                        principalTable: "SlusaPredmet",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Administrator_LoginID",
                table: "Administrator",
                column: "LoginID");

            migrationBuilder.CreateIndex(
                name: "IX_Administrator_OpcinaID",
                table: "Administrator",
                column: "OpcinaID");

            migrationBuilder.CreateIndex(
                name: "IX_Cas_PredajeID",
                table: "Cas",
                column: "PredajeID");

            migrationBuilder.CreateIndex(
                name: "IX_Grad_DrzavaID",
                table: "Grad",
                column: "DrzavaID");

            migrationBuilder.CreateIndex(
                name: "IX_Izostanak_CasID",
                table: "Izostanak",
                column: "CasID");

            migrationBuilder.CreateIndex(
                name: "IX_Izostanak_SlusaPredmetID",
                table: "Izostanak",
                column: "SlusaPredmetID");

            migrationBuilder.CreateIndex(
                name: "IX_Ocjena_CasID",
                table: "Ocjena",
                column: "CasID");

            migrationBuilder.CreateIndex(
                name: "IX_Ocjena_SlusaPredmetID",
                table: "Ocjena",
                column: "SlusaPredmetID");

            migrationBuilder.CreateIndex(
                name: "IX_Odjeljenje_RazrednikID",
                table: "Odjeljenje",
                column: "RazrednikID");

            migrationBuilder.CreateIndex(
                name: "IX_Odjeljenje_SkolskaGodinaID",
                table: "Odjeljenje",
                column: "SkolskaGodinaID");

            migrationBuilder.CreateIndex(
                name: "IX_Odjeljenje_SmjerID",
                table: "Odjeljenje",
                column: "SmjerID");

            migrationBuilder.CreateIndex(
                name: "IX_OdjeljenjeUcenik_OdjeljenjeID",
                table: "OdjeljenjeUcenik",
                column: "OdjeljenjeID");

            migrationBuilder.CreateIndex(
                name: "IX_OdjeljenjeUcenik_UcenikID",
                table: "OdjeljenjeUcenik",
                column: "UcenikID");

            migrationBuilder.CreateIndex(
                name: "IX_Opcina_GradID",
                table: "Opcina",
                column: "GradID");

            migrationBuilder.CreateIndex(
                name: "IX_Predaje_OdjeljenjeID",
                table: "Predaje",
                column: "OdjeljenjeID");

            migrationBuilder.CreateIndex(
                name: "IX_Predaje_PredmetID",
                table: "Predaje",
                column: "PredmetID");

            migrationBuilder.CreateIndex(
                name: "IX_Predaje_ProfesorID",
                table: "Predaje",
                column: "ProfesorID");

            migrationBuilder.CreateIndex(
                name: "IX_Profesor_LoginID",
                table: "Profesor",
                column: "LoginID");

            migrationBuilder.CreateIndex(
                name: "IX_Profesor_OpcinaID",
                table: "Profesor",
                column: "OpcinaID");

            migrationBuilder.CreateIndex(
                name: "IX_Profesor_RasporedKonsultacijaID",
                table: "Profesor",
                column: "RasporedKonsultacijaID");

            migrationBuilder.CreateIndex(
                name: "IX_RasporedKonsultacija_SkolskaGodinaID",
                table: "RasporedKonsultacija",
                column: "SkolskaGodinaID");

            migrationBuilder.CreateIndex(
                name: "IX_Roditelj_LoginID",
                table: "Roditelj",
                column: "LoginID");

            migrationBuilder.CreateIndex(
                name: "IX_Roditelj_OpcinaID",
                table: "Roditelj",
                column: "OpcinaID");

            migrationBuilder.CreateIndex(
                name: "IX_Sekcija_KoordinatorID",
                table: "Sekcija",
                column: "KoordinatorID");

            migrationBuilder.CreateIndex(
                name: "IX_Sjednica_SkolskaGodinaID",
                table: "Sjednica",
                column: "SkolskaGodinaID");

            migrationBuilder.CreateIndex(
                name: "IX_Sjednica_ZapisnikID",
                table: "Sjednica",
                column: "ZapisnikID");

            migrationBuilder.CreateIndex(
                name: "IX_SlusaPredmet_OdjeljenjeUcenikID",
                table: "SlusaPredmet",
                column: "OdjeljenjeUcenikID");

            migrationBuilder.CreateIndex(
                name: "IX_SlusaPredmet_PredajeID",
                table: "SlusaPredmet",
                column: "PredajeID");

            migrationBuilder.CreateIndex(
                name: "IX_Ucenik_OpcinaID",
                table: "Ucenik",
                column: "OpcinaID");

            migrationBuilder.CreateIndex(
                name: "IX_Ucenik_RoditeljID",
                table: "Ucenik",
                column: "RoditeljID");

            migrationBuilder.CreateIndex(
                name: "IX_Ucenik_VladnjeID",
                table: "Ucenik",
                column: "VladnjeID");

            migrationBuilder.CreateIndex(
                name: "IX_UcenikSekcije_SekcijaID",
                table: "UcenikSekcije",
                column: "SekcijaID");

            migrationBuilder.CreateIndex(
                name: "IX_UcenikSekcije_UcenikID",
                table: "UcenikSekcije",
                column: "UcenikID");

            migrationBuilder.CreateIndex(
                name: "IX_Zapisnik_AutorID",
                table: "Zapisnik",
                column: "AutorID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Izostanak");

            migrationBuilder.DropTable(
                name: "Ocjena");

            migrationBuilder.DropTable(
                name: "Sjednica");

            migrationBuilder.DropTable(
                name: "UcenikSekcije");

            migrationBuilder.DropTable(
                name: "Cas");

            migrationBuilder.DropTable(
                name: "SlusaPredmet");

            migrationBuilder.DropTable(
                name: "Zapisnik");

            migrationBuilder.DropTable(
                name: "Sekcija");

            migrationBuilder.DropTable(
                name: "OdjeljenjeUcenik");

            migrationBuilder.DropTable(
                name: "Predaje");

            migrationBuilder.DropTable(
                name: "Administrator");

            migrationBuilder.DropTable(
                name: "Ucenik");

            migrationBuilder.DropTable(
                name: "Odjeljenje");

            migrationBuilder.DropTable(
                name: "Predmet");

            migrationBuilder.DropTable(
                name: "Roditelj");

            migrationBuilder.DropTable(
                name: "Vladanje");

            migrationBuilder.DropTable(
                name: "Profesor");

            migrationBuilder.DropTable(
                name: "Smjer");

            migrationBuilder.DropTable(
                name: "Login");

            migrationBuilder.DropTable(
                name: "Opcina");

            migrationBuilder.DropTable(
                name: "RasporedKonsultacija");

            migrationBuilder.DropTable(
                name: "Grad");

            migrationBuilder.DropTable(
                name: "SkolskaGodina");

            migrationBuilder.DropTable(
                name: "Drzava");
        }
    }
}
