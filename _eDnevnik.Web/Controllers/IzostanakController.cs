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
    [Autorizacija(roditelj: false, profesor: true, administrator: false)]

    public class IzostanakController : Controller
    {
        private MyDbContext _context;
        public IzostanakController(MyDbContext context)
        {
            _context = context;
        }

        public ActionResult Prikaz()
        {
            IzostanakPrikazVM ulazniPodaci = new IzostanakPrikazVM
            {
                ListaIzostanaka = _context.Izostanak.Select(
                    o => new IzostanakPrikazVM.Rows
                    {
                        IzostanakID = o.ID,
                        Napomena = o.Napomena,
                        DatumIzostanka = o.DatumIzostanka.ToShortDateString(),
                        Opravdan = o.Opravdan,
                        SlusaPredmet = "Br." + o.SlusaPredmet.OdjeljenjeUcenik.BrojUDnevniku + " - " + o.SlusaPredmet.OdjeljenjeUcenik.Odjeljenje.Razred + " " + o.SlusaPredmet.OdjeljenjeUcenik.Odjeljenje.Oznaka,
                        Cas = o.Cas.BrojCasa + " " + o.Cas.Predaje.Predmet.Naziv
                    }
                ).ToList()
            };
            return View(ulazniPodaci);
        }

        public ActionResult DodajUredi(int IzostanakID)
        {
            IzostanaDodajUrediVM ulazniPodaci = new IzostanaDodajUrediVM();
            if (IzostanakID == 0)
            {
                ulazniPodaci.Izostanak = new Izostanak();
            }
            else
            {
                ulazniPodaci.Izostanak = _context.Izostanak.Find(IzostanakID);
            }

            ulazniPodaci.SlusaPredmet = _context.SlusaPredmet.Select(s => new SelectListItem
            {
                Value = s.ID.ToString(),
                Text = "Br." + s.OdjeljenjeUcenik.BrojUDnevniku + " - " + s.OdjeljenjeUcenik.Odjeljenje.Razred + " " + s.OdjeljenjeUcenik.Odjeljenje.Oznaka
            }).ToList();

            ulazniPodaci.Cas = _context.Cas.Select(s => new SelectListItem
            {
                Value = s.ID.ToString(),
                Text = s.Predaje.Predmet.Naziv
            }).ToList();

            return View(ulazniPodaci);
        }

        public ActionResult Snimi(int IzostanakID, string Napomena, DateTime DatumIzostanka, bool Opravdan, int SlusaPredmetID, int CasID)
        {
            Izostanak o;
            if (IzostanakID == 0)
            {
                o = new Izostanak();
                _context.Add(o);
            }
            else
            {
                o = _context.Izostanak.Find(IzostanakID);
            }
            o.Napomena = Napomena;
            o.DatumIzostanka = DatumIzostanka;
            o.Opravdan = Opravdan;
            o.SlusaPredmetID = SlusaPredmetID;
            o.CasID = CasID;
            _context.SaveChanges();
            return RedirectToAction("Prikaz");
        }

        public ActionResult Obrisi(int IzostanakID)
        {
            Izostanak o = _context.Izostanak.Find(IzostanakID);
            _context.Izostanak.Remove(o);
            _context.SaveChanges();
            return RedirectToAction("Prikaz");
        }
    }
}