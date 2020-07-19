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
    public class RoditeljDodajUrediVM
    {

        public int RoditeljID { get; set; }

        [Required(ErrorMessage = "Zahtjevano polje.")]
        public string Ime { get; set; }
        
        [Required(ErrorMessage = "Zahtjevano polje.")]
        public string Prezime { get; set; }
        
        [Required(ErrorMessage = "Zahtjevano polje.")]
        public DateTime DatumRodjenja { get; set; }
        
        [Required(ErrorMessage = "Zahtjevano polje.")]
        [RegularExpression(@"^\d{13}$", ErrorMessage = "Nepravilan izraz")]
        public string JMBG { get; set; }

        [Required(ErrorMessage ="Morate unijeti telefon.")]
        [Phone(ErrorMessage = "Neispravan format")]
        public string Telefon { get; set; }

        [Required(ErrorMessage = "Morate unijeti email.")]
        [EmailAddress(ErrorMessage = "Neispravan format")]
        public string Email { get; set; }
        
        [Required(ErrorMessage = "Zahtjevano polje.")]
        public string Spol { get; set; }

        [Required(ErrorMessage = "Zahtjevano polje.")]
        public int OpcinaID { get; set; }
        public List<SelectListItem> Opcina { get; set; }

        [Required(ErrorMessage = "Zahtjevano polje.")]
        public int LoginID { get; set; }
        public List<SelectListItem> Login { get; set; }

        public IFormFile MyImage { get; set; }
        public string NazivSlike { get; set; }

    }
}
