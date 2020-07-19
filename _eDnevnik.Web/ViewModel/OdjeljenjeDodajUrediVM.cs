using _eDnevnik.Data.EntityModel;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace _eDnevnik.Web.ViewModel
{
    public class OdjeljenjeDodajUrediVM
    {
        public int OdjeljenjeID { get; set; }

        [Required(ErrorMessage = "Zahtjevano polje.")]
        [Range(1,9, ErrorMessage = "Unesite broj 1-9")]
        public int Razred { get; set; }

        [Required(ErrorMessage = "Zahtjevano polje.")]
        [RegularExpression(@"^\d{1}-[a-z1-9]{1}$", ErrorMessage = "Nepravilan izraz")]
        public string Oznaka { get; set; }

        public bool PrebacenUViseOdjeljenje { get; set; }

        [Required(ErrorMessage = "Zahtjevano polje.")]
        public int SkolskaGodinaID { get; set; }
        public List<SelectListItem> SkolskeGodine { get; set; }

        [Required(ErrorMessage = "Zahtjevano polje.")]
        public int RazrednikID { get; set; }
        public List<SelectListItem> Razrednici { get; set; }

        [Required(ErrorMessage = "Zahtjevano polje.")]
        public int SmjerID { get; set; }
        public List<SelectListItem> Smjerovi { get; set; }

        public int prebacenoOdjeljenjeID { get; set; }
        public List<SelectListItem> OdjeljenjaZaPrebaciti { get; set; }
    }
}