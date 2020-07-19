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

    public class ProfesorCasController : Controller
    {
        private MyDbContext _context;

        public ProfesorCasController(MyDbContext db)
        {
            _context = db;
        }
        public IActionResult PrikazCasOdjeljenje(int ProfesorID,int OdjeljenjeID)
        {

            CasPrikazOdjeljenjeVM Model = new CasPrikazOdjeljenjeVM
            {
                casovi = _context.Cas.Where(x => x.Predaje.OdjeljenjeID == OdjeljenjeID && x.Predaje.ProfesorID == ProfesorID).Select(c => new CasPrikazOdjeljenjeVM.Row
                {
                    CasID = c.ID,
                    BrojCasa = c.BrojCasa,
                    NastavnaJedinica = c.NastavnaJedinica,

                    DatumOdrzavanja = c.DatumOdrzavanja.ToShortDateString(),
                    PredajeID = c.PredajeID,
                    Odjeljenje = _context.Odjeljenje.Find(OdjeljenjeID).Razred,
                    Profesor = _context.Profesor.Find(ProfesorID).Ime
                }).ToList()
            };
        
            return View();
        }

        public IActionResult Prikaz()
        {
            Profesor p = _context.Profesor.Where(x => x.LoginID == HttpContext.GetLogiraniKorisnik().ID).FirstOrDefault();
            CasPrikazVM Model = new CasPrikazVM
            {
                casovi = _context.Cas.Where(c => c.Predaje.ProfesorID == p.ID).Select(x => new CasPrikazVM.Row
                {
                    CasID = x.ID,
                    BrojCasa = x.BrojCasa,
                    NastavnaJedinica = x.NastavnaJedinica,
                    DatumOdrzavanja = x.DatumOdrzavanja.ToShortDateString(),
                    PredajeID = x.PredajeID,
                    Profesor = x.Predaje.Profesor.Ime + " " + x.Predaje.Profesor.Prezime,
                    Odjeljenje = x.Predaje.Odjeljenje.Razred + " " + x.Predaje.Odjeljenje.Oznaka,
                    Predmet = x.Predaje.Predmet.Naziv
                }).ToList()
            };
            return View(Model);
        }

        public IActionResult DodajUredi(int CasID)
        {
            Profesor p = _context.Profesor.Where(x => x.LoginID == HttpContext.GetLogiraniKorisnik().ID).FirstOrDefault();
            CasDodajUrediVM Model;
            Cas c;
            if (CasID == 0)
            {
                Model = new CasDodajUrediVM();
                Model.DatumOdrzavanja = DateTime.Now;

                Model.predaje = _context.Predaje.Where(x => x.ProfesorID == p.ID).Select(x => new SelectListItem
                {
                    Value = x.ID.ToString(),
                    Text = x.Predmet.Naziv + " | " + x.Odjeljenje.Razred + "-" + x.Odjeljenje.Oznaka + " | " + x.Profesor.Ime + " " + x.Profesor.Prezime
                }).ToList();

            }
            else
            {
                c = _context.Cas.Where(x => x.ID == CasID).Include(l => l.Predaje).FirstOrDefault();
                Model = new CasDodajUrediVM
                {
                    CasID = c.ID,
                    BrojCasa = c.BrojCasa,
                    NastavnaJedinica = c.NastavnaJedinica,
                    DatumOdrzavanja = c.DatumOdrzavanja,
                    PredajeID = c.PredajeID,
                    ProfesorID = c.Predaje.ProfesorID,
                    predaje = _context.Predaje.Where(x => x.ProfesorID == c.Predaje.ProfesorID).Select(l => new SelectListItem
                    {
                        Value = l.ID.ToString(),
                        Text = l.Predmet.Naziv + " | " + l.Odjeljenje.Razred + "-" + l.Odjeljenje.Oznaka + " | " + l.Profesor.Ime + " " + l.Profesor.Prezime
                    }).ToList()
                };
            }
            return View(Model);
        }
        private void pripremiCmbStavke(CasDodajUrediVM ulazniPodaci)
        {
            Cas c = _context.Cas.Include(x => x.Predaje).Where(x => x.BrojCasa == ulazniPodaci.BrojCasa).FirstOrDefault();
            ulazniPodaci.predaje = _context.Predaje.Where(x => x.ProfesorID == c.Predaje.ProfesorID).Select(l => new SelectListItem
            {
                Value = l.ID.ToString(),
                Text = l.Predmet.Naziv + " | " + l.Odjeljenje.Razred + "-" + l.Odjeljenje.Oznaka + " | " + l.Profesor.Ime + " " + l.Profesor.Prezime
            }).ToList();



        }
        public IActionResult Snimi( CasDodajUrediVM x)
        {

            if (!ModelState.IsValid)
            {
                pripremiCmbStavke(x);
                return View("DodajUredi", x);
            }

            Cas cas = _context.Cas.Where(k => k.BrojCasa == x.BrojCasa && k.PredajeID == x.PredajeID).FirstOrDefault();

            if (cas != null && cas.ID != x.CasID)
            {
                pripremiCmbStavke(x);
                TempData["greskaPoruka"] = $"Cas {x.BrojCasa} je vec održan!";
                return View("DodajUredi", x);
            }
            Cas c;
            if(x.CasID == 0)
            {
                c = new Cas();
                _context.Add(c);
            }
            else
            {
                c = _context.Cas.Find(x.CasID);

            }
            c.BrojCasa = _context.Cas.Count(n => n.PredajeID == x.PredajeID) + 1;
         
            c.NastavnaJedinica = x.NastavnaJedinica;
            c.DatumOdrzavanja = x.DatumOdrzavanja;
            c.PredajeID = x.PredajeID;
            _context.SaveChanges();
            return Redirect("/ProfesorCas/Prikaz");
        }

        public IActionResult Obrisi(int CasID)
        {
            Cas s = _context.Cas.Find(CasID);

            _context.Remove(s);
            _context.SaveChanges();
            return Redirect("/ProfesorCas/Prikaz");
        }
    }
}