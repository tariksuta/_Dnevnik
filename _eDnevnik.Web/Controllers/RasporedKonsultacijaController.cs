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
    [Autorizacija(roditelj: false, profesor: true, administrator: true)]
    public class RasporedKonsultacijaController : Controller
        {
        [Obsolete]
        private readonly IHostingEnvironment hostingEnvironment;
        private MyDbContext _context;

        [Obsolete]
        public RasporedKonsultacijaController(MyDbContext db,IHostingEnvironment en)
            {
                _context = db;
                hostingEnvironment = en;
            }
    
      
    

       
        public IActionResult Prikaz()
            {
                RasporedKonsultacijaPrikazVM Model = new RasporedKonsultacijaPrikazVM
                {
                    rasporedi = _context.RasporedKonsultacija.Select(x => new RasporedKonsultacijaPrikazVM.Row
                    {
                        RasporedKID = x.ID,
                        Napomena = x.Napomena,
                        SkolskaGodinaID = x.SkolskaGodinaID,
                        SkolskaGodina = x.SkolskaGodina.Naziv,
                        imefajla = x.imefajla
                    }).ToList()
                };
                return View(Model);
            }

            public IActionResult DodajUredi(int RasporedKID)
            {
                RasporedKonsultacijaDodajUrediVM ulazniPodaci= new RasporedKonsultacijaDodajUrediVM();
                if (RasporedKID != 0)
                {
                    RasporedKonsultacija rk = _context.RasporedKonsultacija.Find(RasporedKID);
                ulazniPodaci = new RasporedKonsultacijaDodajUrediVM
                    {
                        RasporedKID = rk.ID,
                        Napomena = rk.Napomena,
                        RasporedFile = rk.RasporedFile,
                        SkolskaGodinaID = rk.SkolskaGodinaID,
                        imefajla = rk.imefajla
                    };
                }
                pripremiCmbStavke(ulazniPodaci);
                return View(ulazniPodaci);
            }
        private void pripremiCmbStavke(RasporedKonsultacijaDodajUrediVM ulazniPodaci)
        {
            ulazniPodaci.SkolskeGodine = _context.SkolskaGodina.Select(x => new SelectListItem
            {
                Value = x.ID.ToString(),
                Text = x.Naziv
            }).ToList();
        }

        [Obsolete]
        public IActionResult Snimi(RasporedKonsultacijaDodajUrediVM input)
         {
            if (!ModelState.IsValid)
            {
                pripremiCmbStavke(input);
                return View("DodajUredi", input);
            }

            RasporedKonsultacija rk;
                if (input.RasporedKID == 0)
                {
                    rk = new RasporedKonsultacija();
                    _context.Add(rk);
                }
                else
                {
                    rk = _context.RasporedKonsultacija.Find(input.RasporedKID);

                }
           
            if (input.MyImage != null)
            {
                var uniqueFileName = KonvertUpload.JedinstvenNaziv(input.MyImage.FileName);
                var uploads = Path.Combine(hostingEnvironment.WebRootPath, "uploads");
                var filePath = Path.Combine(uploads,uniqueFileName);
                input.MyImage.CopyTo(new FileStream(filePath, FileMode.Create));

                //spasi naziv fajla
                rk.imefajla = uniqueFileName;
            }

            rk.Napomena = input.Napomena;
                rk.RasporedFile = input.RasporedFile;
                rk.SkolskaGodinaID = input.SkolskaGodinaID;

                _context.SaveChanges();
                return RedirectToAction("Prikaz");
            }
            public IActionResult Obrisi(int RasporedKID)
            {
            try
            {
                RasporedKonsultacija rk = _context.RasporedKonsultacija.Find(RasporedKID);
                _context.Remove(rk);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                TempData["greskaPoruka"] = "Nemoguće obrisati raspored!";
            }

            return RedirectToAction("Prikaz");
            }
        }
        
}