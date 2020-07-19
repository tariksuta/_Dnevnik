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
    [Autorizacija(roditelj: false, profesor: false, administrator: true)]
    public class PredajeController : Controller
    {
        private MyDbContext _context;
        public PredajeController(MyDbContext context)
        {
            _context = context;
        }

        public ActionResult Prikaz()
        {
            PredajePrikazVM ulazniPodaci = new PredajePrikazVM
            {
                ListaPredaje = _context.Predaje.Select(
                    o => new PredajePrikazVM.Rows
                    {
                        PredajeID = o.ID,
                        Predmet = o.Predmet.Naziv+" ("+ o.Predmet.Razred + ")",
                        Profesor = o.Profesor.Ime + " " + o.Profesor.Prezime,
                        Odjeljenje = o.Odjeljenje.Oznaka + " (" + o.Odjeljenje.Razred + ")",
                    }
                ).ToList()
            };
            return View(ulazniPodaci);
        }

        public ActionResult DodajUredi(int PredajeID)
        {
            PredajeDodajUrediVM ulazniPodaci = new PredajeDodajUrediVM();
            if (PredajeID != 0)
            {
                Predaje p = _context.Predaje.Find(PredajeID);
                ulazniPodaci.PredajeID = p.ID;
                ulazniPodaci.PredmetID = p.PredmetID;
                ulazniPodaci.ProfesorID = p.ProfesorID;
                ulazniPodaci.OdjeljenjeID = p.OdjeljenjeID;
            }

            pripremiCmbStavke(ulazniPodaci);
            return View(ulazniPodaci);
        }

        private void pripremiCmbStavke(PredajeDodajUrediVM ulazniPodaci) {
            ulazniPodaci.Predmeti = _context.Predmet.Select(s => new SelectListItem
            {
                Value = s.ID.ToString(),
                Text = s.Naziv + " (" + s.Razred + ")"
            }).ToList();

            ulazniPodaci.Profesori = _context.Profesor.Select(s => new SelectListItem
            {
                Value = s.ID.ToString(),
                Text = s.Ime + " " + s.Prezime
            }).ToList();

            ulazniPodaci.Odjeljenja = _context.Odjeljenje.Select(s => new SelectListItem
            {
                Value = s.ID.ToString(),
                Text = s.Oznaka + " (" + s.Razred + ")",
            }).ToList();
        }

        public ActionResult Snimi(PredajeDodajUrediVM input)
        {
            if (!ModelState.IsValid)
            {
                pripremiCmbStavke(input);
                return View("DodajUredi", input);
            }


            //-----------------------------------------------------
            Odjeljenje odjeljenje = _context.Odjeljenje.Where(o => o.ID == input.OdjeljenjeID).FirstOrDefault();
            Predmet predmet = _context.Predmet.Where(o => o.ID == input.PredmetID).FirstOrDefault();

            if (odjeljenje.Razred != predmet.Razred)
            {
                pripremiCmbStavke(input);
                TempData["greskaPoruka"] = "Predmet nije predviđen za odabrano odjeljenje!";
                return View("DodajUredi", input);
            }

            Predaje predaje = _context.Predaje.Where(o => o.PredmetID == input.PredmetID && o.OdjeljenjeID == input.OdjeljenjeID).FirstOrDefault();

            if (predaje != null && predaje.ID != input.PredajeID)
            {
                pripremiCmbStavke(input);
                TempData["greskaPoruka"] = "Nije moguće dodati predmet više puta!";
                return View("DodajUredi", input);
            }
            //-----------------------------------------------------

            Predaje o;
            if (input.PredajeID == 0)
            {
                o = new Predaje();
                _context.Add(o);
            }
            else
            {
                o = _context.Predaje.Find(input.PredajeID);
            }

            o.PredmetID = input.PredmetID;
            o.ProfesorID = input.ProfesorID;
            o.OdjeljenjeID = input.OdjeljenjeID;
            _context.SaveChanges();
            return RedirectToAction("Prikaz");
        }

        public ActionResult Obrisi(int PredajeID)
        {
            try
            {
                Predaje o = _context.Predaje.Find(PredajeID);
            _context.Predaje.Remove(o);
            _context.SaveChanges();
            }
            catch (Exception)
            {
                TempData["greskaPoruka"] = "Nemoguće obrisati!";
            }

            return RedirectToAction("Prikaz");
        }
    }
}