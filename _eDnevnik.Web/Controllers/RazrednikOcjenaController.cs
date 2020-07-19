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

    public class RazrednikOcjenaController : Controller
    {
        private MyDbContext _context;
        public RazrednikOcjenaController(MyDbContext context)
        {
            _context = context;
        }

        public ActionResult Prikaz()
        {
            int id = _context.Profesor.Where(x => x.LoginID == HttpContext.GetLogiraniKorisnik().ID).FirstOrDefault().ID;
            int oid = _context.Odjeljenje.Where(x => x.RazrednikID == id).FirstOrDefault().ID;
            OcjenaPrikazVM ulazniPodaci = new OcjenaPrikazVM
            {
                ListaOcjena = _context.Ocjena.Where(x => x.SlusaPredmet.OdjeljenjeUcenik.OdjeljenjeID == oid).Select(
                    o => new OcjenaPrikazVM.Rows
                    {
                        OcjenaID = o.ID,
                        OcjenaOpisno = o.OcjenaOpisno,
                        OcjenaBrojcano = o.OcjenaBrojcano,
                        DatumUnosaOcjene = o.DatumUnosaOcjene.ToShortDateString(),
                        SlusaPredmet =  o.SlusaPredmet.OdjeljenjeUcenik.BrojUDnevniku.ToString() ,
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

        public ActionResult Snimi(OcjenaDodajUrediVM x)
        {
            Ocjena o;
            if (x.OcjenaID == 0)
            {
                o = new Ocjena();
                _context.Add(o);
            }
            else
            {
                o = _context.Ocjena.Find(x.OcjenaID);
            }
            o.OcjenaOpisno = x.OcjenaOpisno;
            o.OcjenaBrojcano = x.OcjenaBrojcano;
            o.DatumUnosaOcjene = x.DatumUnosOcjene;
            o.SlusaPredmetID = x.SlusaPredmetID;
            o.CasID = x.CasID;
            _context.SaveChanges();
            return RedirectToAction("Prikaz");
        }




    }
}