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

    public class ProfesorSekcijaController : Controller
    {
        private MyDbContext _context;

        public ProfesorSekcijaController(MyDbContext db)
        {
            _context = db;
        }
      
       

      
        public IActionResult Prikaz()
        {

            SelectListIndexVM Model = new SelectListIndexVM
            {
                

                sekcije = _context.Sekcija.Select(k => new SelectListItem
                {
                    Value = k.ID.ToString(),
                    Text = k.Naziv
                }).ToList()
            };
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

        public int ObrisiUcenikSekcija(int UcenikSekcijaID)
        {

            UcenikSekcije us = _context.UcenikSekcije.Find(UcenikSekcijaID);
            int sID = us.SekcijaID;
            _context.Remove(us);
            _context.SaveChanges();

            

            return sID;
        }
        public IActionResult Dodaj()
        {

            ProfesorSekcijaDodajVM Model = new ProfesorSekcijaDodajVM
            {
                sekcije = _context.Sekcija.Select(x => new SelectListItem
                {
                    Value = x.ID.ToString(),
                    Text = x.Naziv
                }).ToList(),
                odjeljenja = _context.Odjeljenje.Select(l => new SelectListItem
                {
                    Value = l.ID.ToString(),
                    Text = l.Oznaka
                }).ToList()
            };
            return View(Model);
        }
        public IActionResult SnimiUcenikaUSekciju(ProfesorSekcijaDodajVM x)
        {

            UcenikSekcije us = new UcenikSekcije
            {
                UcenikID = x.UcenikID,
                SekcijaID = x.SekcijaID,
                DatumUclanjenja = DateTime.Now
            };
            _context.UcenikSekcije.Add(us);
            _context.SaveChanges();
            return Redirect("/ProfesorSekcija/Dodaj");
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
            return Redirect("/ProfesorSekcija/Detalji?SekcijaID=" + us.SekcijaID); 
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