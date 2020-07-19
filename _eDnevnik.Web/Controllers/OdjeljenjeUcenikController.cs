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

namespace _eDnevnik.Web.Controllers
{
    [Autorizacija(roditelj: false, profesor: false, administrator: true)]
    public class OdjeljenjeUcenikController : Controller
    {
        private MyDbContext _context;
        public OdjeljenjeUcenikController(MyDbContext context)
        {
            _context = context;
        }

        public ActionResult Prikaz()
        {
            OdjeljenjeUcenikPrikazVM ulazniPodaci = new OdjeljenjeUcenikPrikazVM
            {
                ListaOdjeljenjeUcenik = _context.OdjeljenjeUcenik.Select(
                    o => new OdjeljenjeUcenikPrikazVM.Rows
                    {
                        OdjeljenjeUcenikID = o.ID,
                        Odjeljenje = o.Odjeljenje.Oznaka,
                        Ucenik= o.Ucenik.Ime + " " + o.Ucenik.Prezime,
                        BrojUDnevniku = o.BrojUDnevniku
                    }
                ).ToList()
            };
            return View(ulazniPodaci);
        }

        public ActionResult DodajUredi(int OdjeljenjeUcenikID)
        {
            OdjeljenjeUcenikDodajUrediVM ulazniPodaci = new OdjeljenjeUcenikDodajUrediVM();
            if (OdjeljenjeUcenikID != 0)
            {
                OdjeljenjeUcenik ou = _context.OdjeljenjeUcenik.Find(OdjeljenjeUcenikID);
                ulazniPodaci.OdjeljenjeUcenikID = ou.ID;
                ulazniPodaci.UcenikID = ou.UcenikID;
                ulazniPodaci.OdjeljenjeID = ou.OdjeljenjeID;
                ulazniPodaci.BrojUDnevniku = ou.BrojUDnevniku;
            }

            pripremiCmbStavke(ulazniPodaci);
            return View(ulazniPodaci);
        }

        private void pripremiCmbStavke(OdjeljenjeUcenikDodajUrediVM ulazniPodaci)
        {
            ulazniPodaci.Odjeljenje = _context.Odjeljenje.Select(s => new SelectListItem
            {
                Value = s.ID.ToString(),
                Text = s.Razred + " " + s.Oznaka
            }).ToList();

            ulazniPodaci.Ucenik = _context.Ucenik.Select(s => new SelectListItem
            {
                Value = s.ID.ToString(),
                Text = s.Ime + " " + s.Prezime
            }).ToList();
        }

        public ActionResult Snimi(OdjeljenjeUcenikDodajUrediVM input)
        {
            if (!ModelState.IsValid)
            {
                pripremiCmbStavke(input);
                return View("DodajUredi", input);
            }

            List<OdjeljenjeUcenik> odjeljenjeLista = _context.OdjeljenjeUcenik.Where(o => o.UcenikID == input.UcenikID || (o.OdjeljenjeID == input.OdjeljenjeID && o.BrojUDnevniku == input.BrojUDnevniku)).ToList();
            foreach (OdjeljenjeUcenik odjeljenje in odjeljenjeLista)
            {
                if (input.OdjeljenjeUcenikID == 0)
                {
                    pripremiCmbStavke(input);
                    TempData["greskaPoruka"] = "Učenik vec dodat/broj zazet!";
                    return View("DodajUredi", input);
                }

                if (odjeljenje.UcenikID != input.UcenikID || (odjeljenje.OdjeljenjeID == input.OdjeljenjeID && odjeljenje.BrojUDnevniku == input.BrojUDnevniku))
                {
                    pripremiCmbStavke(input);
                    TempData["greskaPoruka"] = "Učenik vec dodat/broj zazet!";
                    return View("DodajUredi", input);
                }
            }

            OdjeljenjeUcenik o;
            if (input.OdjeljenjeUcenikID == 0)
            {
                o = new OdjeljenjeUcenik();
                _context.Add(o);
            }
            else
            {
                o = _context.OdjeljenjeUcenik.Find(input.OdjeljenjeUcenikID);
            }
            o.OdjeljenjeID = input.OdjeljenjeID;
            o.UcenikID = input.UcenikID;
            o.BrojUDnevniku = input.BrojUDnevniku;
            _context.SaveChanges();
            return RedirectToAction("Prikaz");
        }

        public ActionResult Obrisi(int OdjeljenjeUcenikID)
        {
            try
            {
                OdjeljenjeUcenik o = _context.OdjeljenjeUcenik.Find(OdjeljenjeUcenikID);
                _context.OdjeljenjeUcenik.Remove(o);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                TempData["greskaPoruka"] = "Nemoguće obrisati učenika!";
            }
            return RedirectToAction("Prikaz");
        }
    }
}