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
    [Autorizacija(roditelj: false, profesor: false, administrator: true)]

    public class GradController : Controller
    {
        private MyDbContext _context;
        public GradController(MyDbContext context)
        {
            _context = context;
        }

        public ActionResult Prikaz()
        {
            GradPrikazVM ulazniPodaci = new GradPrikazVM();
            try
            {
                ulazniPodaci.ListaGradova = _context.Grad.Select(
                    o => new GradPrikazVM.Rows
                    {
                        GradID = o.ID,
                        Naziv = o.Naziv,
                        Drzava = o.Drzava.Naziv
                    }
                ).ToList();
                return View(ulazniPodaci);
            }
            catch (Exception)
            {
                // EmailController.SendEmail(tehnicka.podrska@gmail.com, "Prikaz država-eDnevnik", "Problem s prikazom država-eDnevnik");//Izmisljen mail
                return RedirectToAction("Index", "Home");
            }
        }

        public ActionResult DodajUredi(int GradID)
        {
            GradDodajUrediVM ulazniPodaci = new GradDodajUrediVM();
            try
            {
                if (GradID != 0)
                {

                    Grad g = _context.Grad.Find(GradID);
                    ulazniPodaci.GradID = g.ID;
                    ulazniPodaci.Naziv = g.Naziv;
                    ulazniPodaci.DrzavaID = g.DrzavaID;
                }

                pripremiCmbStavke(ulazniPodaci);

                return View(ulazniPodaci);
            }
            catch (Exception)
            {
               // throw new Exception();
                return RedirectToAction("Prikaz");
            }

        }

        private void pripremiCmbStavke(GradDodajUrediVM ulazniPodaci) {
            ulazniPodaci.Drzave = _context.Drzava.Select(s => new SelectListItem
            {
                Value = s.ID.ToString(),
                Text = s.Naziv
            }).ToList();
        }

        public ActionResult Snimi(GradDodajUrediVM input)
        {
            if (!ModelState.IsValid)
            {
                pripremiCmbStavke(input);
                return View("DodajUredi", input);
            }

            try
            {
                Grad grad = _context.Grad.Where(o => o.Naziv == input.Naziv && o.DrzavaID == input.DrzavaID).FirstOrDefault();
                if (grad != null)
                {
                    pripremiCmbStavke(input);
                    TempData["greskaPoruka"] = "Nemoguće dulpliciranje gradova!";
                    return View("DodajUredi", input);
                }

                Grad o;
                if (input.GradID == 0)
                {
                    o = new Grad();
                    _context.Add(o);
                }
                else
                {
                    o = _context.Grad.Find(input.GradID);
                }
                o.Naziv = input.Naziv;
                o.DrzavaID = input.DrzavaID;
                _context.SaveChanges();
                return RedirectToAction("Prikaz");
            }
            catch (Exception)
            {
                return RedirectToAction("Prikaz");
            }


        }

        public ActionResult Obrisi(int GradID)
        {
            try
            {
                Grad o = _context.Grad.Find(GradID);
                _context.Grad.Remove(o);
                _context.SaveChanges();
            }
            catch (Exception)
            {

                TempData["greskaPoruka"] = "Nemoguće obrisati grad!";
            }
            return RedirectToAction("Prikaz");
        }

    }
}