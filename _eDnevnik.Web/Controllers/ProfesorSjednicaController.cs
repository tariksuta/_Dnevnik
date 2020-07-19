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

    public class ProfesorSjednicaController : Controller
    {
        private MyDbContext _context;
        public ProfesorSjednicaController(MyDbContext context)
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

        
    }
}