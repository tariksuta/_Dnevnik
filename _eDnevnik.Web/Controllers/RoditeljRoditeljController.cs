using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _eDnevnik.Data;
using _eDnevnik.Data.EntityModel;
using _eDnevnik.Web.Helper;
using _eDnevnik.Web.ViewModel;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace _eDnevnik.Web.Controllers
{
    [Autorizacija(roditelj: true, profesor: false, administrator: false)]
    public class RoditeljRoditeljController : Controller
    {
        private MyDbContext _context;
        public RoditeljRoditeljController(MyDbContext context)
        {
            _context = context;
        }

        public ActionResult Prikaz()
        {
            try
            {
                Roditelj roditelj = _context.Roditelj.Include(x => x.Opcina).Where(r => r.LoginID == HttpContext.GetLogiraniKorisnik().ID).FirstOrDefault();

                RoditeljRoditeljPrikazVM x = new RoditeljRoditeljPrikazVM
                {
                    RoditeljID = roditelj.ID,
                    Ime = roditelj.Ime,
                    Prezime = roditelj.Prezime,
                    Spol = roditelj.Spol,
                    JMBG = roditelj.JMBG,
                    DatumRodjenja = roditelj.DatumRodjenja,
                    Opcina = roditelj.Opcina?.Naziv,
                    Telefon = roditelj.Telefon,
                    Email = roditelj.Email,
                    NazivSlike = roditelj.NazivSlike
                };

                return View(x);
            }
            catch (Exception) {
             // EmailController.SendEmail(tehnicka.podrska@gmail.com, "Roditelj - RoditeljRoditelj - eDnevnik", "Problem s prikazom ličnih podataka!");//Izmisljen mail
                return RedirectToAction("Index", "Home");
            }
        }


    }
}