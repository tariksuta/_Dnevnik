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
    public class OpcinaController : Controller
    {
        private MyDbContext _context;
        public OpcinaController(MyDbContext context)
        {
            _context = context;
        }

        public IActionResult Prikaz()
        {
            OpcinaPrikazVM ulazniPodaci = new OpcinaPrikazVM
            {
                ListaOpcina = _context.Opcina.Select(
                    o => new OpcinaPrikazVM.Rows
                    {
                        OpcinaID = o.ID,
                        Naziv = o.Naziv,
                        Grad = o.Grad.Naziv,
                        Drzava = o.Grad.Drzava.Naziv
                    }
                ).ToList()
            };
            return View(ulazniPodaci);
        }

        public IActionResult DodajUredi(int OpcinaID)
        {
            OpcinaDodajUrediVM ulazniPodaci = new OpcinaDodajUrediVM();
            if (OpcinaID != 0)
            {
                Opcina o = _context.Opcina.Find(OpcinaID);
                ulazniPodaci.OpcinaID = o.ID;
                ulazniPodaci.Naziv = o.Naziv;
                ulazniPodaci.GradID = o.GradID;
            }

            pripremiCmbStavke(ulazniPodaci);

            return View(ulazniPodaci);
        }
        private void pripremiCmbStavke(OpcinaDodajUrediVM ulazniPodaci)
        {
            ulazniPodaci.Gradovi = _context.Grad.Select(s => new SelectListItem
            {
                Value = s.ID.ToString(),
                Text = s.Naziv + " (" + s.Drzava.Naziv + ")"
            }).ToList();
        }

        public IActionResult Snimi(OpcinaDodajUrediVM input)
        {
            if (!ModelState.IsValid)
            {
                pripremiCmbStavke(input);
                return View("DodajUredi", input);
            }


            Opcina opcina = _context.Opcina.Where(o => o.Naziv == input.Naziv && o.GradID == input.GradID).FirstOrDefault();
            if (opcina != null)
            {
                pripremiCmbStavke(input);
                TempData["greskaPoruka"] = "Nemoguće dulpliciranje općina!";
                return View("DodajUredi", input);
            }


            Opcina o;
            if (input.OpcinaID == 0)
            {
                o = new Opcina();
                _context.Add(o);
            }
            else
            {
                o = _context.Opcina.Find(input.OpcinaID);
            }
            o.ID = input.OpcinaID;
            o.Naziv = input.Naziv;
            o.GradID = input.GradID;
            _context.SaveChanges();
            return RedirectToAction("Prikaz");
        }

        public IActionResult Obrisi(int OpcinaID)
        {
            try
            {
                Opcina o = _context.Opcina.Find(OpcinaID);
                _context.Opcina.Remove(o);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                TempData["greskaPoruka"] = "Nemoguće obrisati općinu!";
            }

            return RedirectToAction("Prikaz");
        }
    }
}