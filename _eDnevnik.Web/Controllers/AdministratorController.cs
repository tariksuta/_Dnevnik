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
using Microsoft.EntityFrameworkCore;

namespace _eDnevnik.Web.Controllers
{
    [Autorizacija(roditelj: false, profesor: false, administrator: true)]//iznad klase odnosi se na sve akcije
    public class AdministratorController : Controller
    {
        [Obsolete]
        private readonly IHostingEnvironment hostingEnvironment;
        private MyDbContext _context;
       
        [Obsolete]
        public AdministratorController(MyDbContext context, IHostingEnvironment en)
        {
            _context = context;
            hostingEnvironment = en;
        }
        public IActionResult LicniPrikaz()
        {
            Administrator ulazniPodaci = _context.Administrator.Include(o => o.Opcina).Where(o => o.LoginID == HttpContext.GetLogiraniKorisnik().ID).FirstOrDefault();
            return View(ulazniPodaci);
        }
        private string GetUniqueFileName(string fileName)
        {
            fileName = Path.GetFileName(fileName);
            return Path.GetFileNameWithoutExtension(fileName)
                      + "_"
                      + Guid.NewGuid().ToString().Substring(0, 4)
                      + Path.GetExtension(fileName);
        }


        public ActionResult Prikaz()
        {
            AdministratorPrikazVM ulazniPodaci = new AdministratorPrikazVM
            {
                ListaAdministratora = _context.Administrator.Select(
                    o => new AdministratorPrikazVM.Rows
                    {
                        AdministratorID = o.ID,
                        Ime = o.Ime,
                        Prezime = o.Prezime,
                        Spol = o.Spol,
                        DatumRodjenja = o.DatumRodjenja,
                        JMBG = o.JMBG,
                        Telefon = o.Telefon,
                        Email = o.Email,
                        Opcina = o.Opcina.Naziv,
                        Login = o.Login.KorisnickoIme,
                        NazivSlike = o.NazivSlike
                    }
                ).ToList()
            };
            return View(ulazniPodaci);
        }

        public ActionResult DodajUredi(int AdministratorID)
        {
            AdministratorDodajUrediVM ulazniPodaci = new AdministratorDodajUrediVM();
            Administrator administrator = _context.Administrator.Find(AdministratorID);
            if (administrator != null)
            {
                ulazniPodaci.ID = administrator.ID;
                ulazniPodaci.Ime = administrator.Ime;
                ulazniPodaci.Prezime = administrator.Prezime;
                ulazniPodaci.DatumRodjenja = administrator.DatumRodjenja;
                ulazniPodaci.JMBG = administrator.JMBG;
                ulazniPodaci.Spol = administrator.Spol;
                ulazniPodaci.Telefon = administrator.Telefon;
                ulazniPodaci.Email = administrator.Email;
                ulazniPodaci.LoginID = administrator.LoginID;
                ulazniPodaci.OpcinaID = administrator.OpcinaID;
                ulazniPodaci.NazivSlike = administrator.NazivSlike;

            }

            PripremiCmbStavke(ulazniPodaci);
            return View(ulazniPodaci);
        }

        private void PripremiCmbStavke(AdministratorDodajUrediVM ulazniPodaci)
        {
            ulazniPodaci.Opcina = _context.Opcina.Select(s => new SelectListItem
            {
                Value = s.ID.ToString(),
                Text = s.Naziv
            }).ToList();

            /*ulazniPodaci.Login = _context.Login.Select(s => new SelectListItem
            {
                Value = s.ID.ToString(),
                Text = (s.KorisnickoIme ?? "KorisnickoIme")//Ako nema napisi "..."
            }).ToList();*/

            List<Login> listaLogina = _context.Login.ToList();
            ulazniPodaci.Login = new List<SelectListItem>();

            foreach (Login l in listaLogina)
            {
                Roditelj u = _context.Roditelj.Where(o => o.LoginID == l.ID).FirstOrDefault();
                Profesor p = _context.Profesor.Where(o => o.LoginID == l.ID).FirstOrDefault();
                Administrator a = _context.Administrator.Where(o => o.LoginID == l.ID).FirstOrDefault();
                if (u == null && p == null && a == null)
                {
                    ulazniPodaci.Login.Add(new SelectListItem
                    {
                        Value = l.ID.ToString(),
                        Text = (l.KorisnickoIme ?? "KorisnickoIme")
                    });
                }
            }
            if (ulazniPodaci.LoginID != 0)
            {
                ulazniPodaci.Login.Add(new SelectListItem
                {
                    Value = ulazniPodaci.LoginID.ToString(),
                    Text = "Trenutni Login"
                });
            }
        }

        [Obsolete]
        public ActionResult Snimi(AdministratorDodajUrediVM ulazniPodaci)
        {
            if (!ModelState.IsValid)
            {
                PripremiCmbStavke(ulazniPodaci);
                return View("DodajUredi", ulazniPodaci);
            }

            Administrator o;
            if (ulazniPodaci.ID == 0)
            {
                o = new Administrator();
                _context.Add(o);
            }
            else
            {
                o = _context.Administrator.Find(ulazniPodaci.ID);
            }

            if (ulazniPodaci.MyImage != null)
            {
                var uniqueFileName = GetUniqueFileName(ulazniPodaci.MyImage.FileName);
                var uploads = Path.Combine(hostingEnvironment.WebRootPath, "uploads");
                var filePath = Path.Combine(uploads, uniqueFileName);
                ulazniPodaci.MyImage.CopyTo(new FileStream(filePath, FileMode.Create));

                o.NazivSlike = uniqueFileName;
            }

            o.Ime = ulazniPodaci.Ime;
            o.Prezime = ulazniPodaci.Prezime;
            o.Spol = ulazniPodaci.Spol;
            o.DatumRodjenja = ulazniPodaci.DatumRodjenja;
            o.JMBG = ulazniPodaci.JMBG;
            o.Telefon = ulazniPodaci.Telefon;
            o.Email = ulazniPodaci.Email;
            o.OpcinaID = ulazniPodaci.OpcinaID;
            o.LoginID = ulazniPodaci.LoginID;
            _context.SaveChanges();

            /*string telefon = input.Telefon;
            Login login = _context.Login.Where(o => o.ID == input.LoginID).FirstOrDefault();
            string sadrzaj = "Korisnicko ime je: " + login.KorisnickoIme+", " + "sifra je: " + login.Sifra+".";

            return RedirectToAction("PosaljiSMS","SMS", new {to=telefon, text=sadrzaj });*/ //NE DIRATI

            //if (ulazniPodaci.Email != null)
            //{
            //    Login login = _context.Login.Find(ulazniPodaci.LoginID);
            //    EmailController.SendEmail(ulazniPodaci.Email, "Korisnički podaci", "Korisnčko ime: " + login.KorisnickoIme + " Šifra: " + login.Sifra);
            //}
            return RedirectToAction("Prikaz");
        }

        public ActionResult Obrisi(int AdministratorID)
        {
            Administrator o = _context.Administrator.Find(AdministratorID);
            try
            {
                _context.Administrator.Remove(o);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                TempData["greskaPoruka"] = "Nije moguce obrisati administratora!";
            }
            return RedirectToAction("Prikaz");

        }

    }
}