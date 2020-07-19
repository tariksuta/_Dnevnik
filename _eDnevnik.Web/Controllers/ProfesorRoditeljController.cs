using _eDnevnik.Data;
using _eDnevnik.Data.EntityModel;
using _eDnevnik.Web.Helper;
using _eDnevnik.Web.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _eDnevnik.Web.Controllers
{
    [Autorizacija(roditelj: true, profesor: false, administrator: false)]
    public class ProfesorRoditeljController : Controller
    {

        private MyDbContext _context;

        public ProfesorRoditeljController(MyDbContext db)
        {
            _context = db;
        }

        public IActionResult Prikaz()
        {
            try
            {
                ProfesoraRoditeljPrikazVM ulazniPodaci = new ProfesoraRoditeljPrikazVM();
                Roditelj roditelj = _context.Roditelj.Where(r => r.LoginID == HttpContext.GetLogiraniKorisnik().ID).FirstOrDefault();
                Ucenik ucenik = _context.Ucenik.Where(o => o.RoditeljID == roditelj.ID).FirstOrDefault();
                if (ucenik == null)
                {
                    return View(null);
                }

                OdjeljenjeUcenik odjeljenjeUcenik = _context.OdjeljenjeUcenik.Include(o => o.Odjeljenje)
                    .Where(o => o.UcenikID == ucenik.ID && o.Odjeljenje.PrebacenUViseOdjeljenje == false).FirstOrDefault();

                ulazniPodaci.ProfesoriPredmeti = new List<ProfesoraRoditeljPrikazVM.Rows>();//zato sto dodajem jedan po jedadn
                if (odjeljenjeUcenik == null)
                {
                    return View(ulazniPodaci);
                }

                List<SlusaPredmet> slusaPredmets = _context.SlusaPredmet.Where(o => o.OdjeljenjeUcenikID == odjeljenjeUcenik.ID).ToList();

                foreach (SlusaPredmet sp in slusaPredmets)
                {
                    if (_context.Predaje.Where(o => o.ID == sp.PredajeID).FirstOrDefault() != null)
                    {
                        ulazniPodaci.ProfesoriPredmeti.AddRange(_context.Predaje.Select(o => new ProfesoraRoditeljPrikazVM.Rows
                        {
                            PredajeID = o.ID,
                            Ime = o.Profesor.Ime,
                            Prezime = o.Profesor.Prezime,
                            Predmet = o.Predmet.Naziv + " (" + o.Predmet.Oznaka + ")",
                            ZakljucnaOcjenaPolugodiste = sp.ZakljucnaOcjenaNaPolugodistu,
                            ZakljucnaOcjenaKraj = sp.ZakljucnaOcjenaNaKraju
                        }).Where(o => o.PredajeID == sp.PredajeID).ToList());
                    }
                }

                return View(ulazniPodaci);
            }
            catch (Exception)
            {
                // EmailController.SendEmail(tehnicka.podrska@gmail.com, "Roditelj - ProfesorRoditelj - eDnevnik", "Problem s prikazom zakljucnih ocjena!");//Izmisljen mail
                return RedirectToAction("Index", "Home");
            }
        }
    }
}
