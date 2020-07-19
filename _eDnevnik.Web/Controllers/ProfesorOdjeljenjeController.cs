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
    public class ProfesorOdjeljenjeController : Controller
    {
        private MyDbContext _context;
        public ProfesorOdjeljenjeController(MyDbContext context)
        {
            _context = context;
        }
                
        public ActionResult Prikaz()
        {
            Login korisnik = HttpContext.GetLogiraniKorisnik();//<-- dodao
            if (korisnik == null)
            {
                //ViewData["error_poruka"] = "Niste logirani";//view data se nakon redirecta prazni pa se poruka nece ispisati
                TempData["error_poruka"] = "Niste logirani";//zato koristimo TempData
                return RedirectToAction("Index", "Autentifikacija");
                //return Unauthorized();
            }

            PrikazOdjeljenjaVM ulazniPodaci = new PrikazOdjeljenjaVM
            {
                ListaOdjeljenja = _context.Odjeljenje.Select(
                    o => new PrikazOdjeljenjaVM.Rows
                    {
                        OdjeljenjeID = o.ID,
                        Razred = o.Razred,
                        Oznaka = o.Oznaka,
                        PrebacenUViseOdjeljenje = o.PrebacenUViseOdjeljenje,
                        SkolskaGodina = o.SkolskaGodina.Naziv,
                        Razrednik = o.Razrednik.Ime + " " + o.Razrednik.Prezime,
                        Smjer=o.Smjer.Naziv+"/"+o.Smjer.Oznaka
                    }
                ).ToList()
            };
            return View(ulazniPodaci);
        }

       

        

        public ActionResult Obrisi(int OdjeljenjeID)
        {
            Odjeljenje o = _context.Odjeljenje.Find(OdjeljenjeID);

            if (o.RazrednikID != _context.Profesor.Where(x => x.ID == HttpContext.GetLogiraniKorisnik().ID).Select(s => s.ID).Single())
            {
                TempData["error_poruka"] = "Nemate pravo pristurpa";
                return RedirectToAction("Index", "Autentifikacija");
            }//Provjera da li je prof obrisao svoj razred

            _context.Odjeljenje.Remove(o);
            _context.SaveChanges();
            return RedirectToAction("Prikaz");
        }

        public ActionResult Detalji(int OdjeljenjeID)
        {
            Odjeljenje o = _context.Odjeljenje.Where(o=>o.ID==OdjeljenjeID).Include("Razrednik").Include("SkolskaGodina").Include("Smjer").First();
            OdjeljenjeDetaljiVM ulazniPodaci = new OdjeljenjeDetaljiVM { 
                OdjeljenjeID=o.ID,
                PrebacenUViseOdjeljenje=false,
                Oznaka=o.Oznaka,
                Razred=o.Razred,
                Razrednik=o.Razrednik.Ime+" "+o.Razrednik.Prezime,
                SkolskaGodina=o.SkolskaGodina.Naziv,
                Smjer=o.Smjer.Naziv
            };
            return View(ulazniPodaci);
        }

        public ActionResult PrikazUcenika(int OdjeljenjeID)
        {
            OdjeljenjePrikazUcenikaVM ulazniPodaci = new OdjeljenjePrikazUcenikaVM{
                OdjeljenjeID=OdjeljenjeID,
                ListaUcenika=_context.OdjeljenjeUcenik.Where(ou=>ou.OdjeljenjeID==OdjeljenjeID).Select(
                        ou=>new OdjeljenjePrikazUcenikaVM.Rows
                        {
                            OdjeljenjeUcenikID=ou.ID,
                            ImePrezime=ou.Ucenik.Ime+" "+ou.Ucenik.Prezime,
                            BrojUDnevniku=ou.BrojUDnevniku,
                            JMBG=ou.Ucenik.JMBG,
                            ImeRoditelja=ou.Ucenik.Roditelj.Ime+" "+ou.Ucenik.Roditelj.Prezime
                        }
                    ).ToList()
            };
            return PartialView(ulazniPodaci);
        }

       

       

       
    }
}