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
    [Autorizacija(roditelj: false, profesor: false, administrator: true)]
    public class OdjeljenjeController : Controller
    {
        private MyDbContext _context;
        public OdjeljenjeController(MyDbContext context)
        {
            _context = context;
        }
                
        public ActionResult Prikaz()
        {
            /*Login korisnik = HttpContext.GetLogiraniKorisnik();//<-- dodao
            if (korisnik == null)
            {
                //ViewData["error_poruka"] = "Niste logirani";//view data se nakon redirecta prazni pa se poruka nece ispisati
                TempData["error_poruka"] = "Niste logirani";//zato koristimo TempData
                return RedirectToAction("Index", "Autentifikacija");
                //return Unauthorized();
            }*/

            PrikazOdjeljenjaVM ulazniPodaci = new PrikazOdjeljenjaVM
            {
                ListaOdjeljenja = _context.Odjeljenje.Select(
                    o => new PrikazOdjeljenjaVM.Rows
                    {
                        OdjeljenjeID = o.ID,
                        Razred = o.Razred,
                        Oznaka = o.Oznaka,
                        PrebacenUViseOdjeljenje = o.PrebacenUViseOdjeljenje,
                        SkolskaGodina = o.SkolskaGodina.Naziv,
                        Razrednik = o.Razrednik.Ime + " " + o.Razrednik.Prezime,
                        Smjer=o.Smjer.Naziv+"/"+o.Smjer.Oznaka
                    }
                ).ToList()
            };
            return View(ulazniPodaci);
        }

        public ActionResult DodajUredi(int OdjeljenjeID)
        {
            OdjeljenjeDodajUrediVM ulazniPodaci = new OdjeljenjeDodajUrediVM();
            if (OdjeljenjeID != 0)
            {
                Odjeljenje o = _context.Odjeljenje.Find(OdjeljenjeID);
                ulazniPodaci.OdjeljenjeID = o.ID;
                ulazniPodaci.Razred  = o.Razred;
                ulazniPodaci.Oznaka = o.Oznaka;
                ulazniPodaci.PrebacenUViseOdjeljenje = o.PrebacenUViseOdjeljenje;
                ulazniPodaci.SkolskaGodinaID = o.SkolskaGodinaID;
                ulazniPodaci.RazrednikID = o.RazrednikID;
                ulazniPodaci.SmjerID = o.SmjerID;
            }

            pripremiCmbStavke(ulazniPodaci);

            return View(ulazniPodaci);
        }
        private void pripremiCmbStavke(OdjeljenjeDodajUrediVM ulazniPodaci)
        {
            ulazniPodaci.SkolskeGodine = _context.SkolskaGodina.Select(s => new SelectListItem
            {
                Value = s.ID.ToString(),
                Text = s.Naziv
            }).ToList();

            ulazniPodaci.Razrednici = _context.Profesor.Select(s => new SelectListItem
            {
                Value = s.ID.ToString(),
                Text = s.Ime + " " + s.Prezime
            }).ToList();

            ulazniPodaci.Smjerovi = _context.Smjer.Select(s => new SelectListItem
            {
                Value = s.ID.ToString(),
                Text = s.Naziv
            }).ToList();

            ulazniPodaci.OdjeljenjaZaPrebaciti = _context.Odjeljenje.Where(o=>o.PrebacenUViseOdjeljenje==false).Select(o=>
                new SelectListItem
                {
                    Value=o.ID.ToString(),
                    Text=o.Oznaka+"/školska godina: "+o.SkolskaGodina.Naziv
                }).ToList();
        }

        public ActionResult Snimi(OdjeljenjeDodajUrediVM input)
        {
            if (!ModelState.IsValid)
            {
                pripremiCmbStavke(input);
                return View("DodajUredi", input);
            }

            Odjeljenje odjeljenje = _context.Odjeljenje.Where(o => o.Oznaka == input.Oznaka && o.SkolskaGodinaID == input.SkolskaGodinaID).FirstOrDefault();
            if (odjeljenje != null && odjeljenje.ID != input.OdjeljenjeID) {
                pripremiCmbStavke(input);
                TempData["greskaPoruka"] = "Odjeljenje već dodano!";
                return View("DodajUredi", input);
            }

            odjeljenje = _context.Odjeljenje.Where(o => o.RazrednikID == input.RazrednikID && o.SkolskaGodinaID == input.SkolskaGodinaID).FirstOrDefault();
            if (odjeljenje != null && odjeljenje.ID != input.OdjeljenjeID)
            {
                pripremiCmbStavke(input);
                TempData["greskaPoruka"] = "Razrednik već dodan!";
                return View("DodajUredi", input);
            }

            Odjeljenje o;
            if (input.OdjeljenjeID == 0)
            {
                o = new Odjeljenje();
                _context.Add(o);
            }
            else
            {
                o = _context.Odjeljenje.Find(input.OdjeljenjeID);
            }
            o.Razred = input.Razred;
            o.Oznaka = input.Oznaka;
            o.SkolskaGodinaID = input.SkolskaGodinaID;
            o.RazrednikID = input.RazrednikID;
            o.RazrednikID = input.RazrednikID;
            o.SmjerID = input.SmjerID;
            o.PrebacenUViseOdjeljenje = false;
            _context.SaveChanges();

            Odjeljenje staroOdjeljenje = _context.Odjeljenje.Find(input.prebacenoOdjeljenjeID);
            if (staroOdjeljenje != null)
            {
                staroOdjeljenje.PrebacenUViseOdjeljenje = true;

            IQueryable<OdjeljenjeUcenik> sviUceniciIzStarogOdjeljenja = _context.OdjeljenjeUcenik.
                    Where(o => o.OdjeljenjeID == staroOdjeljenje.ID);

                foreach (OdjeljenjeUcenik u in sviUceniciIzStarogOdjeljenja)
                {
                    int zakljucneJedinice = _context.SlusaPredmet.Where(sp => sp.OdjeljenjeUcenikID == u.ID)
                        .Count(sp=>sp.ZakljucnaOcjenaNaKraju==1);
                    if (zakljucneJedinice == 0)
                    {
                        OdjeljenjeUcenik noviUcenik = new OdjeljenjeUcenik
                        {
                            UcenikID = u.UcenikID,
                            Odjeljenje = o,
                            BrojUDnevniku = u.BrojUDnevniku
                        };
                        _context.OdjeljenjeUcenik.Add(noviUcenik);

                        List<Predaje> predajeLista = _context.Predaje.Where(x => x.OdjeljenjeID == u.OdjeljenjeID).ToList();

                        foreach (Predaje p in predajeLista)
                        {
                            SlusaPredmet zakljucna = new SlusaPredmet
                            {
                                OdjeljenjeUcenikID = u.ID,
                                PredajeID = p.ID,
                                ZakljucnaOcjenaNaKraju = 0,
                                ZakljucnaOcjenaNaPolugodistu = 0
                            };
                            _context.Add(zakljucna);
                        }
                    }

                }
                _context.SaveChanges();
            }
            return RedirectToAction("Prikaz");
        }

        public ActionResult Obrisi(int OdjeljenjeID)
        {
            try
            {
                Odjeljenje o = _context.Odjeljenje.Find(OdjeljenjeID);

                //if (o.RazrednikID != _context.Profesor.Where(x => x.ID == HttpContext.GetLogiraniKorisnik().ID).Select(s => s.ID).Single())
                //{
                //    TempData["greskaPoruka"] = "Nemate pravo pristurpa";
                //    return RedirectToAction("Index", "Autentifikacija");
                //}//Provjera da li je prof obrisao svoj razred

                _context.Odjeljenje.Remove(o);
                _context.SaveChanges();
            }
            catch (Exception) { 
                    TempData["greskaPoruka"] = "Nemoguće obrisat odjeljenje";

            }
            return RedirectToAction("Prikaz");
        }

        public ActionResult Detalji(int OdjeljenjeID)
        {
            Odjeljenje o = _context.Odjeljenje.Where(o=>o.ID==OdjeljenjeID).Include("Razrednik").Include("SkolskaGodina").Include("Smjer").First();
            OdjeljenjeDetaljiVM ulazniPodaci = new OdjeljenjeDetaljiVM { 
                OdjeljenjeID=o.ID,
                PrebacenUViseOdjeljenje=false,
                Oznaka=o.Oznaka,
                Razred=o.Razred,
                Razrednik=o.Razrednik.Ime+" "+o.Razrednik.Prezime,
                SkolskaGodina=o.SkolskaGodina.Naziv,
                Smjer=o.Smjer.Naziv
            };
            return View(ulazniPodaci);
        }

        public ActionResult PrikazUcenika(int OdjeljenjeID)
        {
            OdjeljenjePrikazUcenikaVM ulazniPodaci = new OdjeljenjePrikazUcenikaVM{
                OdjeljenjeID=OdjeljenjeID,
                ListaUcenika=_context.OdjeljenjeUcenik.Where(ou=>ou.OdjeljenjeID==OdjeljenjeID).Select(
                        ou=>new OdjeljenjePrikazUcenikaVM.Rows
                        {
                            OdjeljenjeUcenikID=ou.ID,
                            ImePrezime=ou.Ucenik.Ime+" "+ou.Ucenik.Prezime,
                            BrojUDnevniku=ou.BrojUDnevniku,
                            JMBG=ou.Ucenik.JMBG,
                            ImeRoditelja=ou.Ucenik.Roditelj.Ime+" "+ou.Ucenik.Roditelj.Prezime
                        }
                    ).ToList().OrderBy(ou=>ou.BrojUDnevniku).ToList()
            };

            return PartialView(ulazniPodaci);
        }

        public ActionResult ObrisiUcenika(int OdjeljenjeUcenikID)
        {
            OdjeljenjeUcenik ou = _context.OdjeljenjeUcenik.Find(OdjeljenjeUcenikID);
            int id = ou.OdjeljenjeID;
            try
            {
                //List<SlusaPredmet> lsp = _context.SlusaPredmet.Where(x => x.OdjeljenjeUcenikID == ou.ID).ToList();

                //foreach (SlusaPredmet sp in lsp) {

                //    List<Ocjena> lo = _context.Ocjena.Where(x => x.SlusaPredmetID == ou.ID).ToList();
                //    List<Izostanak> li = _context.Izostanak.Where(x => x.SlusaPredmetID == ou.ID).ToList();

                //    foreach (Ocjena o in lo) {
                //        _context.Ocjena.Remove(o);
                //    }
                //    foreach (Izostanak i in li)
                //    {
                //        _context.Izostanak.Remove(i);
                //    }

                //    _context.SlusaPredmet.Remove(sp);
                //}
                _context.OdjeljenjeUcenik.Remove(ou);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                TempData["greskaPoruka"] = "Nemoguće obrisat učenika!";
            }
            return RedirectToAction("Detalji","Odjeljenje", new { OdjeljenjeID = id });
        }

        public ActionResult DodajUcenika(int OdjeljenjeID)
        {
            OdjeljenjeDodajUrediUcenikaVM ulazniPodaci = new OdjeljenjeDodajUrediUcenikaVM
            {
                OdjeljenjeID = OdjeljenjeID,
                BrojUDnevniku = _context.OdjeljenjeUcenik.Count(x => x.OdjeljenjeID == OdjeljenjeID) + 1,
            };
            pripremiCmbStavke(ulazniPodaci);
            return PartialView("DodajUrediUcenika", ulazniPodaci);
        }

        public ActionResult UrediUcenika(int OdjeljenjeUcenikID)
        {
            OdjeljenjeUcenik o = _context.OdjeljenjeUcenik.Find(OdjeljenjeUcenikID);

            OdjeljenjeDodajUrediUcenikaVM ulazniPodaci = new OdjeljenjeDodajUrediUcenikaVM
            {
                OdjeljenjeUcenikID = o.ID,
                OdjeljenjeID = o.OdjeljenjeID,
                UcenikID = o.UcenikID,
                BrojUDnevniku = o.BrojUDnevniku
            };
            pripremiCmbStavke(ulazniPodaci);
            return PartialView("DodajUrediUcenika", ulazniPodaci);
        }


        private void pripremiCmbStavke(OdjeljenjeDodajUrediUcenikaVM ulazniPodaci)
        {
            //ulazniPodaci.Odjeljenja = _context.Odjeljenje.Select(od => new SelectListItem
            //{
            //    Value = od.ID.ToString(),
            //    Text = od.Oznaka
            //}).ToList();

            ulazniPodaci.Ucenici = _context.Ucenik.Select(u => new SelectListItem
            {
                Value = u.ID.ToString(),
                Text = u.Ime + " " + u.Prezime
            }).ToList();
        }

        public ActionResult SnimiUcenika(OdjeljenjeDodajUrediUcenikaVM input)
        {
            if (!ModelState.IsValid)
            {
                //pripremiCmbStavke(input);
                //return RedirectToAction("DodajUrediUcenika",input.OdjeljenjeUcenikID);
                TempData["greskaPoruka"] = "Nemoguće dodati učenika!";
                return RedirectToAction("Detalji", new { input.OdjeljenjeID });
            }
            

            OdjeljenjeUcenik odjeljenjeUcenik = _context.OdjeljenjeUcenik.Where(o => o.OdjeljenjeID == input.OdjeljenjeID && o.UcenikID == input.UcenikID).FirstOrDefault();
            if(odjeljenjeUcenik!= null && odjeljenjeUcenik.ID != input.OdjeljenjeUcenikID)
            {
                //pripremiCmbStavke(input);
                //return RedirectToAction("DodajUrediUcenika", input.OdjeljenjeUcenikID);
                TempData["greskaPoruka"] = "Učenik već dodan!";
                return RedirectToAction("Detalji", new { input.OdjeljenjeID });
            }

            OdjeljenjeUcenik o;
            if (input.OdjeljenjeUcenikID == 0)
            {
                o = new OdjeljenjeUcenik();
                _context.OdjeljenjeUcenik.Add(o);
            }
            else
            {
                o = _context.OdjeljenjeUcenik.Find(input.OdjeljenjeUcenikID);
            }
            o.OdjeljenjeID = input.OdjeljenjeID;
            o.UcenikID = input.UcenikID;
            o.BrojUDnevniku = input.BrojUDnevniku;
            _context.SaveChanges();

            
            List<OdjeljenjeUcenik> ucenici = _context.OdjeljenjeUcenik.Include(x => x.Ucenik)//rekonstrukcija brojeva
                .Where(u => u.OdjeljenjeID == o.OdjeljenjeID).ToList();

            ucenici = ucenici.OrderBy(o=>o.Ucenik.Prezime).ToList();
            
            for(int i=ucenici.Count()-1; i>=0; i--)
            {
                ucenici[i].BrojUDnevniku = i+1;
            }
            _context.SaveChanges();

            
            //if (input.OdjeljenjeUcenikID == 0)//Dodavanje predmeta novododanom uceniku
            //{
            //    OdjeljenjeUcenik novo = _context.OdjeljenjeUcenik.Include(x => x.Odjeljenje).Where(x => x.ID == o.ID).FirstOrDefault();

            //    List<Predaje> predajeLista = _context.Predaje.Where(x => x.OdjeljenjeID == novo.OdjeljenjeID).ToList();

            //    foreach (Predaje p in predajeLista)
            //    {
            //        SlusaPredmet zakljucna = new SlusaPredmet
            //        {
            //            OdjeljenjeUcenikID = novo.ID,
            //            PredajeID = p.ID,
            //            ZakljucnaOcjenaNaKraju = 0,
            //            ZakljucnaOcjenaNaPolugodistu = 0
            //        };
            //        _context.Add(zakljucna);
            //    }
            //    _context.SaveChanges();
            //}

            return RedirectToAction("Detalji",new{input.OdjeljenjeID});
        }
    }
}


                