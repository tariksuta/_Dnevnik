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

    public class ProfesorIzostanakController : Controller
    {
        private MyDbContext _context;
        public ProfesorIzostanakController(MyDbContext context)
        {
            _context = context;
        }

        public ActionResult Prikaz()
        {
            int id = _context.Profesor.Where(x => x.LoginID == HttpContext.GetLogiraniKorisnik().ID).FirstOrDefault().ID;
            IzostanakPrikazVM ulazniPodaci = new IzostanakPrikazVM
            {
                ListaIzostanaka = _context.Izostanak.Where(x => x.Cas.Predaje.ProfesorID == id).Select(
                    o => new IzostanakPrikazVM.Rows
                    {
                        IzostanakID = o.ID,
                        Napomena = o.Napomena,
                        DatumIzostanka = o.DatumIzostanka.ToShortDateString(),
                        Opravdan = o.Opravdan,
                        SlusaPredmet = "Odj. " + o.SlusaPredmet.OdjeljenjeUcenik.Odjeljenje.Oznaka + " (" + o.SlusaPredmet.OdjeljenjeUcenik.Odjeljenje.Razred + ")  - " + o.SlusaPredmet.OdjeljenjeUcenik.Ucenik.Ime +
                        " " + o.SlusaPredmet.OdjeljenjeUcenik.Ucenik.Prezime + "(br." + o.SlusaPredmet.OdjeljenjeUcenik.BrojUDnevniku + ")",
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
                    CasID = i.CasID,
                    DatumIzostanka = i.DatumIzostanka,
                    SlusaPredmetID = i.SlusaPredmetID,
                    Napomena = i.Napomena,
                    
                };
            }

            ulazniPodaci.SlusaPredmet = _context.SlusaPredmet.Select(s => new SelectListItem
            {
                Value = s.ID.ToString(),
                Text = "Odj. " + s.OdjeljenjeUcenik.Odjeljenje.Oznaka + " (" + s.OdjeljenjeUcenik.Odjeljenje.Razred + ")  - " + s.OdjeljenjeUcenik.Ucenik.Ime +
                        " " + s.OdjeljenjeUcenik.Ucenik.Prezime + "(br." + s.OdjeljenjeUcenik.BrojUDnevniku + ")",
            }).ToList();

            ulazniPodaci.Cas = _context.Cas.Select(s => new SelectListItem
            {
                Value = s.ID.ToString(),
                Text = s.Predaje.Predmet.Naziv
            }).ToList();

            return View(ulazniPodaci);
        }
        [HttpPost]
        [ValidateAntiForgeryToken()]
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

        public ActionResult Obrisi(int IzostanakID)
        {
            Izostanak o = _context.Izostanak.Find(IzostanakID);
            _context.Izostanak.Remove(o);
            _context.SaveChanges();
            return RedirectToAction("Prikaz");
        }

        
        public IActionResult ProfesorDodajIzostanak(int CasID)
        {

           
                Cas cas = _context.Cas.Where(o => o.ID == CasID).FirstOrDefault();
                int odjeljenjeID = _context.Predaje.Where(o => o.ID == cas.PredajeID).FirstOrDefault().OdjeljenjeID;

                ProfesorDodajIzostanakVM Model = new ProfesorDodajIzostanakVM
                {
                    CasID = CasID,
                    Odrzavanja = _context.Cas.Where(x => x.ID == CasID).FirstOrDefault().DatumOdrzavanja,
                    BrojCasa = _context.Cas.Where(x => x.ID == CasID).FirstOrDefault().BrojCasa,

                    slusapredemt = _context.SlusaPredmet.Where(o => o.OdjeljenjeUcenik.OdjeljenjeID == odjeljenjeID && o.PredajeID == cas.PredajeID).Select(x => new SelectListItem
                    {
                        Value = x.ID.ToString(),
                        Text = "Odj. " + x.OdjeljenjeUcenik.Odjeljenje.Oznaka + " (" + x.OdjeljenjeUcenik.Odjeljenje.Razred + ")  - " + x.OdjeljenjeUcenik.Ucenik.Ime +
                              " " + x.OdjeljenjeUcenik.Ucenik.Prezime + "(br." + x.OdjeljenjeUcenik.BrojUDnevniku + ")"
                    }).ToList(),
                };
                return View(Model);
            
           
          
        }
        private void pripremiCmbStavke(ProfesorDodajIzostanakVM ulazniPodaci)
        {
            Cas cas = _context.Cas.Where(o => o.ID == ulazniPodaci.CasID).FirstOrDefault();
            int odjeljenjeID = _context.Predaje.Where(o => o.ID == cas.PredajeID).FirstOrDefault().OdjeljenjeID;

            ulazniPodaci.slusapredemt = _context.SlusaPredmet.Where(o => o.OdjeljenjeUcenik.OdjeljenjeID == odjeljenjeID && o.PredajeID == cas.PredajeID).Select(x => new SelectListItem
            {
                Value = x.ID.ToString(),
                Text = "Odj. " + x.OdjeljenjeUcenik.Odjeljenje.Oznaka + " (" + x.OdjeljenjeUcenik.Odjeljenje.Razred + ")  - " + x.OdjeljenjeUcenik.Ucenik.Ime +
                          " " + x.OdjeljenjeUcenik.Ucenik.Prezime + "(br." + x.OdjeljenjeUcenik.BrojUDnevniku + ")"
            }).ToList();


        }

        [HttpPost]
        [ValidateAntiForgeryToken()]
        public ActionResult SnimiIzostanak(ProfesorDodajIzostanakVM x)
        {

            if (!ModelState.IsValid)
            {
                pripremiCmbStavke(x);
                return View("ProfesorDodajIzostanak", x);
            }

            //CMB RIJESITI
            Izostanak izostanak = _context.Izostanak.Where(k => k.CasID == x.CasID && k.SlusaPredmetID == x.SlusaPredmetID).FirstOrDefault();
            if (izostanak != null && izostanak.ID != x.IzostanakID)
            {
                pripremiCmbStavke(x);
                TempData["greskaPoruka"] = "Ucenik je vec napustio cas!";
                return View("ProfesorDodajIzostanak", x);
            }
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
            o.DatumIzostanka = x.Odrzavanja;
            o.Opravdan = false;
            o.SlusaPredmetID = x.SlusaPredmetID;
            o.CasID = x.CasID;
            _context.SaveChanges();

            int uid = _context.SlusaPredmet.Include(t => t.OdjeljenjeUcenik).Where(l => l.ID == x.SlusaPredmetID).FirstOrDefault().OdjeljenjeUcenik.UcenikID;
            Ucenik u = _context.Ucenik.Where(n => n.ID == uid).FirstOrDefault();
            Roditelj r = _context.Ucenik.Include(c => c.Roditelj).Where(e => e.ID == u.ID).FirstOrDefault().Roditelj;
            string poruka = u.Ime + " " + u.Prezime + " je izostao'\'la sa nastave";
            poruka += "Datum izostnka" + o.DatumIzostanka.ToShortDateString();
            poruka += "Napomena : " + o.Napomena;
            //string telefon = r.Telefon;
            string telefon = "38761434931";
            return RedirectToAction("PosaljiSMS", "SMS", new { to = telefon, text = poruka });

            //return Redirect("/ProfesorCas/Prikaz");
        }
    }
}