using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _eDnevnik.Data;
using _eDnevnik.Web.Helper;
using _eDnevnik.Web.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace _eDnevnik.Web.Controllers
{
    [Autorizacija(roditelj: false, profesor: true, administrator: false)]
    public class RazrednikController : Controller
    {
        private MyDbContext _context;

        public RazrednikController(MyDbContext db)
        {
            _context = db;
        }
        public IActionResult Index()
        {
            int id = _context.Profesor.Where(x => x.LoginID == HttpContext.GetLogiraniKorisnik().ID).FirstOrDefault().ID;
            int oid = _context.Odjeljenje.Where(x => x.RazrednikID == id).FirstOrDefault().ID;
            RazrednikIndexVM Model = new RazrednikIndexVM
            {
                BrojIzostanaka = _context.Izostanak.Count(x => x.SlusaPredmet.OdjeljenjeUcenik.OdjeljenjeID == oid),
                BrojOcjena = _context.Ocjena.Count(x => x.SlusaPredmet.OdjeljenjeUcenik.OdjeljenjeID == oid),
                BrojUcenika = _context.OdjeljenjeUcenik.Count(x => x.OdjeljenjeID == oid)
             };
            return View(Model);
        }
    }
}