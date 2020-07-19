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
    public class ProfesorSlusaPredmetController : Controller
    {
        private MyDbContext _context;
        public ProfesorSlusaPredmetController(MyDbContext context)
        {
            _context = context;
        }

        public ActionResult Prikaz()
        {
            Profesor p = _context.Profesor.Where(x => x.LoginID == HttpContext.GetLogiraniKorisnik().ID).FirstOrDefault();

            if (p == null)
                return Redirect("/Home/Index");

            SlusaPredmetPrikazVM ulazniPodaci = new SlusaPredmetPrikazVM
            {
                ListaSlusaPredmet = _context.SlusaPredmet.Where(x=> x.OdjeljenjeUcenik.Odjeljenje.RazrednikID == p.ID).Select(
                    o => new SlusaPredmetPrikazVM.Rows
                    {
                        SlusaPredmetID = o.ID,
                        OdjeljenjeUcenik = "Br." + o.OdjeljenjeUcenik.BrojUDnevniku + " Odj. " + o.OdjeljenjeUcenik.Odjeljenje.Oznaka,
                        Predaje = o.Predaje.Predmet.Naziv  + " - " + o.Predaje.Profesor.Ime +" " + o.Predaje.Profesor.Prezime,
                        ZakljucnaOcjenaNaPolugodistu = o.ZakljucnaOcjenaNaPolugodistu,
                        ZakljucnaOcjenaNaKraju = o.ZakljucnaOcjenaNaKraju
                    }
                ).ToList()
            };
            return View(ulazniPodaci);
        }

        public ActionResult DodajUredi(int SlusaPredmetID)
        {
            Profesor p = _context.Profesor.Where(x => x.LoginID == HttpContext.GetLogiraniKorisnik().ID).FirstOrDefault();
            ProfesorSlusaPredmetDodajUrediVM ulazniPodaci;
            SlusaPredmet sp;
            if (SlusaPredmetID == 0)
            {
                ulazniPodaci = new ProfesorSlusaPredmetDodajUrediVM();
            }
            else
            {
                sp = _context.SlusaPredmet.Find(SlusaPredmetID);
                ulazniPodaci = new ProfesorSlusaPredmetDodajUrediVM
                {
                    SlusaPredmetID = sp.ID,
                    PredajeID = sp.PredajeID,
                    OdjeljenjeUcenikID = sp.OdjeljenjeUcenikID,
                    ZakljucnaOcjenaNaKraju = sp.ZakljucnaOcjenaNaKraju,
                    ZakljucnaOcjenaNaPolugodistu = sp.ZakljucnaOcjenaNaPolugodistu
                };
            }

            ulazniPodaci.OdjeljenjeUcenik = _context.OdjeljenjeUcenik.Where(x => x.Odjeljenje.RazrednikID == p.ID).Select(s => new SelectListItem
            {
                Value = s.ID.ToString(),
                Text = "Br." + s.BrojUDnevniku + " Odj. " + s.Odjeljenje.Oznaka
            }).ToList();

            ulazniPodaci.Predaje = _context.Predaje.Where(x => x.ProfesorID == p.ID).Select(s => new SelectListItem
            {
                Value = s.ID.ToString(),
                Text = s.Predmet.Naziv + " - " + s.Profesor.Ime + " " + s.Profesor.Prezime
            }).ToList();

            return View(ulazniPodaci);
        }
        private void pripremiCmbStavke(ProfesorSlusaPredmetDodajUrediVM ulazniPodaci)
        {
            Profesor p = _context.Profesor.Where(x => x.LoginID == HttpContext.GetLogiraniKorisnik().ID).FirstOrDefault();
            ulazniPodaci.OdjeljenjeUcenik = _context.OdjeljenjeUcenik.Where(x => x.Odjeljenje.RazrednikID == p.ID).Select(s => new SelectListItem
            {
                Value = s.ID.ToString(),
                Text = "Odj. " + s.Odjeljenje.Oznaka + " (" + s.Odjeljenje.Razred + ") - " + "br. " + s.BrojUDnevniku
            }).ToList();

            ulazniPodaci.Predaje = _context.Predaje.Where(x => x.ProfesorID == p.ID).Select(s => new SelectListItem
            {
                Value = s.ID.ToString(),
                Text = s.Predmet.Naziv + " (" + s.Predmet.Razred + ")" + " - " + s.Profesor.Ime + " " + s.Profesor.Prezime
            }).ToList();
        }

        public ActionResult Snimi(ProfesorSlusaPredmetDodajUrediVM x)
        {
            if (!ModelState.IsValid)
            {
                pripremiCmbStavke(x);
                return View("DodajUredi", x);
            }

            //----------------------------------------------------


            OdjeljenjeUcenik odjeljenjeUcenik = _context.OdjeljenjeUcenik.Where(o => o.ID == x.OdjeljenjeUcenikID).FirstOrDefault();
            Predaje predaje = _context.Predaje.Where(o => o.ID == x.PredajeID).FirstOrDefault();

            if (odjeljenjeUcenik.OdjeljenjeID != predaje.OdjeljenjeID)
            {
                pripremiCmbStavke(x);
                TempData["greskaPoruka"] = "Predmet nije predviđen za odabrano odjeljenje!";
                return View("DodajUredi", x);
            }

            SlusaPredmet slusaPredmet = _context.SlusaPredmet.Where(o => o.OdjeljenjeUcenikID == x.OdjeljenjeUcenikID && o.PredajeID == x.PredajeID).FirstOrDefault();

            if (slusaPredmet != null && slusaPredmet.ID != x.SlusaPredmetID)
            {
                pripremiCmbStavke(x);
                TempData["greskaPoruka"] = "Nije moguće dodati predmet istom učeniku više puta!";
                return View("DodajUredi", x);
            }
            //----------------------------------------------------
            SlusaPredmet o;
            if (x.SlusaPredmetID == 0)
            {
                o = new SlusaPredmet();
                _context.Add(o);
            }
            else
            {
                o = _context.SlusaPredmet.Find(x.SlusaPredmetID);
            }
            o.PredajeID = x.PredajeID;
            o.OdjeljenjeUcenikID = x.OdjeljenjeUcenikID;
            o.ZakljucnaOcjenaNaPolugodistu = x.ZakljucnaOcjenaNaPolugodistu;
            o.ZakljucnaOcjenaNaKraju = x.ZakljucnaOcjenaNaKraju;
            _context.SaveChanges();
            return RedirectToAction("Prikaz");
        }

        public ActionResult Obrisi(int SlusaPredmetID)
        {
            SlusaPredmet o = _context.SlusaPredmet.Find(SlusaPredmetID);
            _context.SlusaPredmet.Remove(o);
            _context.SaveChanges();
            return RedirectToAction("Prikaz");
        }
    }
}