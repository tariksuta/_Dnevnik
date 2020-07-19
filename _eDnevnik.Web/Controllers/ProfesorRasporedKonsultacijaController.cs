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
   [Autorizacija(false,true,false)]
        public class ProfesorRasporedKonsultacijaController : Controller
        {
        [Obsolete]
        private readonly IHostingEnvironment hostingEnvironment;
        private MyDbContext _context;

        [Obsolete]
        public ProfesorRasporedKonsultacijaController(MyDbContext db,IHostingEnvironment en)
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
                RasporedKonsultacijaDodajUrediVM Model;
                RasporedKonsultacija rk;
                if (RasporedKID == 0)
                {
                    Model = new RasporedKonsultacijaDodajUrediVM();
               
                }
                else
                {
                    rk = _context.RasporedKonsultacija.Find(RasporedKID);
                    Model = new RasporedKonsultacijaDodajUrediVM
                    {
                        RasporedKID = rk.ID,
                        Napomena = rk.Napomena,
                        RasporedFile = rk.RasporedFile,
                        SkolskaGodinaID = rk.SkolskaGodinaID,
                        imefajla = rk.imefajla
                    };
                }

                Model.SkolskeGodine = _context.SkolskaGodina.Select(x => new SelectListItem
                {
                    Value = x.ID.ToString(),
                    Text = x.Naziv
                }).ToList();
                return View(Model);
            }

        [Obsolete]
        public IActionResult Snimi(RasporedKonsultacijaDodajUrediVM x)
            {

            try
            {
                RasporedKonsultacija rk;
                if (x.RasporedKID == 0)
                {
                    rk = new RasporedKonsultacija();
                    _context.Add(rk);
                }
                else
                {
                    rk = _context.RasporedKonsultacija.Find(x.RasporedKID);

                }

                if (x.MyImage != null)
                {
                    var uniqueFileName = KonvertUpload.JedinstvenNaziv(x.MyImage.FileName);
                    var uploads = Path.Combine(hostingEnvironment.WebRootPath, "uploads");
                    var filePath = Path.Combine(uploads, uniqueFileName);
                    x.MyImage.CopyTo(new FileStream(filePath, FileMode.Create));

                    //spasi naziv fajla
                    rk.imefajla = uniqueFileName;
                }

                rk.Napomena = x.Napomena;
                rk.RasporedFile = x.RasporedFile;
                rk.SkolskaGodinaID = x.SkolskaGodinaID;
                Profesor p = _context.Profesor.Where(l => l.LoginID == HttpContext.GetLogiraniKorisnik().ID).FirstOrDefault();
                   _context.SaveChanges();
                p.RasporedKonsultacijaID = rk.ID;

                _context.SaveChanges();
                var emailProfesor = p.Email;
                // kada bi slali mail profesoru
               // EmailController.SendEmail(emailProfesor, "Dodavanje rasporeda", "Dodali ste novi raspored");
                EmailController.SendEmail("tariksuta0@gmail.com", "Dodavanje rasporeda", "Dodali ste novi raspored");
                return RedirectToAction("Prikaz");
            }
            catch(Exception e)
            {
                EmailController.SendEmail("tariksuta0@gmail.com", "Dodavanje rasporeda", "Problem prilikom dodavanja");
                return RedirectToAction("Index", "Home");
            }
               
            }
            public IActionResult Obrisi(int RasporedKID)
            {

                RasporedKonsultacija rk = _context.RasporedKonsultacija.Find(RasporedKID);
                _context.Remove(rk);
                _context.SaveChanges();
                return RedirectToAction("Prikaz");
            }
        }
        
}