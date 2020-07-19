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
    public class UcenikController : Controller
    {
        private MyDbContext _context;
        public UcenikController(MyDbContext context)
        {
            _context = context;
        }

        public ActionResult Prikaz()
        {
            UcenikPrikazVM ulazniPodaci = new UcenikPrikazVM
            {
                ListaUcenika = _context.Ucenik.Select(
                    o => new UcenikPrikazVM.Rows
                    {
                        UcenikID = o.ID,
                        Ime = o.Ime,
                        Prezime = o.Prezime,
                        Spol = o.Spol,
                        DatumRodjenja = o.DatumRodjenja,
                        JMBG = o.JMBG,
                        Roditelj = o.Roditelj.Ime + " " + o.Roditelj.Prezime,
                        Vladanje = o.Vladanje.VladanjeOpisno,
                        Opcina = o.Opcina.Naziv,
                    }
                ).ToList()
            };
            return View(ulazniPodaci);
        }

        public ActionResult DodajUredi(int UcenikID)
        {
            UcenikDodajUrediVM ulazniPodaci = new UcenikDodajUrediVM();
            if (UcenikID != 0) { 
                Ucenik u = _context.Ucenik.Find(UcenikID);
                ulazniPodaci.UcenikID = u.ID;
                ulazniPodaci.Ime = u.Ime;
                ulazniPodaci.Prezime = u.Prezime;
                ulazniPodaci.Spol = u.Spol;
                ulazniPodaci.DatumRodjenja = u.DatumRodjenja;
                ulazniPodaci.JMBG = u.JMBG;
                ulazniPodaci.RoditeljID = u.RoditeljID;
                ulazniPodaci.VladanjeID = u.VladanjeID;
                ulazniPodaci.OpcinaID = u.OpcinaID;
            }

            pripremiCmbStavke(ulazniPodaci);
            return View(ulazniPodaci);
        }
        private void pripremiCmbStavke(UcenikDodajUrediVM ulazniPodaci) {
            ulazniPodaci.Opcina = _context.Opcina.Select(s => new SelectListItem
            {
                Value = s.ID.ToString(),
                Text = s.Naziv
            }).ToList();

            ulazniPodaci.Vladanje = _context.Vladanje.Select(s => new SelectListItem
            {
                Value = s.ID.ToString(),
                Text = s.VladanjeOpisno
            }).ToList();

            /*ulazniPodaci.Roditelj = _context.Roditelj.Select(s => new SelectListItem
            {
                Value = s.ID.ToString(),
                Text = s.Ime + " " + s.Prezime
            }).ToList();*/

            List<Roditelj> listaRoditelja = _context.Roditelj.ToList();
            ulazniPodaci.Roditelj = new List<SelectListItem>();

            foreach (Roditelj r in listaRoditelja)
            {
                Ucenik u = _context.Ucenik.Where(o => o.RoditeljID == r.ID).FirstOrDefault();
                if (u == null)
                {
                    ulazniPodaci.Roditelj.Add(new SelectListItem
                    {
                        Value = r.ID.ToString(),
                        Text = r.Ime + " " +r.Prezime
                    });
                }
            }
            if (ulazniPodaci.RoditeljID != 0)
            {
                ulazniPodaci.Roditelj.Add(new SelectListItem
                {
                    Value = ulazniPodaci.RoditeljID.ToString(),
                    Text = "Trenutni Login"
                });
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken()]
        public ActionResult Snimi(UcenikDodajUrediVM input)
        {
            if (!ModelState.IsValid)
            {
                pripremiCmbStavke(input);
                return View("DodajUredi", input);
            }

            Ucenik o;
            if (input.UcenikID == 0)
            {
                o = new Ucenik();
                _context.Add(o);
            }
            else
            {
                o = _context.Ucenik.Find(input.UcenikID);
            }
            o.Ime = input.Ime;
            o.Prezime = input.Prezime;
            o.Spol = input.Spol;
            o.DatumRodjenja = input.DatumRodjenja;
            o.JMBG = input.JMBG;
            o.RoditeljID = input.RoditeljID;
            o.OpcinaID = input.OpcinaID;
            o.VladanjeID = input.VladanjeID;
            _context.SaveChanges();
            return RedirectToAction("Prikaz");
        }

        public ActionResult Obrisi(int UcenikID)
        {
            try
            {

                Ucenik o = _context.Ucenik.Find(UcenikID);
            _context.Ucenik.Remove(o);
            _context.SaveChanges();
            }
            catch (Exception)
            {
                TempData["greskaPoruka"] = "Nemoguće obrisati učenika!";
            }

            return RedirectToAction("Prikaz");
        }
    }
}