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
    [Autorizacija(roditelj: false, profesor: true, administrator: false)]

    public class ProfesorZapisnikController : Controller
    {
        private MyDbContext _context;
        public ProfesorZapisnikController(MyDbContext context)
        {
            _context = context;
        }

        public IActionResult Prikaz()
        {
            ZapisnikPrikazVM ulazniPodaci = new ZapisnikPrikazVM
            {
                ListaZapisnika = _context.Zapisnik.Select(
                    z => new ZapisnikPrikazVM.Rows
                    {
                        ID = z.ID,
                        Napomena=z.Napomena,
                        Sadrzaj=z.Sadrzaj,
                        Autor=z.Autor.Ime+" "+z.Autor.Prezime,
                        Sjednica = z.Sjednica.Naziv
                    }
                ).ToList()
            };
            return View(ulazniPodaci);
        }

      

        public IActionResult Detalji(int ZapisnikID)
        {
            Zapisnik zapisnik = _context.Zapisnik.Find(ZapisnikID);
            return View(zapisnik);
        }

        

       
    }
}