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
    public class DrzavaController : Controller
    {
        private MyDbContext _context;
        public DrzavaController(MyDbContext context)
        {
            _context = context;
        }

        public ActionResult Prikaz()
        {
            try
            {
                DrzavaPrikazVM ulazniPodaci = new DrzavaPrikazVM();
                ulazniPodaci.ListaDrzava = _context.Drzava.Select(
                    o => new Drzava
                    {
                        ID = o.ID,
                        Naziv = o.Naziv,
                    }
                    ).ToList();
                return View(ulazniPodaci);
            }
            catch (Exception e)
            {

                List<Administrator> la = _context.Administrator.ToList();
                foreach (Administrator l in la)
                    if (l.Email != null)
                    {
                        string naslov = "Prikaz država-eDnevnik";
                        string sadrzaj = "Problem s prikazom država-eDnevnik"+e.Message;
                        string primalac = l.Email;
                        EmailController.SendEmail(primalac, naslov, sadrzaj);//Salje svim adminima
                    }

                //ili

                EmailController.SendEmail("amelmaslo@gmail.com", "Prikaz država-eDnevnik", "Problem s prikazom država-eDnevnik");
                return RedirectToAction("Index", "Home");
            }
        }

        public ActionResult DodajUredi(int DrzavaID)
        {
            try
            {
                DrzavaDodajUrediVM ulazniPodaci = new DrzavaDodajUrediVM();
                if (DrzavaID != 0)
                {
                    Drzava d = _context.Drzava.Find(DrzavaID);
                    ulazniPodaci.DrzavaID = d.ID;
                    ulazniPodaci.Naziv = d.Naziv;
                }
                return View(ulazniPodaci);
            }
            catch (Exception)
            {
                return RedirectToAction("Prikaz");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken()]
        public ActionResult Snimi(DrzavaDodajUrediVM input)
        {
            if (!ModelState.IsValid)
            {
                return View("DodajUredi", input);
            }

            try
            {
                Drzava drzava = _context.Drzava.Where(o => o.Naziv == input.Naziv).FirstOrDefault();
                if (drzava != null)
                {
                    TempData["greskaPoruka"] = "Nemoguće dulpliciranje država!";
                    return View("DodajUredi", input);
                }

                Drzava o;
                if (input.DrzavaID == 0)
                {
                    o = new Drzava();
                    _context.Add(o);
                }
                else
                {
                    o = _context.Drzava.Find(input.DrzavaID);
                }
                o.ID = input.DrzavaID;
                o.Naziv = input.Naziv;
                _context.SaveChanges();
                return RedirectToAction("Prikaz");
            }
            catch (Exception)
            {
                return RedirectToAction("Prikaz");
            }
        }

        public ActionResult Obrisi(int DrzavaID)
        {
            try
            {
                Drzava o = _context.Drzava.Find(DrzavaID);
                _context.Drzava.Remove(o);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                TempData["greskaPoruka"] = "Nemoguće obrisati državu!";
            }
            return RedirectToAction("Prikaz");

        }
    }
}