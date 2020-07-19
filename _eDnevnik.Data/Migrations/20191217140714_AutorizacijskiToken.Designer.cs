﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using _eDnevnik.Data;

namespace _eDnevnik.Data.Migrations
{
    [DbContext(typeof(MyDbContext))]
    [Migration("20191217140714_AutorizacijskiToken")]
    partial class AutorizacijskiToken
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("_eDnevnik.Data.EntityModel.Administrator", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DatumRodjenja")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("JMBG")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("LoginID")
                        .HasColumnType("int");

                    b.Property<int>("OpcinaID")
                        .HasColumnType("int");

                    b.Property<string>("Prezime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Spol")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefon")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("LoginID");

                    b.HasIndex("OpcinaID");

                    b.ToTable("Administrator");
                });

            modelBuilder.Entity("_eDnevnik.Data.EntityModel.AutorizacijskiToken", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("LoginID")
                        .HasColumnType("int");

                    b.Property<string>("Vrijednost")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("VrijemeEvidentiranja")
                        .HasColumnType("datetime2");

                    b.HasKey("ID");

                    b.HasIndex("LoginID");

                    b.ToTable("AutorizacijskiToken");
                });

            modelBuilder.Entity("_eDnevnik.Data.EntityModel.Cas", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BrojCasa")
                        .HasColumnType("int");

                    b.Property<DateTime>("DatumOdrzavanja")
                        .HasColumnType("datetime2");

                    b.Property<string>("NastavnaJedinica")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PredajeID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("PredajeID");

                    b.ToTable("Cas");
                });

            modelBuilder.Entity("_eDnevnik.Data.EntityModel.Drzava", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Naziv")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Drzava");
                });

            modelBuilder.Entity("_eDnevnik.Data.EntityModel.Grad", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DrzavaID")
                        .HasColumnType("int");

                    b.Property<string>("Naziv")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("DrzavaID");

                    b.ToTable("Grad");
                });

            modelBuilder.Entity("_eDnevnik.Data.EntityModel.Izostanak", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CasID")
                        .HasColumnType("int");

                    b.Property<DateTime>("DatumIzostanka")
                        .HasColumnType("datetime2");

                    b.Property<string>("Napomena")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Opravdan")
                        .HasColumnType("bit");

                    b.Property<int>("SlusaPredmetID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("CasID");

                    b.HasIndex("SlusaPredmetID");

                    b.ToTable("Izostanak");
                });

            modelBuilder.Entity("_eDnevnik.Data.EntityModel.Login", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("KorisnickoIme")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sifra")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("ZapamtiSifru")
                        .HasColumnType("bit");

                    b.HasKey("ID");

                    b.ToTable("Login");
                });

            modelBuilder.Entity("_eDnevnik.Data.EntityModel.Ocjena", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CasID")
                        .HasColumnType("int");

                    b.Property<DateTime>("DatumUnosaOcjene")
                        .HasColumnType("datetime2");

                    b.Property<int>("OcjenaBrojcano")
                        .HasColumnType("int");

                    b.Property<string>("OcjenaOpisno")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SlusaPredmetID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("CasID");

                    b.HasIndex("SlusaPredmetID");

                    b.ToTable("Ocjena");
                });

            modelBuilder.Entity("_eDnevnik.Data.EntityModel.Odjeljenje", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Oznaka")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PrebacenUViseOdjeljenje")
                        .HasColumnType("bit");

                    b.Property<int>("Razred")
                        .HasColumnType("int");

                    b.Property<int>("RazrednikID")
                        .HasColumnType("int");

                    b.Property<int>("SkolskaGodinaID")
                        .HasColumnType("int");

                    b.Property<int>("SmjerID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("RazrednikID");

                    b.HasIndex("SkolskaGodinaID");

                    b.HasIndex("SmjerID");

                    b.ToTable("Odjeljenje");
                });

            modelBuilder.Entity("_eDnevnik.Data.EntityModel.OdjeljenjeUcenik", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BrojUDnevniku")
                        .HasColumnType("int");

                    b.Property<int>("OdjeljenjeID")
                        .HasColumnType("int");

                    b.Property<int>("UcenikID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("OdjeljenjeID");

                    b.HasIndex("UcenikID");

                    b.ToTable("OdjeljenjeUcenik");
                });

            modelBuilder.Entity("_eDnevnik.Data.EntityModel.Opcina", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("GradID")
                        .HasColumnType("int");

                    b.Property<string>("Naziv")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("GradID");

                    b.ToTable("Opcina");
                });

            modelBuilder.Entity("_eDnevnik.Data.EntityModel.Predaje", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("OdjeljenjeID")
                        .HasColumnType("int");

                    b.Property<int>("PredmetID")
                        .HasColumnType("int");

                    b.Property<int>("ProfesorID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("OdjeljenjeID");

                    b.HasIndex("PredmetID");

                    b.HasIndex("ProfesorID");

                    b.ToTable("Predaje");
                });

            modelBuilder.Entity("_eDnevnik.Data.EntityModel.Predmet", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Naziv")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Oznaka")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Razred")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("Predmet");
                });

            modelBuilder.Entity("_eDnevnik.Data.EntityModel.Profesor", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DatumRodjenja")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("JMBG")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("LoginID")
                        .HasColumnType("int");

                    b.Property<int>("OpcinaID")
                        .HasColumnType("int");

                    b.Property<string>("Prezime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RasporedKonsultacijaID")
                        .HasColumnType("int");

                    b.Property<string>("Spol")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefon")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("LoginID");

                    b.HasIndex("OpcinaID");

                    b.HasIndex("RasporedKonsultacijaID");

                    b.ToTable("Profesor");
                });

            modelBuilder.Entity("_eDnevnik.Data.EntityModel.RasporedKonsultacija", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Napomena")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte>("RasporedFile")
                        .HasColumnType("tinyint");

                    b.Property<int>("SkolskaGodinaID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("SkolskaGodinaID");

                    b.ToTable("RasporedKonsultacija");
                });

            modelBuilder.Entity("_eDnevnik.Data.EntityModel.Roditelj", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DatumRodjenja")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("JMBG")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("LoginID")
                        .HasColumnType("int");

                    b.Property<int>("OpcinaID")
                        .HasColumnType("int");

                    b.Property<string>("Prezime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Spol")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefon")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("LoginID");

                    b.HasIndex("OpcinaID");

                    b.ToTable("Roditelj");
                });

            modelBuilder.Entity("_eDnevnik.Data.EntityModel.Sekcija", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("KoordinatorID")
                        .HasColumnType("int");

                    b.Property<string>("Napomena")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Naziv")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("KoordinatorID");

                    b.ToTable("Sekcija");
                });

            modelBuilder.Entity("_eDnevnik.Data.EntityModel.Sjednica", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DatumOdrzavanja")
                        .HasColumnType("datetime2");

                    b.Property<string>("Naziv")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SkolskaGodinaID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("SkolskaGodinaID");

                    b.ToTable("Sjednica");
                });

            modelBuilder.Entity("_eDnevnik.Data.EntityModel.SkolskaGodina", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DatumPocetka")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DatumZavrsetka")
                        .HasColumnType("datetime2");

                    b.Property<string>("Naziv")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("SkolskaGodina");
                });

            modelBuilder.Entity("_eDnevnik.Data.EntityModel.SlusaPredmet", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("OdjeljenjeUcenikID")
                        .HasColumnType("int");

                    b.Property<int>("PredajeID")
                        .HasColumnType("int");

                    b.Property<int>("ZakljucnaOcjenaNaKraju")
                        .HasColumnType("int");

                    b.Property<int>("ZakljucnaOcjenaNaPolugodistu")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("OdjeljenjeUcenikID");

                    b.HasIndex("PredajeID");

                    b.ToTable("SlusaPredmet");
                });

            modelBuilder.Entity("_eDnevnik.Data.EntityModel.Smjer", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Naziv")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Oznaka")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Stepen")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Zvanje")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Smjer");
                });

            modelBuilder.Entity("_eDnevnik.Data.EntityModel.Ucenik", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DatumRodjenja")
                        .HasColumnType("datetime2");

                    b.Property<string>("Ime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("JMBG")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OpcinaID")
                        .HasColumnType("int");

                    b.Property<string>("Prezime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoditeljID")
                        .HasColumnType("int");

                    b.Property<string>("Spol")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("VladanjeID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("OpcinaID");

                    b.HasIndex("RoditeljID");

                    b.HasIndex("VladanjeID");

                    b.ToTable("Ucenik");
                });

            modelBuilder.Entity("_eDnevnik.Data.EntityModel.UcenikSekcije", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DatumUclanjenja")
                        .HasColumnType("datetime2");

                    b.Property<int>("SekcijaID")
                        .HasColumnType("int");

                    b.Property<int>("UcenikID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("SekcijaID");

                    b.HasIndex("UcenikID");

                    b.ToTable("UcenikSekcije");
                });

            modelBuilder.Entity("_eDnevnik.Data.EntityModel.Vladanje", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Napomena")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("VladanjeBrojcano")
                        .HasColumnType("int");

                    b.Property<string>("VladanjeOpisno")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Vladanje");
                });

            modelBuilder.Entity("_eDnevnik.Data.EntityModel.Zapisnik", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AutorID")
                        .HasColumnType("int");

                    b.Property<string>("Napomena")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sadrzaj")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SjednicaID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("AutorID");

                    b.HasIndex("SjednicaID");

                    b.ToTable("Zapisnik");
                });

            modelBuilder.Entity("_eDnevnik.Data.EntityModel.Administrator", b =>
                {
                    b.HasOne("_eDnevnik.Data.EntityModel.Login", "Login")
                        .WithMany()
                        .HasForeignKey("LoginID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("_eDnevnik.Data.EntityModel.Opcina", "Opcina")
                        .WithMany()
                        .HasForeignKey("OpcinaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("_eDnevnik.Data.EntityModel.AutorizacijskiToken", b =>
                {
                    b.HasOne("_eDnevnik.Data.EntityModel.Login", "Login")
                        .WithMany()
                        .HasForeignKey("LoginID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("_eDnevnik.Data.EntityModel.Cas", b =>
                {
                    b.HasOne("_eDnevnik.Data.EntityModel.Predaje", "Predaje")
                        .WithMany()
                        .HasForeignKey("PredajeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("_eDnevnik.Data.EntityModel.Grad", b =>
                {
                    b.HasOne("_eDnevnik.Data.EntityModel.Drzava", "Drzava")
                        .WithMany()
                        .HasForeignKey("DrzavaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("_eDnevnik.Data.EntityModel.Izostanak", b =>
                {
                    b.HasOne("_eDnevnik.Data.EntityModel.Cas", "Cas")
                        .WithMany()
                        .HasForeignKey("CasID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("_eDnevnik.Data.EntityModel.SlusaPredmet", "SlusaPredmet")
                        .WithMany()
                        .HasForeignKey("SlusaPredmetID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("_eDnevnik.Data.EntityModel.Ocjena", b =>
                {
                    b.HasOne("_eDnevnik.Data.EntityModel.Cas", "Cas")
                        .WithMany()
                        .HasForeignKey("CasID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("_eDnevnik.Data.EntityModel.SlusaPredmet", "SlusaPredmet")
                        .WithMany()
                        .HasForeignKey("SlusaPredmetID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("_eDnevnik.Data.EntityModel.Odjeljenje", b =>
                {
                    b.HasOne("_eDnevnik.Data.EntityModel.Profesor", "Razrednik")
                        .WithMany()
                        .HasForeignKey("RazrednikID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("_eDnevnik.Data.EntityModel.SkolskaGodina", "SkolskaGodina")
                        .WithMany()
                        .HasForeignKey("SkolskaGodinaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("_eDnevnik.Data.EntityModel.Smjer", "Smjer")
                        .WithMany()
                        .HasForeignKey("SmjerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("_eDnevnik.Data.EntityModel.OdjeljenjeUcenik", b =>
                {
                    b.HasOne("_eDnevnik.Data.EntityModel.Odjeljenje", "Odjeljenje")
                        .WithMany()
                        .HasForeignKey("OdjeljenjeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("_eDnevnik.Data.EntityModel.Ucenik", "Ucenik")
                        .WithMany()
                        .HasForeignKey("UcenikID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("_eDnevnik.Data.EntityModel.Opcina", b =>
                {
                    b.HasOne("_eDnevnik.Data.EntityModel.Grad", "Grad")
                        .WithMany()
                        .HasForeignKey("GradID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("_eDnevnik.Data.EntityModel.Predaje", b =>
                {
                    b.HasOne("_eDnevnik.Data.EntityModel.Odjeljenje", "Odjeljenje")
                        .WithMany()
                        .HasForeignKey("OdjeljenjeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("_eDnevnik.Data.EntityModel.Predmet", "Predmet")
                        .WithMany()
                        .HasForeignKey("PredmetID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("_eDnevnik.Data.EntityModel.Profesor", "Profesor")
                        .WithMany()
                        .HasForeignKey("ProfesorID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("_eDnevnik.Data.EntityModel.Profesor", b =>
                {
                    b.HasOne("_eDnevnik.Data.EntityModel.Login", "Login")
                        .WithMany()
                        .HasForeignKey("LoginID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("_eDnevnik.Data.EntityModel.Opcina", "Opcina")
                        .WithMany()
                        .HasForeignKey("OpcinaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("_eDnevnik.Data.EntityModel.RasporedKonsultacija", "RasporedKonsultacija")
                        .WithMany()
                        .HasForeignKey("RasporedKonsultacijaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("_eDnevnik.Data.EntityModel.RasporedKonsultacija", b =>
                {
                    b.HasOne("_eDnevnik.Data.EntityModel.SkolskaGodina", "SkolskaGodina")
                        .WithMany()
                        .HasForeignKey("SkolskaGodinaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("_eDnevnik.Data.EntityModel.Roditelj", b =>
                {
                    b.HasOne("_eDnevnik.Data.EntityModel.Login", "Login")
                        .WithMany()
                        .HasForeignKey("LoginID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("_eDnevnik.Data.EntityModel.Opcina", "Opcina")
                        .WithMany()
                        .HasForeignKey("OpcinaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("_eDnevnik.Data.EntityModel.Sekcija", b =>
                {
                    b.HasOne("_eDnevnik.Data.EntityModel.Profesor", "Koordinator")
                        .WithMany()
                        .HasForeignKey("KoordinatorID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("_eDnevnik.Data.EntityModel.Sjednica", b =>
                {
                    b.HasOne("_eDnevnik.Data.EntityModel.SkolskaGodina", "SkolskaGodina")
                        .WithMany()
                        .HasForeignKey("SkolskaGodinaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("_eDnevnik.Data.EntityModel.SlusaPredmet", b =>
                {
                    b.HasOne("_eDnevnik.Data.EntityModel.OdjeljenjeUcenik", "OdjeljenjeUcenik")
                        .WithMany()
                        .HasForeignKey("OdjeljenjeUcenikID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("_eDnevnik.Data.EntityModel.Predaje", "Predaje")
                        .WithMany()
                        .HasForeignKey("PredajeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("_eDnevnik.Data.EntityModel.Ucenik", b =>
                {
                    b.HasOne("_eDnevnik.Data.EntityModel.Opcina", "Opcina")
                        .WithMany()
                        .HasForeignKey("OpcinaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("_eDnevnik.Data.EntityModel.Roditelj", "Roditelj")
                        .WithMany()
                        .HasForeignKey("RoditeljID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("_eDnevnik.Data.EntityModel.Vladanje", "Vladanje")
                        .WithMany()
                        .HasForeignKey("VladanjeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("_eDnevnik.Data.EntityModel.UcenikSekcije", b =>
                {
                    b.HasOne("_eDnevnik.Data.EntityModel.Sekcija", "Sekcija")
                        .WithMany()
                        .HasForeignKey("SekcijaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("_eDnevnik.Data.EntityModel.Ucenik", "Ucenik")
                        .WithMany()
                        .HasForeignKey("UcenikID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("_eDnevnik.Data.EntityModel.Zapisnik", b =>
                {
                    b.HasOne("_eDnevnik.Data.EntityModel.Administrator", "Autor")
                        .WithMany()
                        .HasForeignKey("AutorID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("_eDnevnik.Data.EntityModel.Sjednica", "Sjednica")
                        .WithMany()
                        .HasForeignKey("SjednicaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
