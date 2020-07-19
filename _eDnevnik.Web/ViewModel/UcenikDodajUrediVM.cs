using _eDnevnik.Data.EntityModel;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace _eDnevnik.Web.ViewModel
{
    public class UcenikDodajUrediVM
    {
        public int UcenikID { get; set; }
        
        [Required(ErrorMessage = "Zahtjevano polje.")]
        public string Ime { get; set; }

        [Required(ErrorMessage = "Zahtjevano polje.")]
        public string Prezime { get; set; }
        
        [Required(ErrorMessage = "Zahtjevano polje.")]
        public string Spol { get; set; }
 
        [Required(ErrorMessage = "Zahtjevano polje.")]
        public DateTime DatumRodjenja { get; set; }

        [Required(ErrorMessage = "Zahtjevano polje.")]
        [RegularExpression(@"^\d{13}$", ErrorMessage = "Nepravilan izraz")]
        public string JMBG { get; set; }

        [Required(ErrorMessage = "Zahtjevano polje.")]
        public int RoditeljID { get; set; }
        public List<SelectListItem> Roditelj { get; set; }

        [Required(ErrorMessage = "Zahtjevano polje.")]
        public int VladanjeID { get; set; }
        public List<SelectListItem> Vladanje { get; set; }

        [Required(ErrorMessage = "Zahtjevano polje.")]
        public int OpcinaID { get; set; }
        public List<SelectListItem> Opcina { get; set; }
    }
}
