using _eDnevnik.Data;
using _eDnevnik.Data.EntityModel;
using _eDnevnik.Web.Helper;
using _eDnevnik.Web.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _eDnevnik.Web.Controllers
{
    [Autorizacija(roditelj: false, profesor: true, administrator: false)]
    public class ProfesorProfesorController : Controller
    {

        private MyDbContext _context;

        public ProfesorProfesorController(MyDbContext db)
        {
            _context = db;
        }


        public IActionResult Info()
        {

            Login k = HttpContext.GetLogiraniKorisnik();

            Profesor p = _context.Profesor.
                                            Include(n => n.Opcina)
                                            .Include(m => m.Opcina.Grad)
                                            .Include(m => m.Opcina.Grad.Drzava)
                                            .Include(m => m.RasporedKonsultacija)
                                            .Where(x => x.LoginID == k.ID).FirstOrDefault();

            if (p == null)
                return Redirect("/Home/Index");

            ProfesorInfo Model = new ProfesorInfo
            {
                ProfesorID = p.ID,
                Ime = p.Ime,
                Prezime = p.Prezime,
                KorisničkoIme = k.KorisnickoIme,
                Opcina = p.Opcina.Naziv,
                Grad = p.Opcina.Grad.Naziv,
                Država = p.Opcina.Grad.Drzava.Naziv,

                //// problem kad profesor nije razrednik al se da riejsiti
                //OdjeljenjeOznaka = _context.Odjeljenje.Where(x => x.RazrednikID == p.ID).FirstOrDefault().Oznaka,
                //Razred = _context.Odjeljenje.Where(x => x.RazrednikID == p.ID).FirstOrDefault().Razred,
                //SkolskaGodina = _context.Odjeljenje.Include(k => k.SkolskaGodina).Where(x => x.RazrednikID == p.ID).FirstOrDefault().SkolskaGodina.Naziv,
                //Smjer = _context.Odjeljenje.Include(k => k.Smjer).Where(x => x.RazrednikID == p.ID).FirstOrDefault().Smjer.Naziv,

                ////---------------------------------------------------------//////////////////////////
                NapomenaRasporeda = p.RasporedKonsultacija.Napomena,
                Rasporedfajl = p.RasporedKonsultacija.imefajla,
                SkolskaGodinaRaspored = _context.RasporedKonsultacija.Include(h => h.SkolskaGodina).Where(l => l.ID == p.RasporedKonsultacijaID).FirstOrDefault().SkolskaGodina.Naziv,
                NazivSlike = p.NazivSlike
            };

            if(_context.Odjeljenje.Where(l => l.RazrednikID == p.ID).FirstOrDefault() != null)
            {
                Model.OdjeljenjeOznaka = _context.Odjeljenje.Where(x => x.RazrednikID == p.ID).FirstOrDefault().Oznaka;
                Model.Razred = _context.Odjeljenje.Where(x => x.RazrednikID == p.ID).FirstOrDefault().Razred;
                Model.SkolskaGodina = _context.Odjeljenje.Include(k => k.SkolskaGodina).Where(x => x.RazrednikID == p.ID).FirstOrDefault().SkolskaGodina.Naziv;
                Model.Smjer = _context.Odjeljenje.Include(k => k.Smjer).Where(x => x.RazrednikID == p.ID).FirstOrDefault().Smjer.Naziv;
            }
            return View(Model);
        }
        public IActionResult PrikaziSveProfesore()
        {

            ProfesoraPrikazVM ulazniPodaci = new ProfesoraPrikazVM
            {

                Profesori = _context.Profesor.Select(p => new ProfesoraPrikazVM.Row
                {
                    ProfesorID = p.ID,
                    Ime = p.Ime,
                    Spol = p.Spol,
                    Prezime = p.Prezime,
                    DatumRodjenja = p.DatumRodjenja.ToString().Substring(0, 11),
                    Opcina = p.Opcina.Naziv,
                    RasporedKonsultacija = p.RasporedKonsultacija.Napomena,
                    OdjeljenjeID = (_context.Odjeljenje.Where(x => x.RazrednikID == p.ID).FirstOrDefault().ID != 0 ? _context.Odjeljenje.Where(x => x.RazrednikID == p.ID).FirstOrDefault().ID : 0)
                }).ToList()
            };


            return View(ulazniPodaci);
        }

    }
}
