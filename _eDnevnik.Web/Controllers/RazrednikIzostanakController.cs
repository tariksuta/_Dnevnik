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
    [Autorizacija(roditelj: false, profesor: true, administrator: false)]

    public class RazrednikIzostanakController : Controller
    {
        private MyDbContext _context;
        public RazrednikIzostanakController(MyDbContext context)
        {
            _context = context;
        }

        public ActionResult Prikaz()
        {
            int id = _context.Profesor.Where(x => x.LoginID == HttpContext.GetLogiraniKorisnik().ID).FirstOrDefault().ID;
            int oid = _context.Odjeljenje.Where(x => x.RazrednikID == id).FirstOrDefault().ID;
            IzostanakPrikazVM ulazniPodaci = new IzostanakPrikazVM
            {
                ListaIzostanaka = _context.Izostanak.Where(x => x.SlusaPredmet.OdjeljenjeUcenik.OdjeljenjeID == oid).Select(
                    o => new IzostanakPrikazVM.Rows
                    {
                        IzostanakID = o.ID,
                        Napomena = o.Napomena,
                        DatumIzostanka = o.DatumIzostanka.ToShortDateString(),
                        Opravdan = o.Opravdan,
                        SlusaPredmet = o.SlusaPredmet.OdjeljenjeUcenik.BrojUDnevniku.ToString(),
                        Cas = o.Cas.BrojCasa + " " + o.Cas.Predaje.Predmet.Naziv
                    }
                ).ToList()
            };
            return View(ulazniPodaci);
        }

        public ActionResult DodajUredi(int IzostanakID)
        {
            IzostanaDodajUrediVM ulazniPodaci;
            Izostanak i;
            if (IzostanakID == 0)
            {
                ulazniPodaci = new IzostanaDodajUrediVM();
            }
            else
            {
                i = _context.Izostanak.Find(IzostanakID);
                ulazniPodaci = new IzostanaDodajUrediVM
                {
                    IzostanakID = i.ID,
                    Napomena = i.Napomena,
                    DatumIzostanka = i.DatumIzostanka,
                    CasID = i.CasID,
                    SlusaPredmetID = i.SlusaPredmetID,
                    Opravdan = i.Opravdan

                };
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

        public ActionResult Snimi(IzostanaDodajUrediVM x)
        {
            Izostanak o;
            if (x.IzostanakID == 0)
            {
                o = new Izostanak();
                _context.Add(o);
            }
            else
            {
                o = _context.Izostanak.Find(x.IzostanakID);
            }
            o.Napomena = x.Napomena;
            o.DatumIzostanka = x.DatumIzostanka;
            o.Opravdan = x.Opravdan;
            o.SlusaPredmetID = x.SlusaPredmetID;
            o.CasID = x.CasID;
            _context.SaveChanges();
            return RedirectToAction("Prikaz");
        }

        public IActionResult Obrisi(int IzostanakID)
        {

            Izostanak i = _context.Izostanak.Find(IzostanakID);

            _context.Remove(i);
            _context.SaveChanges();
            return Redirect("/RazrednikIzostanak/Prikaz");
        }


    }
}