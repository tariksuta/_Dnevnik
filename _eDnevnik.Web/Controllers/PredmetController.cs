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

    public class PredmetController : Controller
    {
        private MyDbContext _context;
        public PredmetController(MyDbContext context)
        {
            _context = context;
        }

        public ActionResult Prikaz()
        {
            PredmetPrikazVM ulazniPodaci = new PredmetPrikazVM
            {
                ListaPredmeta = _context.Predmet.Select(
                    o => new Predmet
                    {
                        ID = o.ID,
                        Naziv = o.Naziv,
                        Oznaka = o.Oznaka,
                        Razred = o.Razred
                    }
                ).ToList()
            };
            return View(ulazniPodaci);
        }

        public ActionResult DodajUredi(int PredmetID)
        {
            PredmetDodajUrediVM ulazniPodaci = new PredmetDodajUrediVM();
            if (PredmetID != 0)
            {
                Predmet p = _context.Predmet.Find(PredmetID);
                ulazniPodaci.PredmetID = p.ID;
                ulazniPodaci.Naziv = p.Naziv;
                ulazniPodaci.Oznaka = p.Oznaka;
                ulazniPodaci.Razred = p.Razred;
            }
            return View(ulazniPodaci);
        }

        public ActionResult Snimi(PredmetDodajUrediVM input)
        {
            if (!ModelState.IsValid)
            {
                return View("DodajUredi", input);
            }


            Predmet predmet = _context.Predmet.Where(o => o.Naziv == input.Naziv && o.Razred == input.Razred).FirstOrDefault();
            if (predmet != null && predmet.ID != input.PredmetID)
            {
                TempData["greskaPoruka"] = "Nemoguće dulpliciranje predmeta!";
                return View("DodajUredi", input);
            }

            Predmet o;
            if (input.PredmetID == 0)
            {
                o = new Predmet();
                _context.Add(o);
            }
            else
            {
                o = _context.Predmet.Find(input.PredmetID);
            }
            o.ID = input.PredmetID;
            o.Naziv = input.Naziv;
            o.Oznaka = input.Oznaka;
            o.Razred = input.Razred;
            _context.SaveChanges();
            return RedirectToAction("Prikaz");
        }

        public ActionResult Obrisi(int PredmetID)
        {
            try
            {

                Predmet o = _context.Predmet.Find(PredmetID);
                _context.Predmet.Remove(o);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                TempData["greskaPoruka"] = "Nemoguće obrisati predmet!";
            }
            return RedirectToAction("Prikaz");
        }
    }
}