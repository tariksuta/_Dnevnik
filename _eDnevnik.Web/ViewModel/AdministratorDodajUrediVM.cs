using _eDnevnik.Data.EntityModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace _eDnevnik.Web.ViewModel
{
    public class AdministratorDodajUrediVM
    {
        [Required(ErrorMessage = "Niste unijeli općinu.")]
        public int OpcinaID { get; set; }
        public List<SelectListItem> Opcina { get; set; }

        [Required(ErrorMessage = "Niste unijeli login.")]
        public int LoginID { get; set; }
        public List<SelectListItem> Login { get; set; }

        public int ID { get; set; }

        [Required(ErrorMessage = "Niste unijeli ime.")]
        public string Ime { get; set; }

        [Required(ErrorMessage = "Niste unijeli prezime.")]
        public string Prezime { get; set; }

        [Required(ErrorMessage = "Niste unijeli datum rođenja.")]
        public DateTime DatumRodjenja { get; set; }

        [Required(ErrorMessage = "Niste unijeli 13 cifara.")]
        [RegularExpression(@"^[0-9]{13}$")]
        public string JMBG { get; set; }

        [Required(ErrorMessage = "Niste unijeli telefon.")]
        [RegularExpression(@"[0-9]{1,}$")]
        public string Telefon { get; set; }

        [Required(ErrorMessage = "Niste unijeli email.")]
        [RegularExpression(@"[A-Za-z0-9]{1,}\.[A-Za-z0-9]{1,}\@[A-Za-z]{1,}\.[A-Za-z]{1,}\.[A-Za-z]{1,}$",
            ErrorMessage = "Niste unijeli ispravan format email-a.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Niste unijeli spol (M/Ž).")]
        [RegularExpression(@"[MŽ]$", ErrorMessage = "Niste unijeli M/Ž.")]
        public string Spol { get; set; }

        public IFormFile MyImage { get; set; }
        public string NazivSlike { get; set; }
    }
}
