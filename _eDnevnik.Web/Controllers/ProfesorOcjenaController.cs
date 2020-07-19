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

    public class ProfesorOcjenaController : Controller
    {
        private MyDbContext _context;
        public ProfesorOcjenaController(MyDbContext context)
        {
            _context = context;
        }

        public ActionResult Prikaz()
        {
            int id = _context.Profesor.Where(x => x.LoginID == HttpContext.GetLogiraniKorisnik().ID).FirstOrDefault().ID;
            OcjenaPrikazVM ulazniPodaci = new OcjenaPrikazVM
            {
                ListaOcjena = _context.Ocjena.Where(x => x.Cas.Predaje.ProfesorID == id).Select(
                    o => new OcjenaPrikazVM.Rows
                    {
                        OcjenaID = o.ID,
                        OcjenaOpisno = o.OcjenaOpisno,
                        OcjenaBrojcano = o.OcjenaBrojcano,
                        DatumUnosaOcjene = o.DatumUnosaOcjene.ToShortDateString(),
                        SlusaPredmet = "Odj. " + o.SlusaPredmet.OdjeljenjeUcenik.Odjeljenje.Oznaka+" (" + o.SlusaPredmet.OdjeljenjeUcenik.Odjeljenje.Razred + ")  - " + o.SlusaPredmet.OdjeljenjeUcenik.Ucenik.Ime + 
                        " " + o.SlusaPredmet.OdjeljenjeUcenik.Ucenik.Prezime + "(br." + o.SlusaPredmet.OdjeljenjeUcenik.BrojUDnevniku+")", 
                        Cas = o.Cas.BrojCasa + " " + o.Cas.Predaje.Predmet.Naziv
                    }
                ).ToList()
            };
            return View(ulazniPodaci);
        }

        public ActionResult DodajUredi(int OcjenaID)
        {
            OcjenaDodajUrediVM ulazniPodaci;
            Ocjena o;
            if (OcjenaID == 0)
            {
                ulazniPodaci = new OcjenaDodajUrediVM();
            }
            else
            {
                 o = _context.Ocjena.Find(OcjenaID);
                ulazniPodaci = new OcjenaDodajUrediVM
                {
                    OcjenaID = o.ID,
                    CasID = o.CasID,
                    OcjenaOpisno = o.OcjenaOpisno,
                    OcjenaBrojcano = o.OcjenaBrojcano,
                    DatumUnosOcjene = o.DatumUnosaOcjene,
                    SlusaPredmetID = o.SlusaPredmetID
                };
            }

            ulazniPodaci.SlusaPredmet = _context.SlusaPredmet.Select(s => new SelectListItem
            {
                Value = s.ID.ToString(),
                Text = "Odj. " + s.OdjeljenjeUcenik.Odjeljenje.Oznaka + " (" + s.OdjeljenjeUcenik.Odjeljenje.Razred + ")  - " + s.OdjeljenjeUcenik.Ucenik.Ime +
                        " " + s.OdjeljenjeUcenik.Ucenik.Prezime + "(br." + s.OdjeljenjeUcenik.BrojUDnevniku + ")"
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
        
        public IActionResult DodajOcjenuNaCas(int CasID)
        {

            try
            {
                Cas cas = _context.Cas.Where(o => o.ID == CasID).FirstOrDefault();
                int odjeljenjeID = _context.Predaje.Where(o => o.ID == cas.PredajeID).FirstOrDefault().OdjeljenjeID;

                DodajOcjenuNaCasVM Model = new DodajOcjenuNaCasVM
                {
                    CasID = CasID,
                    BrojCasa = _context.Cas.Where(x => x.ID == CasID).FirstOrDefault().BrojCasa,
                    Datum = _context.Cas.Where(x => x.ID == CasID).FirstOrDefault().DatumOdrzavanja,

                    slusapredmet = _context.SlusaPredmet.Where(o => o.OdjeljenjeUcenik.OdjeljenjeID == odjeljenjeID && o.PredajeID == cas.PredajeID).Select(x => new SelectListItem
                    {
                        Value = x.ID.ToString(),
                        Text = "Odj. " + x.OdjeljenjeUcenik.Odjeljenje.Oznaka + " (" + x.OdjeljenjeUcenik.Odjeljenje.Razred + ")  - " + x.OdjeljenjeUcenik.Ucenik.Ime +
                              " " + x.OdjeljenjeUcenik.Ucenik.Prezime + "(br." + x.OdjeljenjeUcenik.BrojUDnevniku + ")"
                    }).ToList(),
                };
                return View(Model);
            }
            catch (Exception)
            {
                return Redirect("/ProfesorCas/Prikaz");
            }
           
        }
        private void pripremiCmbStavke(DodajOcjenuNaCasVM ulazniPodaci)
        {
            Cas cas = _context.Cas.Where(o => o.ID == ulazniPodaci.CasID).FirstOrDefault();
            int odjeljenjeID = _context.Predaje.Where(o => o.ID == cas.PredajeID).FirstOrDefault().OdjeljenjeID;

            ulazniPodaci.slusapredmet = _context.SlusaPredmet.Where(o => o.OdjeljenjeUcenik.OdjeljenjeID == odjeljenjeID && o.PredajeID == cas.PredajeID).Select(x => new SelectListItem
            {
                Value = x.ID.ToString(),
                Text = "Odj. " + x.OdjeljenjeUcenik.Odjeljenje.Oznaka + " (" + x.OdjeljenjeUcenik.Odjeljenje.Razred + ")  - " + x.OdjeljenjeUcenik.Ucenik.Ime +
                         " " + x.OdjeljenjeUcenik.Ucenik.Prezime + "(br." + x.OdjeljenjeUcenik.BrojUDnevniku + ")"
            }).ToList();


        }
        [HttpPost]
        [ValidateAntiForgeryToken()]
        public IActionResult OcjenaSnimi(DodajOcjenuNaCasVM x)
        {
            if (!ModelState.IsValid)
            {
                pripremiCmbStavke(x);
                return View("DodajOcjenuNaCas", x);
            }

            Izostanak izostanak = _context.Izostanak.Where(k => k.CasID == x.CasID && k.SlusaPredmetID == x.SlusaPredmetID).FirstOrDefault();
            if (izostanak != null)
            {
                pripremiCmbStavke(x);
                TempData["greskaPoruka"] = "Ucenik ne prisustvuje nastavi!";
                return View("DodajOcjenuNaCas", x);
            }
            Ocjena o = new Ocjena
            {
                CasID = x.CasID,
                SlusaPredmetID = x.SlusaPredmetID,
                OcjenaBrojcano = x.OcjenaBrojcano,
                OcjenaOpisno = x.OcjenaOpisno,
                DatumUnosaOcjene = x.Datum
            };
            _context.Ocjena.Add(o);
            _context.SaveChanges();
            return Redirect("/ProfesorCas/Prikaz");
        }
    }
}