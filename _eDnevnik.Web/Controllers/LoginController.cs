using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _eDnevnik.Data;
using _eDnevnik.Data.EntityModel;
using _eDnevnik.Web.Helper;
using _eDnevnik.Web.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace _eDnevnik.Web.Controllers
{
    [Autorizacija(roditelj: false, profesor: false, administrator: true)]

    public class LoginController : Controller
    {
        private MyDbContext _context;
        public LoginController(MyDbContext context)
        {
            _context = context;
        }

        public ActionResult Prikaz()
        {
            LoginPrikazVM ulazniPodaci = new LoginPrikazVM
            {
                ListaLogina = _context.Login.Select(
                    o => new Login
                    {
                        ID = o.ID,
                        KorisnickoIme = o.KorisnickoIme,
                        Sifra = o.Sifra,
                        ZapamtiSifru = true,
                    }
                ).ToList()
            };
            return View(ulazniPodaci);
        }

        public ActionResult DodajUredi(int LoginID)
        {
            LoginDodajUrediVM ulazniPodaci = new LoginDodajUrediVM();
            Login login = _context.Login.Find(LoginID);
            if (login != null)
            {
                ulazniPodaci.ID = login.ID;
                ulazniPodaci.KorisnickoIme = login.KorisnickoIme;
                ulazniPodaci.Sifra = login.Sifra;
            }

            return View(ulazniPodaci);
        }

        [HttpPost]
        [ValidateAntiForgeryToken()]
        public ActionResult Snimi(LoginDodajUrediVM ulazniPodaci)
        {
            if (!ModelState.IsValid)
            {
                return View("DodajUredi", ulazniPodaci);
            }

            Login login = _context.Login.Where(o => o.KorisnickoIme == ulazniPodaci.KorisnickoIme).FirstOrDefault();
            if (login != null) {
                TempData["greskaPoruka"] = "Nemoguće dulpliciranje korisničkih imena!";
                return View("DodajUredi", ulazniPodaci);
            }

            Login o;
            if (ulazniPodaci.ID == 0)
            {
                o = new Login();
                _context.Add(o);
            }
            else
            {
                o = _context.Login.Find(ulazniPodaci.ID);
            }

            o.ID = ulazniPodaci.ID;
            o.KorisnickoIme = ulazniPodaci.KorisnickoIme;
            o.Sifra = ulazniPodaci.Sifra;
            _context.SaveChanges();
            return RedirectToAction("Prikaz");
        }

        public ActionResult Obrisi(int LoginID)
        {
            Login o = _context.Login.Find(LoginID);
            try
            {
                _context.Login.Remove(o);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                TempData["greskaPoruka"] = "Nije moguce obrisati login!";
            }
            return RedirectToAction("Prikaz");
        }
    }
}