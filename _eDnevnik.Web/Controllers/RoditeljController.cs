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
    public class RoditeljController : Controller
    {
        [Obsolete]
        private readonly IHostingEnvironment hostingEnvironment;
        private MyDbContext _context;
       
        [Obsolete]
        public RoditeljController(MyDbContext context, IHostingEnvironment en)
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


        public ActionResult Prikaz()
        {
            RoditeljPrikazVM ulazniPodaci = new RoditeljPrikazVM
           {
                ListaRoditelja = _context.Roditelj.Select(
                    o => new RoditeljPrikazVM.Rows
                    {
                        RoditeljID = o.ID,
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
        public ActionResult DodajUredi(int RoditeljID)
        {
            RoditeljDodajUrediVM ulazniPodaci = new RoditeljDodajUrediVM();
            if (RoditeljID != 0)
            {
               Roditelj r = _context.Roditelj.Find(RoditeljID);
                ulazniPodaci.RoditeljID = r.ID;
                ulazniPodaci.Ime = r.Ime;
                ulazniPodaci.Prezime = r.Prezime;
                ulazniPodaci.DatumRodjenja = r.DatumRodjenja;
                ulazniPodaci.JMBG = r.JMBG;
                ulazniPodaci.Telefon = r.Telefon;
                ulazniPodaci.Email = r.Email;
                ulazniPodaci.Spol = r.Spol;
                ulazniPodaci.OpcinaID = r.OpcinaID;
                ulazniPodaci.LoginID = r.LoginID;
                ulazniPodaci.NazivSlike = r.NazivSlike;
            }

            pripremiCmbStavke(ulazniPodaci);
            return View(ulazniPodaci);
        }

        private void pripremiCmbStavke(RoditeljDodajUrediVM ulazniPodaci) {
            ulazniPodaci.Opcina = _context.Opcina.Select(s => new SelectListItem
            {
                Value = s.ID.ToString(),
                Text = s.Naziv
            }).ToList();

            /*ulazniPodaci.Login = _context.Login.Select(s => new SelectListItem
            {
                Value = s.ID.ToString(),
                Text = (s.KorisnickoIme ?? "KorisnickoIme")
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
        public ActionResult Snimi(RoditeljDodajUrediVM input)
        {
            if (!ModelState.IsValid)
            {
                pripremiCmbStavke(input);
                return View("DodajUredi", input);
            }

            Roditelj o;
            if (input.RoditeljID == 0)
            {
                o = new Roditelj();
                _context.Add(o);
            }
            else
            {
                o = _context.Roditelj.Find(input.RoditeljID);
            }
            
            if (input.MyImage != null)
            {
                var uniqueFileName = GetUniqueFileName(input.MyImage.FileName);
                var uploads = Path.Combine(hostingEnvironment.WebRootPath, "uploads");
                var filePath = Path.Combine(uploads, uniqueFileName);
                input.MyImage.CopyTo(new FileStream(filePath, FileMode.Create));

                o.NazivSlike = uniqueFileName;
            }

            o.Ime = input.Ime;
            o.Prezime = input.Prezime;
            o.Spol = input.Spol;
            o.DatumRodjenja = input.DatumRodjenja;
            o.JMBG = input.JMBG;
            o.Telefon = input.Telefon;
            o.Email = input.Email;
            o.OpcinaID = input.OpcinaID;
            o.LoginID = input.LoginID;
            _context.SaveChanges();

            /*string telefon = input.Telefon;
            Login login = _context.Login.Where(o => o.ID == input.LoginID).FirstOrDefault();
            string sadrzaj = "Korisnicko ime je: " + login.KorisnickoIme+", " + "sifra je: " + login.Sifra+".";

            return RedirectToAction("PosaljiSMS","SMS", new {to=telefon, text=sadrzaj });*/ //NE DIRATI

            if (input.Email != null)
            {
                Login login = _context.Login.Find(input.LoginID);
                EmailController.SendEmail(input.Email, "Korisnički podaci", "Korisnčko ime: " + login.KorisnickoIme + " Šifra: " + login.Sifra);
            }

            return RedirectToAction("Prikaz");
        }
        public ActionResult Obrisi(int RoditeljID)
        {
            try
            {
                Roditelj o = _context.Roditelj.Find(RoditeljID);
                _context.Roditelj.Remove(o);
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