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
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace _eDnevnik.Web.Controllers
{
    [Autorizacija(roditelj: false, profesor: false, administrator: true)]

    public class ZapisnikController : Controller
    {
        [Obsolete]
        private readonly IHostingEnvironment hostingEnvironment;
        private MyDbContext _context;

        [Obsolete]
        public ZapisnikController(MyDbContext context, IHostingEnvironment en)
        {
            _context = context;
            hostingEnvironment = en;
        }

        private string GetUniqueFileName(string fileName)
        {
            fileName = Path.GetFileName(fileName);
            return Path.GetFileNameWithoutExtension(fileName)
                      + "_"
                      + Guid.NewGuid().ToString().Substring(0, 4)
                      + Path.GetExtension(fileName);
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
                        Sjednica = z.Sjednica.Naziv,
                        imefajla = z.imefajla
                    }
                ).ToList()
            };
            return View(ulazniPodaci);
        }

        public IActionResult DodajUredi(int ZapisnikID)
        {
            ZapisnikDodajUrediVM ulazniPodaci = new ZapisnikDodajUrediVM();
            if (ZapisnikID != 0)
            {
             Zapisnik z = _context.Zapisnik.Find(ZapisnikID);
                ulazniPodaci.ZapisnikID = z.ID;
                ulazniPodaci.Sadrzaj = z.Sadrzaj;
                ulazniPodaci.Napomena = z.Napomena;
                ulazniPodaci.AutorID = z.AutorID;
                ulazniPodaci.SjednicaID = z.SjednicaID;
                ulazniPodaci.imefajla = z.imefajla;
            }
            pripremiCmbStavke(ulazniPodaci);    
            return View(ulazniPodaci);
        }

        private void pripremiCmbStavke(ZapisnikDodajUrediVM ulazniPodaci)
        {
            ulazniPodaci.Autori = _context.Administrator.Select(
                   a => new SelectListItem
                   {
                       Value = a.ID.ToString(),
                       Text = a.Ime + " " + a.Prezime
                   }
                   ).ToList();

            ulazniPodaci.Sjednice = _context.Sjednica.Select(
                   a => new SelectListItem
                   {
                       Value = a.ID.ToString(),
                       Text = a.Naziv
                   }
                   ).ToList();
        }

            public IActionResult Detalji(int ZapisnikID)
        {
            Zapisnik zapisnik = _context.Zapisnik.Find(ZapisnikID);
            return View(zapisnik);
        }

        [Obsolete]
        public IActionResult Snimi(ZapisnikDodajUrediVM input)
        {
            if (!ModelState.IsValid)
            {
                pripremiCmbStavke(input);
                return View("DodajUredi", input);
            }

            Zapisnik z;
            if (input.ZapisnikID == 0)
            {
                z = new Zapisnik();
                _context.Add(z);
            }
            else
            {
                z = _context.Zapisnik.Find(input.ZapisnikID);
            }

            if (input.MyImage != null)
            {
                var uniqueFileName = GetUniqueFileName(input.MyImage.FileName);
                var uploads = Path.Combine(hostingEnvironment.WebRootPath, "uploads");
                var filePath = Path.Combine(uploads, uniqueFileName);
                input.MyImage.CopyTo(new FileStream(filePath, FileMode.Create));

                z.imefajla = uniqueFileName;
            }

            z.RasporedFile = input.RasporedFile;
            z.Napomena = input.Napomena;
            z.Sadrzaj = input.Sadrzaj;
            z.AutorID = input.AutorID;
            z.SjednicaID = input.SjednicaID;
            try
            {
                _context.SaveChanges();
            }
            catch (Exception)
            {
                TempData["greskaPoruka"] = "Nemoguće dodati zapisnik!";
            }
            return Redirect("Prikaz");
        }

        public IActionResult Obrisi(int ZapisnikID)
        {
            try
            {
                Zapisnik smjer = _context.Zapisnik.Find(ZapisnikID);
                _context.Zapisnik.Remove(smjer);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                TempData["greskaPoruka"] = "Nemoguće obrisati zapisnik!";
            }

            return Redirect("Prikaz");
        }
    }
}