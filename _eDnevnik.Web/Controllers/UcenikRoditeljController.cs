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
using Microsoft.EntityFrameworkCore;

namespace _eDnevnik.Web.Controllers
{
    [Autorizacija(roditelj: true, profesor: false, administrator: false)]
    public class UcenikRoditeljController : Controller
    {
        private MyDbContext _context;
        public UcenikRoditeljController(MyDbContext context)
        {
            _context = context;
        }

        public ActionResult Prikaz()
        {
            try
            {
                Roditelj roditelj = _context.Roditelj.Where(r => r.LoginID == HttpContext.GetLogiraniKorisnik().ID).FirstOrDefault();

                Ucenik ucenik = _context.Ucenik.Include(o => o.Opcina).Include(o => o.Vladanje).Include(o => o.Roditelj).Where(o => o.RoditeljID == roditelj.ID).FirstOrDefault();
                if (ucenik == null)
                {
                    return View(null);
                }

                UcenikRoditeljPrikazVM ulazniPodaci = new UcenikRoditeljPrikazVM
                {
                    UcenikID = ucenik.ID,
                    Ime = ucenik.Ime,
                    Prezime = ucenik.Prezime,
                    Spol = ucenik.Spol,
                    DatumRodjenja = ucenik.DatumRodjenja,
                    JMBG = ucenik.JMBG,
                    Roditelj = ucenik.Roditelj.Ime + " " + ucenik.Roditelj.Prezime,
                    Vladanje = ucenik.Vladanje.VladanjeOpisno + " (" + ucenik.Vladanje.VladanjeBrojcano + ")",
                    Opcina = ucenik.Opcina.Naziv,
                };

                OdjeljenjeUcenik odjeljenjeUcenik = _context.OdjeljenjeUcenik.Include(o => o.Odjeljenje)
                    .Where(o => o.UcenikID == ucenik.ID && o.Odjeljenje.PrebacenUViseOdjeljenje == false).FirstOrDefault();
                ulazniPodaci.ListaIzostanaka = new List<UcenikRoditeljPrikazVM.RowsI>();
                ulazniPodaci.ListaOcjena = new List<UcenikRoditeljPrikazVM.RowsO>();

                if (odjeljenjeUcenik == null)
                {
                    return View(ulazniPodaci);
                }

                List<SlusaPredmet> slusaPredmets = _context.SlusaPredmet.Where(o => o.OdjeljenjeUcenikID == odjeljenjeUcenik.ID).ToList();

                foreach (SlusaPredmet sp in slusaPredmets)

                {
                    if (_context.Izostanak.Where(o => o.SlusaPredmetID == sp.ID).FirstOrDefault() != null)
                    {
                        ulazniPodaci.ListaIzostanaka.AddRange(_context.Izostanak.Select(o => new UcenikRoditeljPrikazVM.RowsI
                        {
                            IzostanakID = o.ID,
                            SlusaPredmetID = o.SlusaPredmetID,
                            CasID = o.CasID,
                            Napomena = o.Napomena,
                            DatumIzostanka = o.DatumIzostanka,
                            Opravdan = o.Opravdan
                        }).Where(o => o.SlusaPredmetID == sp.ID).ToList());
                    }

                    if (_context.Ocjena.Where(o => o.SlusaPredmetID == sp.ID).FirstOrDefault() != null)
                    {
                        ulazniPodaci.ListaOcjena.AddRange(_context.Ocjena.Select(o => new UcenikRoditeljPrikazVM.RowsO
                        {
                            OcjenaID = o.ID,
                            SlusaPredmetID = o.SlusaPredmetID,
                            CasID = o.CasID,
                            OcjenaBrojcano = o.OcjenaBrojcano,
                            OcjenaOpisno = o.OcjenaOpisno,
                            Datum = o.DatumUnosaOcjene
                        }).Where(o => o.SlusaPredmetID == sp.ID).ToList());
                    }
                }// problem select null

                foreach (UcenikRoditeljPrikazVM.RowsI i in ulazniPodaci.ListaIzostanaka)
                {
                    //predmet profesor
                    Cas cas = _context.Cas.Where(o => o.ID == i.CasID).FirstOrDefault();
                    Predaje predaje = _context.Predaje.Include(o => o.Predmet).Include(o => o.Profesor).Where(o => o.ID == cas.PredajeID).FirstOrDefault();
                    i.Profesor = predaje.Profesor.Ime + " " + predaje.Profesor.Prezime;
                    i.Predmet = predaje.Predmet.Naziv + " (" + predaje.Predmet.Oznaka + ")";
                }

                foreach (UcenikRoditeljPrikazVM.RowsO i in ulazniPodaci.ListaOcjena)
                {
                    //predmet profesor
                    Cas cas = _context.Cas.Where(o => o.ID == i.CasID).FirstOrDefault();
                    Predaje predaje = _context.Predaje.Include(o => o.Predmet).Include(o => o.Profesor).Where(o => o.ID == cas.PredajeID).FirstOrDefault();
                    i.Profesor = predaje.Profesor.Ime + " " + predaje.Profesor.Prezime;
                    i.Predmet = predaje.Predmet.Naziv + " (" + predaje.Predmet.Oznaka + ")";
                }

                return View(ulazniPodaci);


            }
            catch (Exception)
            {
                // EmailController.SendEmail(tehnicka.podrska@gmail.com, "Roditelj - UcenikRoditelj - eDnevnik", "Problem s prikazom podataka o uceniku!");//Izmisljen mail
                return RedirectToAction("Index", "Home");
            }
        }
    }
}