using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _eDnevnik.Data;
using _eDnevnik.Data.EntityModel;
using _eDnevnik.Web.Helper;
using _eDnevnik.Web.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace _eDnevnik.Web.Controllers
{
    [Autorizacija(roditelj: false, profesor: false, administrator: true)]

    public class SekcijaController : Controller
    {
        private MyDbContext _context;

        public SekcijaController(MyDbContext db)
        {
            _context = db;
        }
        public IActionResult PrikazSekcija()
        {
            SekcijaPrikazSekcijaVM Model = new SekcijaPrikazSekcijaVM
            {
                sekcije = _context.Sekcija.Select(x => new SekcijaPrikazSekcijaVM.Row
                {
                    SekcijaID = x.ID,
                    Napomena = x.Napomena,
                    Naziv = x.Naziv,
                    Koordinator = x.Koordinator.Ime + " " + x.Koordinator.Prezime
                }).ToList()
            };
            return View(Model);
        }
        public IActionResult DodajUrediSekciju(int SekcijaID)
        {
            SekcijaDodajUrediVM ulazniPodaci = new SekcijaDodajUrediVM();
            if (SekcijaID != 0)
            { 
                Sekcija s = _context.Sekcija.Find(SekcijaID);
                ulazniPodaci.SekcijaID =  s.ID;
                ulazniPodaci.Naziv =  s.Naziv;
                ulazniPodaci.Napomena =  s.Napomena;
                ulazniPodaci.KoordinatorID =  s.KoordinatorID;
            }

            pripremiCmbStavke(ulazniPodaci);
            return View(ulazniPodaci);
        }

        private void pripremiCmbStavke(SekcijaDodajUrediVM ulazniPodaci) {
            ulazniPodaci.koordinatori = _context.Profesor.Select(x => new SelectListItem
            {
                Value = x.ID.ToString(),
                Text = x.Ime + " " + x.Prezime
            }).ToList();
        }

        public IActionResult SnimiSekciju(SekcijaDodajUrediVM input)
        {
            if (!ModelState.IsValid)
            {
                pripremiCmbStavke(input);
                return View("DodajUrediSekciju", input);
            }

            Sekcija s;
            if(input.SekcijaID == 0)
            {
                s = new Sekcija();
                _context.Add(s);
            }
            else
            {
                s = _context.Sekcija.Find(input.SekcijaID);
            }
            s.Napomena = input.Napomena;
            s.Naziv = input.Naziv;
            s.KoordinatorID = input.KoordinatorID;
            _context.SaveChanges();
            return Redirect("/Sekcija/PrikazSekcija"); // trenutno kad se snimi prebacuje na prikaz sekcija za određenog profesora
            //return Redirect("/Sekcija/Prikaz?ProfesorID="+ s.KoordinatorID); // trenutno kad se snimi prebacuje na prikaz sekcija za određenog profesora
        }
     

        public IActionResult Obrisi(int SekcijaID)
        {
            try
            {
                Sekcija s = _context.Sekcija.Find(SekcijaID);
                _context.Remove(s);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                TempData["greskaPoruka"] = "Nemoguće obrisati sekciju!";
            }

            return RedirectToAction("PrikazSekcija");
        }
    }
}