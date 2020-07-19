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
    public class RazrednikOdjeljenjeUcenikController : Controller
    {
        private MyDbContext _context;
        public RazrednikOdjeljenjeUcenikController(MyDbContext context)
        {
            _context = context;
        }

        public ActionResult Prikaz()
        {
            int id = _context.Profesor.Where(k => k.LoginID == HttpContext.GetLogiraniKorisnik().ID).FirstOrDefault().ID;
            RazrednikUceniciVM Model = new RazrednikUceniciVM
            {
                Odjeljenje = _context.Odjeljenje.Where(k => k.RazrednikID == id).FirstOrDefault().Oznaka,
                ucenici = _context.OdjeljenjeUcenik.Where(x => x.OdjeljenjeID == _context.Odjeljenje.Where(k => k.RazrednikID == id).FirstOrDefault().ID).Select(u => new RazrednikUceniciVM.Row
                {
                    UcenikOdjeljenjeID = u.ID,
                    BrojUDnevniku = u.BrojUDnevniku,
                    Ime = u.Ucenik.Ime,
                    Prezime = u.Ucenik.Prezime,
                    Spol = u.Ucenik.Spol,
                    JMBG = u.Ucenik.JMBG,
                    Vladanje = u.Ucenik.Vladanje.VladanjeOpisno,
                    Roditelj = u.Ucenik.Roditelj.Ime,
                    UcenikID = u.Ucenik.ID
                }).ToList()
            };
            return View(Model);
        }
        
        public ActionResult DodajUredi(int UcenikID)
        {
            RazrednikUcenikDodajUrediVM ulazniPodaci = new RazrednikUcenikDodajUrediVM();
            if (UcenikID == 0)
            {
                ulazniPodaci.Ucenik = new Ucenik();
            }
            else
            {
                ulazniPodaci.Ucenik = _context.Ucenik.Find(UcenikID);
            }

            ulazniPodaci.Opcina = _context.Opcina.Select(s => new SelectListItem
            {
                Value = s.ID.ToString(),
                Text = s.Naziv
            }).ToList();

            ulazniPodaci.Roditelj = _context.Roditelj.Select(s => new SelectListItem
            {
                Value = s.ID.ToString(),
                Text = s.Ime + " " + s.Prezime
            }).ToList();

            ulazniPodaci.Vladanje = _context.Vladanje.Select(s => new SelectListItem
            {
                Value = s.ID.ToString(),
                Text = s.VladanjeOpisno
            }).ToList();

            return View(ulazniPodaci);
        }

        public ActionResult Snimi(int UcenikID, string Ime, string Prezime, string Spol, DateTime DatumRodjenja, string JMBG, int RoditeljID, int OpcinaID, int VladanjeID)
        {
            Ucenik o;
            if (UcenikID == 0)
            {
                o = new Ucenik();
                _context.Add(o);
            }
            else
            {
                o = _context.Ucenik.Find(UcenikID);
            }
            o.Ime = Ime;
            o.Prezime = Prezime;
            o.Spol = Spol;
            o.DatumRodjenja = DatumRodjenja;
            o.JMBG = JMBG;
            o.RoditeljID = RoditeljID;
            o.OpcinaID = OpcinaID;
            o.VladanjeID = VladanjeID;
            _context.SaveChanges();
            return RedirectToAction("Prikaz");
        }

     






    }
}