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

    public class SjednicaController : Controller
    {
        private MyDbContext _context;
        public SjednicaController(MyDbContext context)
        {
            _context = context;
        }

        public IActionResult Prikaz()
        {
            SjednicaPrikazVM ulazniPodaci = new SjednicaPrikazVM
            {
                ListaSjednica = _context.Sjednica.Select(
                    s => new SjednicaPrikazVM.Rows
                    {
                        ID = s.ID,
                        DatumOdrzavanja = s.DatumOdrzavanja,
                        Naziv = s.Naziv,
                        SkolskaGodina = s.SkolskaGodina.Naziv,
                    }
                ).ToList()
            };
            return View(ulazniPodaci);
        }

        public IActionResult DodajUredi(int SjednicaID)
        {
            SjednicaDodajUrediVM ulazniPodaci = new SjednicaDodajUrediVM();
            if (SjednicaID != 0)
            {
               Sjednica s = _context.Sjednica.Find(SjednicaID);
                ulazniPodaci.SjednicaID = s.ID;
                ulazniPodaci.DatumOdrzavanja = s.DatumOdrzavanja;
                ulazniPodaci.Naziv = s.Naziv;
                ulazniPodaci.SkolskaGodinaID = s.SkolskaGodinaID;
            }

            pripremiCmbStavke(ulazniPodaci);

            return View(ulazniPodaci);
        }
        private void pripremiCmbStavke(SjednicaDodajUrediVM ulazniPodaci)
        {
            ulazniPodaci.SkolskeGodine = _context.SkolskaGodina.Select(
                    sg => new SelectListItem
                    {
                        Value = sg.ID.ToString(),
                        Text = sg.Naziv
                    }
                ).ToList();
        }

        [HttpPost]
        [ValidateAntiForgeryToken()]
        public IActionResult Snimi(SjednicaDodajUrediVM input)
        {
            if (!ModelState.IsValid)
            {
                pripremiCmbStavke(input);
                return View("DodajUredi", input);
            }

            Sjednica s;
            if (input.SjednicaID == 0)
            {
                s = new Sjednica();
                _context.Add(s);
            }
            else
            {
                s = _context.Sjednica.Find(input.SjednicaID);
            }
            s.DatumOdrzavanja = input.DatumOdrzavanja;
            s.Naziv = input.Naziv;
            s.SkolskaGodinaID = input.SkolskaGodinaID;
            _context.SaveChanges();
            return Redirect("Prikaz");
        }

        public IActionResult Obrisi(int SjednicaID)
        {
            try
            {
                Sjednica sjednica = _context.Sjednica.Find(SjednicaID);
                _context.Sjednica.Remove(sjednica);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                TempData["greskaPoruka"] = "Nemoguće obrisati sjednicu!";
            }

            return Redirect("Prikaz");
        }
    }
}