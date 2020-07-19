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
    public class VladanjeController : Controller
    {
        private MyDbContext _context;
        public VladanjeController(MyDbContext context)
        {
            _context = context;
        }

        public ActionResult Prikaz()
        {
            VladanjePrikazVM ulazniPodaci = new VladanjePrikazVM
            {
                ListaVladanja = _context.Vladanje.Select(
                    o => new Vladanje
                    {
                        ID = o.ID,
                        VladanjeBrojcano = o.VladanjeBrojcano,
                        VladanjeOpisno = o.VladanjeOpisno,
                        Napomena = o.Napomena
                    }
                ).ToList()
            };
            return View(ulazniPodaci);
        }

        public ActionResult DodajUredi(int VladanjeID)
        {
            VladanjeDodajUrediVM ulazniPodaci = new VladanjeDodajUrediVM();
            if (VladanjeID != 0) {
                Vladanje v = _context.Vladanje.Find(VladanjeID);
                ulazniPodaci.VladanjeID = v.ID;
                ulazniPodaci.VladanjeOpisno = v.VladanjeOpisno;
                ulazniPodaci.VladanjeBrojcano = v.VladanjeBrojcano;
                ulazniPodaci.Napomena = v.Napomena;
            }
            return View(ulazniPodaci);
        }

        public ActionResult Snimi(VladanjeDodajUrediVM input)
        {
            if (!ModelState.IsValid)
            {
                return View("DodajUredi", input);
            }

            Vladanje o;
            if (input.VladanjeID == 0)
            {
                o = new Vladanje();
                _context.Add(o);
            }
            else
            {
                o = _context.Vladanje.Find(input.VladanjeID);
            }
            o.ID = input.VladanjeID;
            o.VladanjeBrojcano = input.VladanjeBrojcano;
            o.VladanjeOpisno = input.VladanjeOpisno;
            o.Napomena = input.Napomena;
            _context.SaveChanges();
            return RedirectToAction("Prikaz");
        }

        public ActionResult Obrisi(int VladanjeID)
        {
            try
            {
                Vladanje o = _context.Vladanje.Find(VladanjeID);
                _context.Vladanje.Remove(o);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                TempData["greskaPoruka"] = "Nemoguće obrisati vladanje!";
            }

            return RedirectToAction("Prikaz");
        }
    }
}