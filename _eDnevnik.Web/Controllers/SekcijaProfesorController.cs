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

    public class SekcijaProfesorController : Controller
    {
        private MyDbContext _context;

        public SekcijaProfesorController(MyDbContext db)
        {
            _context = db;
        }
        public IActionResult PrikazSekcija()
        {
            SekcijaPrikazSekcijaVM Model = new SekcijaPrikazSekcijaVM
            {
                sekcije = _context.Sekcija.Select(x => new SekcijaPrikazSekcijaVM.Row
                {
                    SekcijaID = x.ID,
                    Napomena = x.Napomena,
                    Naziv = x.Naziv,
                    Koordinator = x.Koordinator.Ime + " " + x.Koordinator.Prezime
                }).ToList()
            };
            return View(Model);
        }
        public IActionResult DodajUrediSekciju(int SekcijaID)
        {
            SekcijaDodajUrediVM ulazniPodaci = new SekcijaDodajUrediVM();
            if (SekcijaID != 0)
            { 
                Sekcija s = _context.Sekcija.Find(SekcijaID);
                ulazniPodaci.SekcijaID =  s.ID;
                ulazniPodaci.Naziv =  s.Naziv;
                ulazniPodaci.Napomena =  s.Napomena;
                ulazniPodaci.KoordinatorID =  s.KoordinatorID;
            }

            pripremiCmbStavke(ulazniPodaci);
            return View(ulazniPodaci);
        }

        private void pripremiCmbStavke(SekcijaDodajUrediVM ulazniPodaci) {
            ulazniPodaci.koordinatori = _context.Profesor.Select(x => new SelectListItem
            {
                Value = x.ID.ToString(),
                Text = x.Ime + " " + x.Prezime
            }).ToList();
        }

        public IActionResult SnimiSekciju(SekcijaDodajUrediVM input)
        {
            if (!ModelState.IsValid)
            {
                pripremiCmbStavke(input);
                return View("DodajUrediSekciju", input);
            }

            Sekcija s;
            if(input.SekcijaID == 0)
            {
                s = new Sekcija();
                _context.Add(s);
            }
            else
            {
                s = _context.Sekcija.Find(input.SekcijaID);
            }
            s.Napomena = input.Napomena;
            s.Naziv = input.Naziv;
            s.KoordinatorID = input.KoordinatorID;
            _context.SaveChanges();
            return Redirect("/Sekcija/PrikazSekcija"); // trenutno kad se snimi prebacuje na prikaz sekcija za određenog profesora
            //return Redirect("/Sekcija/Prikaz?ProfesorID="+ s.KoordinatorID); // trenutno kad se snimi prebacuje na prikaz sekcija za određenog profesora
        }
        public IActionResult Prikaz(int ProfesorID)
        {
            SekcijaPrikazVM Model = new SekcijaPrikazVM();
            Model.sekcije = _context.Sekcija.Where(n=> n.KoordinatorID == ProfesorID).Select(x => new SekcijaPrikazVM.Row
            {
                SekcijaID = x.ID,
                Napomena = x.Napomena,
                Naziv = x.Naziv,
                Profesor = x.Koordinator.Ime + " " + x.Koordinator.Prezime
            }).ToList();

            return View(Model);
        }
       
        public IActionResult DodajUredi(int SekcijaID,int UcenikSekcijaID)
        {
            SekcijaUcenikDodajUrediVM Model = new SekcijaUcenikDodajUrediVM();
            UcenikSekcije us;
            if(UcenikSekcijaID == 0)
            {
                us = new UcenikSekcije();

                Model.SekcijaID = SekcijaID;
                Model.DatumUclanjenja = DateTime.Now;
                Model.ucenici = _context.Ucenik.Select(u => new SelectListItem
                {
                    Value = u.ID.ToString(),
                    Text = u.Ime + " " + u.Prezime
                }).ToList();
            }
            else
            {
                us = _context.UcenikSekcije.Find(UcenikSekcijaID);

                Model = new SekcijaUcenikDodajUrediVM
                {
                    UcenikSekcijaID = us.ID,
                    SekcijaID = us.SekcijaID,
                    UcenikID = us.UcenikID,
                    DatumUclanjenja = us.DatumUclanjenja,
                    ucenici = _context.UcenikSekcije.Where(l => l.SekcijaID == SekcijaID).Select(y => new SelectListItem
                    {
                        Value = y.UcenikID.ToString(),
                        Text = y.Ucenik.Ime + " " + y.Ucenik.Prezime

                    }).ToList()



                };
            }

            
    
            return PartialView(Model);
        }

        public IActionResult ObrisiUcenikSekcija(int UcenikSekcijaID)
        {

            UcenikSekcije us = _context.UcenikSekcije.Find(UcenikSekcijaID);
            int sID = us.SekcijaID;
            _context.Remove(us);
            _context.SaveChanges();

            return Redirect("/Sekcija/Detalji?SekcijaID=" + sID);
        }

        public IActionResult Obrisi(int SekcijaID)
        {
            try
            {
                Sekcija s = _context.Sekcija.Find(SekcijaID);
                _context.Remove(s);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                TempData["greskaPoruka"] = "Nemoguće obrisati sekciju!";
            }

            return RedirectToAction("PrikazSekcija");
        }


        public IActionResult Snimi(SekcijaUcenikDodajUrediVM x) // pogledati ovo i dovrsiti sto nema
        {
            UcenikSekcije us;
            if(x.UcenikSekcijaID == 0)
            {
                us = new UcenikSekcije();
                _context.Add(us);
            }
            else
            {
                us = _context.UcenikSekcije.Find(x.UcenikSekcijaID);

            }

            us.SekcijaID = x.SekcijaID;
            us.UcenikID = x.UcenikID;
            us.DatumUclanjenja = x.DatumUclanjenja;
            _context.SaveChanges();
            return Redirect("/Sekcija/Detalji?SekcijaID=" + us.SekcijaID); // nece redirekcija
        }
        public IActionResult UceniciPoSekcijama(int SekcijaID)
        {
            SekcijaUceniciPoSekcijamaVM Model = new SekcijaUceniciPoSekcijamaVM();
            Model.SekcijaID = SekcijaID;
            Model.ucenici = _context.UcenikSekcije.Where(x => x.SekcijaID == SekcijaID).Select(l => new SekcijaUceniciPoSekcijamaVM.Row
            {
                UcenikSekcijaID = l.ID,
                UcenikID = l.UcenikID,
                DatumUclanjenja = l.DatumUclanjenja.ToShortDateString(),
                Ime = l.Ucenik.Ime,
                Prezime = l.Ucenik.Prezime,
                Razred = _context.OdjeljenjeUcenik.Where(n => n.UcenikID == l.UcenikID).FirstOrDefault().Odjeljenje.Razred
            }).ToList();

            return PartialView(Model);
        }
        public IActionResult Detalji(int SekcijaID)
        {
            Sekcija s = _context.Sekcija.Where(x => x.ID == SekcijaID).Include(l => l.Koordinator).FirstOrDefault();
            SekcijaDetaljiVM Model = new SekcijaDetaljiVM
            {
                SekcijaID = s.ID,
                Naziv = s.Naziv,
                Koordinator = s.Koordinator.Ime + " " + s.Koordinator.Prezime
            };
            return View(Model);
        }
    }
}