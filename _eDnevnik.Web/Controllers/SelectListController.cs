using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _eDnevnik.Data;
using _eDnevnik.Data.EntityModel;
using _eDnevnik.Web.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace _eDnevnik.Web.Controllers
{
    public class SelectListController : Controller
    {
        private MyDbContext _context;

        public SelectListController(MyDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
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

        public JsonResult getGradovi(int id)
        {
            var list = new List<Grad>();

            list = _context.Grad.Where(l => l.DrzavaID == id).ToList();

            list.Insert(0, new Grad { ID = 0, Naziv = "Odaberi grad" });

            return Json(new SelectList(list, "ID", "Naziv"));
        }

        public IActionResult Snimi(SelectListIndexVM x)
        {
            int id1 = x.DrzavaID;
            int id2 = x.GradID;
            return Redirect("");
        }

        public JsonResult getUceniciIzSekcije(int id)
        {
            var lista = new List<UceniciSekcijaProbaVM>();
            foreach (var x in _context.UcenikSekcije.Include(k => k.Ucenik).Where(l => l.SekcijaID == id))
            {
                lista.Add(new UceniciSekcijaProbaVM
                {
                    ID = x.ID,
                    Ime = x.Ucenik.Ime,
                    Prezime = x.Ucenik.Prezime,
                    DatumUpisa = x.DatumUclanjenja.ToShortDateString(),
                    Odjeljenje = _context.OdjeljenjeUcenik.Where(l => l.UcenikID == x.UcenikID).Select(k => k.Odjeljenje.Oznaka).FirstOrDefault()
                });
            }

            return Json(lista);
        }

        public JsonResult getUceniciIzOdjeljenja(int id)
        {
           

            var lista = new List<SelectListItemUcenikVM>();
            foreach (var x in _context.OdjeljenjeUcenik.Include(k => k.Ucenik).Where(l => l.OdjeljenjeID == id))
            {
                lista.Add(new SelectListItemUcenikVM
                {
                    UcenikID = x.UcenikID,
                    ImePrezime = x.Ucenik.Ime + " " + x.Ucenik.Prezime
                });
            }
            lista.Insert(0, new SelectListItemUcenikVM { UcenikID = 0, ImePrezime = "Dodaj ucenika" });
            return Json(new SelectList(lista, "UcenikID", "ImePrezime"));
        }
    }
}