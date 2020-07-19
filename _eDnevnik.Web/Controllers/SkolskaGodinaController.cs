using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _eDnevnik.Data;
using _eDnevnik.Data.EntityModel;
using _eDnevnik.Web.Helper;
using _eDnevnik.Web.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace _eDnevnik.Web.Controllers
{
    [Autorizacija(roditelj: false, profesor: false, administrator: true)]

    public class SkolskaGodinaController : Controller
    {
        private MyDbContext _context;
        public SkolskaGodinaController(MyDbContext context)
        {
            _context = context;
        }
        public IActionResult Prikaz()
        {
            SkolskaGodinaPrikazVM ulazniPodaci = new SkolskaGodinaPrikazVM
            {
                ListaSkolskihGodina = _context.SkolskaGodina.Select(
                    sg => new SkolskaGodinaPrikazVM.Rows
                    {
                        ID = sg.ID,
                        Naziv = sg.Naziv,
                        DatumPocetka=sg.DatumPocetka,
                        DatumZavrsetka=sg.DatumZavrsetka
                    }
                ).ToList()
            };
            return View(ulazniPodaci);
        }

        public IActionResult DodajUredi(int SkolskaGodinaID)
        {
            SkolskaGodinaDodajUrediVM ulazniPodaci = new SkolskaGodinaDodajUrediVM();
            if (SkolskaGodinaID != 0)
            {
               SkolskaGodina sk = _context.SkolskaGodina.Find(SkolskaGodinaID);
                ulazniPodaci.SkolskaGodinaID = sk.ID;
                ulazniPodaci.Naziv = sk.Naziv;
                ulazniPodaci.DatumPocetka = sk.DatumPocetka;
                ulazniPodaci.DatumZavrsetka = sk.DatumZavrsetka;
            }
            return View(ulazniPodaci);
        }

        public IActionResult Snimi(SkolskaGodinaDodajUrediVM input)
        {
            if (!ModelState.IsValid)
            {
                return View("DodajUredi", input);
            }

            SkolskaGodina s;
            if (input.SkolskaGodinaID == 0)
            {
                s = new SkolskaGodina();
                _context.Add(s);
            }
            else
            {
                s = _context.SkolskaGodina.Find(input.SkolskaGodinaID);
            }
            s.Naziv = input.Naziv;
            s.DatumPocetka = input.DatumPocetka;
            s.DatumZavrsetka = input.DatumZavrsetka;
            _context.SaveChanges();
            return Redirect("Prikaz");
        }

        public IActionResult Obrisi(int SkolskaGodinaID)
        {
            try
            {
                SkolskaGodina skolskaGodina = _context.SkolskaGodina.Find(SkolskaGodinaID);
                _context.SkolskaGodina.Remove(skolskaGodina);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                TempData["greskaPoruka"] = "Nemoguće obrisati školsku godinu!";
            }
            return Redirect("Prikaz");
        }

    }

}