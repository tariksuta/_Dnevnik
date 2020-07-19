using _eDnevnik.Data.EntityModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace _eDnevnik.Data
{
    public class MyDbContext:DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> x):base(x)
        {

        }
        public MyDbContext() { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=app.fit.ba,1431;Database=p1857_eDnevnik; Trusted_Connection=false; MultipleActiveResultSets=true;User ID=p1857_eDnevnik;Password=ATMteam123***");
        }
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);
        //}
        public DbSet<Drzava> Drzava { get; set; }
        public DbSet<Grad> Grad { get; set; }
        public DbSet<Opcina> Opcina { get; set; }
        public DbSet<Ucenik> Ucenik { get; set; }
        public DbSet<Profesor> Profesor { get; set; }
        public DbSet<Roditelj> Roditelj { get; set; }
        public DbSet<Administrator> Administrator { get; set; }
        public DbSet<Login> Login { get; set; }
        public DbSet<UcenikSekcije> UcenikSekcije { get; set; }
        public DbSet<Sekcija> Sekcija { get; set; }
        public DbSet<Vladanje> Vladanje { get; set; }
        public DbSet<OdjeljenjeUcenik> OdjeljenjeUcenik { get; set; }
        public DbSet<Odjeljenje> Odjeljenje { get; set; }
        public DbSet<Smjer> Smjer { get; set; }
        public DbSet<SkolskaGodina> SkolskaGodina { get; set; }
        public DbSet<RasporedKonsultacija> RasporedKonsultacija { get; set; }
        public DbSet<Sjednica> Sjednica { get; set; }
        public DbSet<Zapisnik> Zapisnik { get; set; }
        public DbSet<SlusaPredmet> SlusaPredmet { get; set; }
        public DbSet<Predaje> Predaje { get; set; }
        public DbSet<Predmet> Predmet { get; set; }
        public DbSet<Cas> Cas { get; set; }
        public DbSet<Ocjena> Ocjena { get; set; }
        public DbSet<Izostanak> Izostanak { get; set; }
        public DbSet<AutorizacijskiToken> AutorizacijskiToken { get; set; }

    }
}
