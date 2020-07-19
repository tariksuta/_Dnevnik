using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using _eDnevnik.Data;
using _eDnevnik.Data.EntityModel;
using _eDnevnik.Web.Helper;
using _eDnevnik.Web.ViewModel;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace _eDnevnik.Web.Controllers
{
    [Autorizacija(roditelj: true, profesor: false, administrator: false)]
    public class RasporedKonsultacijaRoditeljController : Controller
    {
        private MyDbContext _context;

        public RasporedKonsultacijaRoditeljController(MyDbContext db)
        {
            _context = db;
        }

        public IActionResult Prikaz()
        {
            try
            {
                RasporedKonsultacijaRoditeljPrikazVM ulazniPodaci = new RasporedKonsultacijaRoditeljPrikazVM
                {
                    rasporedi = _context.Profesor.Select(x => new RasporedKonsultacijaRoditeljPrikazVM.Row
                    {
                        ProfesorID = x.ID,
                        Ime = x.Ime,
                        Prezime = x.Prezime,
                        SkolskaGodina = x.RasporedKonsultacija.SkolskaGodina.Naziv,
                        imefajla = x.RasporedKonsultacija.imefajla,
                        Napomena = x.RasporedKonsultacija.Napomena
                    }).ToList()
                };
                return View(ulazniPodaci);
            }
            catch (Exception)
            {
                // EmailController.SendEmail(tehnicka.podrska@gmail.com, "Roditelj - RasporedKonsultacijaRoditelj - eDnevnik", "Problem s prikazom rasporeda konsultacija!");//Izmisljen mail
                return RedirectToAction("Index", "Home");
            }
        }
    } 
        
}