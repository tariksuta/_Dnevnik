using _eDnevnik.Data;
using _eDnevnik.Data.EntityModel;
using _eDnevnik.Web.Helper;
using _eDnevnik.Web.ViewModel;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace _eDnevnik.Web.Controllers
{
    [Autorizacija(roditelj: false, profesor: false, administrator: true)]
    public class ProfesorController : Controller
    {
        [Obsolete]
        private readonly IHostingEnvironment hostingEnvironment;
        private MyDbContext _context;
        [Obsolete]
        public ProfesorController(MyDbContext db, IHostingEnvironment en)
        {
            _context = db;
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

            ProfesoraPrikazVM ulazniPodaci = new ProfesoraPrikazVM
            {

                Profesori = _context.Profesor.Select(p => new ProfesoraPrikazVM.Row
                {
                    ProfesorID = p.ID,
                    Ime = p.Ime,
                    Spol = p.Spol,
                    Prezime = p.Prezime,
                    JMBG = p.JMBG,
                    DatumRodjenja = p.DatumRodjenja.ToString().Substring(0, 11),
                    Opcina = p.Opcina.Naziv,
                    RasporedKonsultacija = p.RasporedKonsultacija.Napomena,
                    OdjeljenjeID = (_context.Odjeljenje.Where(x => x.RazrednikID == p.ID).FirstOrDefault().ID != 0 ? _context.Odjeljenje.Where(x => x.RazrednikID == p.ID).FirstOrDefault().ID : 0),
                    NazivSlike = p.NazivSlike
                }).ToList()
            };


            return View(ulazniPodaci);
        }

        public IActionResult DodajUredi(int ProfesorID)
        {

            ProfesorDodajUrediVM ulazniPodaci;
            Profesor x;
            if (ProfesorID == 0)
            {
                ulazniPodaci = new ProfesorDodajUrediVM();
                ulazniPodaci.DatumRodjenja = new DateTime(2000, 01, 01);
            }
            else
            {
                x = _context.Profesor.Find(ProfesorID);
                ulazniPodaci = new ProfesorDodajUrediVM
                {
                    ProfesorID = x.ID,
                    Ime = x.Ime,
                    Prezime = x.Prezime,
                    Spol = x.Spol,
                    DatumRodjenja = x.DatumRodjenja,
                    JMBG = x.JMBG,
                    Telefon = x.Telefon,
                    Email = x.Email,
                    OpcineID = x.OpcinaID,
                    RasporedKonsultacijaID = x.RasporedKonsultacijaID,
                    LoginID = x.LoginID,
                    NazivSlike = x.NazivSlike
            };
            }
            PiripremiCmbStavke(ulazniPodaci);

            return View(ulazniPodaci);
        }
        private void PiripremiCmbStavke(ProfesorDodajUrediVM ulazniPodaci)
        {

            ulazniPodaci.Opcine = _context.Opcina.Select(x => new SelectListItem
            {
                Value = x.ID.ToString(),
                Text = x.Naziv
            }).ToList();

            ulazniPodaci.RasporedKonsultacija = _context.RasporedKonsultacija.Select(x => new SelectListItem
            {
                Value = x.ID.ToString(),
                Text = x.Napomena
            }).ToList();

            /*ulazniPodaci.Login = _context.Login.Select(x => new SelectListItem
            {
                Value = x.ID.ToString(),
                Text = x.KorisnickoIme
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
        public IActionResult Snimi(ProfesorDodajUrediVM x)
        {
            if (!ModelState.IsValid)
            {
                PiripremiCmbStavke(x);
                return View("DodajUredi", x);
            }
            Profesor p1;
            if (x.ProfesorID == 0)
            {
                p1 = new Profesor();
                _context.Add(p1);
            }
            else
            {
                p1 = _context.Profesor.Find(x.ProfesorID);
            }
            if (x.MyImage != null)
            {
                var uniqueFileName = GetUniqueFileName(x.MyImage.FileName);
                var uploads = Path.Combine(hostingEnvironment.WebRootPath, "uploads");
                var filePath = Path.Combine(uploads, uniqueFileName);
                x.MyImage.CopyTo(new FileStream(filePath, FileMode.Create));

                p1.NazivSlike = uniqueFileName;
            }

            p1.Ime = x.Ime;
            p1.Prezime = x.Prezime;
            p1.DatumRodjenja = x.DatumRodjenja;
            p1.JMBG = x.JMBG;
            p1.Telefon = x.Telefon;
            p1.Email = x.Email;
            p1.OpcinaID = x.OpcineID;
            p1.RasporedKonsultacijaID = x.RasporedKonsultacijaID;
            p1.LoginID = x.LoginID;

            _context.SaveChanges();

            /*string telefon = input.Telefon;
            Login login = _context.Login.Where(o => o.ID == input.LoginID).FirstOrDefault();
            string sadrzaj = "Korisnicko ime je: " + login.KorisnickoIme+", " + "sifra je: " + login.Sifra+".";
            return RedirectToAction("PosaljiSMS","SMS", new {to=telefon, text=sadrzaj });*/ //NE DIRATI

            //if (x.Email != null)
            //{
            //    Login login = _context.Login.Find(x.LoginID);
            //    EmailController.SendEmail(x.Email, "Korisnički podaci", "Korisnčko ime: " + login.KorisnickoIme + " Šifra: " + login.Sifra);
            //}
            return RedirectToAction("Prikaz");
        }

        public ActionResult Obrisi(int ProfesorID)
        {
            try
            {
                Profesor o = _context.Profesor.Find(ProfesorID);
                _context.Profesor.Remove(o);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                TempData["greskaPoruka"] = "Nemoguće obrisati roditelja!";
            }
            return RedirectToAction("Prikaz");
        }
    }
}
