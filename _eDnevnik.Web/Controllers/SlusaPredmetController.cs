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
    public class SlusaPredmetController : Controller
    {
        private MyDbContext _context;
        public SlusaPredmetController(MyDbContext context)
        {
            _context = context;
        }

        public ActionResult Prikaz()
        {
            SlusaPredmetPrikazVM ulazniPodaci = new SlusaPredmetPrikazVM
            {
                ListaSlusaPredmet = _context.SlusaPredmet.Select(
                    o => new SlusaPredmetPrikazVM.Rows
                    {
                        SlusaPredmetID = o.ID,
                        OdjeljenjeUcenik ="Odj. " + o.OdjeljenjeUcenik.Odjeljenje.Oznaka + " ("+ o.OdjeljenjeUcenik.Odjeljenje.Razred + ") - " + "br. " + o.OdjeljenjeUcenik.BrojUDnevniku,
                        Predaje = o.Predaje.Predmet.Naziv+" (" + o.Predaje.Predmet.Razred + ")"  + " - " + o.Predaje.Profesor.Ime +" " + o.Predaje.Profesor.Prezime,
                        ZakljucnaOcjenaNaPolugodistu = o.ZakljucnaOcjenaNaPolugodistu,
                        ZakljucnaOcjenaNaKraju = o.ZakljucnaOcjenaNaKraju
                    }
                ).ToList()
            };
            return View(ulazniPodaci);
        }

        public ActionResult DodajUredi(int SlusaPredmetID)
        {
            SlusaPredmetDodajUrediVM ulazniPodaci = new SlusaPredmetDodajUrediVM();
            if (SlusaPredmetID != 0)
            {
              SlusaPredmet sp = _context.SlusaPredmet.Find(SlusaPredmetID);
                ulazniPodaci.SlusaPredmetID = sp.ID;
                ulazniPodaci.OdjeljenjeUcenikID = sp.OdjeljenjeUcenikID;
                ulazniPodaci.PredajeID = sp.PredajeID;
                ulazniPodaci.ZakljucnaOcjenaNaPolugodistu = sp.ZakljucnaOcjenaNaPolugodistu;
                ulazniPodaci.ZakljucnaOcjenaNaKraju = sp.ZakljucnaOcjenaNaKraju;
            }

            pripremiCmbStavke(ulazniPodaci);
            return View(ulazniPodaci);
        }

        private void pripremiCmbStavke(SlusaPredmetDodajUrediVM ulazniPodaci) {
            ulazniPodaci.OdjeljenjeUcenik = _context.OdjeljenjeUcenik.Select(s => new SelectListItem
            {
                Value = s.ID.ToString(),
                Text = "Odj. " + s.Odjeljenje.Oznaka + " (" + s.Odjeljenje.Razred + ") - " + "br. " + s.BrojUDnevniku
            }).ToList();

            ulazniPodaci.Predaje = _context.Predaje.Select(s => new SelectListItem
            {
                Value = s.ID.ToString(),
                Text = s.Predmet.Naziv + " (" + s.Predmet.Razred + ")" + " - " + s.Profesor.Ime + " " + s.Profesor.Prezime
            }).ToList();
        }


        [HttpPost]
        [ValidateAntiForgeryToken()]
        public ActionResult Snimi(SlusaPredmetDodajUrediVM input)
        {
            if (!ModelState.IsValid)
            {
                pripremiCmbStavke(input);
                return View("DodajUredi", input);
            }

            //----------------------------------------------------


            OdjeljenjeUcenik odjeljenjeUcenik = _context.OdjeljenjeUcenik.Where(o => o.ID == input.OdjeljenjeUcenikID).FirstOrDefault();
            Predaje predaje = _context.Predaje.Where(o => o.ID == input.PredajeID).FirstOrDefault();
         
            if (odjeljenjeUcenik.OdjeljenjeID != predaje.OdjeljenjeID)
            {
                pripremiCmbStavke(input);
                TempData["greskaPoruka"] = "Predmet nije predviđen za odabrano odjeljenje!";
                return View("DodajUredi", input);
            }


            SlusaPredmet slusaPredmet = _context.SlusaPredmet.Where(o => o.OdjeljenjeUcenikID == input.OdjeljenjeUcenikID && o.PredajeID == input.PredajeID).FirstOrDefault();

            if (slusaPredmet != null && slusaPredmet.ID != input.SlusaPredmetID)
            {
                pripremiCmbStavke(input);
                TempData["greskaPoruka"] = "Nije moguće dodati predmet istom učeniku više puta!";
                return View("DodajUredi", input);
            }
            //----------------------------------------------------

            SlusaPredmet o;
            if (input.SlusaPredmetID == 0)
            {
                o = new SlusaPredmet();
                _context.Add(o);
            }
            else
            {
                o = _context.SlusaPredmet.Find(input.SlusaPredmetID);
            }
            o.PredajeID = input.PredajeID;
            o.OdjeljenjeUcenikID = input.OdjeljenjeUcenikID;
            o.ZakljucnaOcjenaNaPolugodistu = input.ZakljucnaOcjenaNaPolugodistu;
            o.ZakljucnaOcjenaNaKraju = input.ZakljucnaOcjenaNaKraju;
            _context.SaveChanges();
            return RedirectToAction("Prikaz");
        }

        public ActionResult Obrisi(int SlusaPredmetID)
        {
            try
            {
                SlusaPredmet o = _context.SlusaPredmet.Find(SlusaPredmetID);
                _context.SlusaPredmet.Remove(o);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                TempData["greskaPoruka"] = "Nemoguće obrisati !";
            }

            return RedirectToAction("Prikaz");
        }
    }
}