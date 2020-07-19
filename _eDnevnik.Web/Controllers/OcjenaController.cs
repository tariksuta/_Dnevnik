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

    public class OcjenaController : Controller
    {
        private MyDbContext _context;
        public OcjenaController(MyDbContext context)
        {
            _context = context;
        }

        public ActionResult Prikaz()
        {
            OcjenaPrikazVM ulazniPodaci = new OcjenaPrikazVM
            {
                ListaOcjena = _context.Ocjena.Select(
                    o => new OcjenaPrikazVM.Rows
                    {
                        OcjenaID = o.ID,
                        OcjenaOpisno = o.OcjenaOpisno,
                        OcjenaBrojcano = o.OcjenaBrojcano,
                        DatumUnosaOcjene = o.DatumUnosaOcjene.ToShortDateString(),
                        SlusaPredmet ="Br." + o.SlusaPredmet.OdjeljenjeUcenik.BrojUDnevniku + " odj." + o.SlusaPredmet.OdjeljenjeUcenik.Odjeljenje.Razred + " " + o.SlusaPredmet.OdjeljenjeUcenik.Odjeljenje.Oznaka,
                        Cas = o.Cas.BrojCasa + " " + o.Cas.Predaje.Predmet.Naziv
                    }
                ).ToList()
            };
            return View(ulazniPodaci);
        }

        public ActionResult DodajUredi(int OcjenaID)
        {
            OcjenaDodajUrediVM ulazniPodaci = new OcjenaDodajUrediVM();
            if (OcjenaID == 0)
            {
                ulazniPodaci.Ocjena = new Ocjena();
            }
            else
            {
                ulazniPodaci.Ocjena = _context.Ocjena.Find(OcjenaID);
            }

            ulazniPodaci.SlusaPredmet = _context.SlusaPredmet.Select(s => new SelectListItem
            {
                Value = s.ID.ToString(),
                Text = "Br." + s.OdjeljenjeUcenik.BrojUDnevniku + " odj." + s.OdjeljenjeUcenik.Odjeljenje.Razred + " " + s.OdjeljenjeUcenik.Odjeljenje.Oznaka
            }).ToList();

            ulazniPodaci.Cas = _context.Cas.Select(s => new SelectListItem
            {
                Value = s.ID.ToString(),
                Text = s.Predaje.Predmet.Naziv
            }).ToList();

            return View(ulazniPodaci);
        }

        public ActionResult Snimi(int OcjenaID, string OcjenaOpisno, int OcjenaBrojcano, DateTime DatumUnosaOcjene, int SlusaPredmetID, int CasID)
        {
            Ocjena o;
            if (OcjenaID == 0)
            {
                o = new Ocjena();
                _context.Add(o);
            }
            else
            {
                o = _context.Ocjena.Find(OcjenaID);
            }
            o.OcjenaOpisno = OcjenaOpisno;
            o.OcjenaBrojcano = OcjenaBrojcano;
            o.DatumUnosaOcjene = DatumUnosaOcjene;
            o.SlusaPredmetID = SlusaPredmetID;
            o.CasID = CasID;
            _context.SaveChanges();
            return RedirectToAction("Prikaz");
        }

        public ActionResult Obrisi(int OcjenaID)
        {
            Ocjena o = _context.Ocjena.Find(OcjenaID);
            _context.Ocjena.Remove(o);
            _context.SaveChanges();
            return RedirectToAction("Prikaz");
        }
    }
}