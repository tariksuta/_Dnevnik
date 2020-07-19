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
    public class SmjerController : Controller
    {
        private MyDbContext _context;
        public SmjerController(MyDbContext context)
        {
            _context = context;
        }

        public IActionResult Prikaz()
        {
            SmjerPrikazVM ulazniPodaci = new SmjerPrikazVM
            {
                ListaSmjerova = _context.Smjer.Select(
                    s => new SmjerPrikazVM.Rows
                    {
                        ID=s.ID,
                        Naziv=s.Naziv,
                        Stepen=s.Stepen,
                        Zvanje=s.Zvanje,
                        Oznaka=s.Oznaka
                    }
                ).ToList()
            };
            return View(ulazniPodaci);
        }

        public IActionResult DodajUredi(int SmjerID)
        {
            SmjerDodajUrediVM ulazniPodaci = new SmjerDodajUrediVM();
            if (SmjerID != 0)
            {
                Smjer s = _context.Smjer.Find(SmjerID);
                ulazniPodaci.SmjerID = s.ID;
                ulazniPodaci.Naziv = s.Naziv;
                ulazniPodaci.Oznaka = s.Oznaka;
                ulazniPodaci.Zvanje = s.Zvanje;
                ulazniPodaci.Stepen = s.Stepen;
            }
           
            return View(ulazniPodaci);
        }

        public IActionResult Snimi(SmjerDodajUrediVM input)
        {
            if (!ModelState.IsValid) {
                return View("DodajUredi", input);
            }
            Smjer s;
            if (input.SmjerID == 0)
            {
                s = new Smjer();
                _context.Add(s);
            }
            else
            {
                s = _context.Smjer.Find(input.SmjerID);
            }
            s.Naziv = input.Naziv;
            s.Stepen = input.Stepen;
            s.Zvanje = input.Zvanje;
            s.Oznaka = input.Oznaka;
            _context.SaveChanges();
            return Redirect("Prikaz");
        }

        public IActionResult Obrisi(int SmjerID)
        {
            try
            {
                Smjer smjer = _context.Smjer.Find(SmjerID);
                _context.Smjer.Remove(smjer);
                _context.SaveChanges();
            }
            catch(Exception)
            {

                TempData["greskaPoruka"] ="Nemoguće obrisati smjer!";
            }
            return Redirect("Prikaz");
        }

    }
}