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
    [Autorizacija(roditelj: true, profesor: false, administrator: false)]

    public class SekcijaRoditeljController : Controller
    {
        private MyDbContext _context;

        public SekcijaRoditeljController(MyDbContext db)
        {
            _context = db;
        }

        public IActionResult Prikaz()
        {
            try
            {
                Roditelj roditelj = _context.Roditelj.Where(r => r.LoginID == HttpContext.GetLogiraniKorisnik().ID).FirstOrDefault();

                Ucenik ucenik = _context.Ucenik.Where(u => u.RoditeljID == roditelj.ID).FirstOrDefault();
                if (ucenik == null)
                {
                    return View(null);
                }

                List<UcenikSekcije> ucenikSekcije = _context.UcenikSekcije.Where(u => u.UcenikID == ucenik.ID).ToList();

                SekcijaRoditeljPrikazVM ulazniPodaci = new SekcijaRoditeljPrikazVM
                {
                    ListaSekcija = _context.Sekcija.Select(
                         o => new SekcijaRoditeljPrikazVM.Rows
                         {

                             SekcijaID = o.ID,
                             Naziv = o.Naziv,
                             Napomena = o.Napomena,
                             Profesor = o.Koordinator.Ime + " " + o.Koordinator.Prezime,
                             Uclanjen = "Ne"
                         }
                     ).ToList()
                };

                foreach (UcenikSekcije us in ucenikSekcije)
                {
                    foreach (SekcijaRoditeljPrikazVM.Rows row in ulazniPodaci.ListaSekcija)
                    {

                        if (row.SekcijaID == us.SekcijaID)
                        {
                            row.Uclanjen = "Da";
                        }
                    }
                }

                return View(ulazniPodaci);
            }
            catch (Exception)
            {
                // EmailController.SendEmail(tehnicka.podrska@gmail.com, "Roditelj - SekcijaRoditelj - eDnevnik", "Problem s prikazom sekcija!");//Izmisljen mail
                return RedirectToAction("Index", "Home");
            }
        }
    }
}