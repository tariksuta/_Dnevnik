using _eDnevnik.Data.EntityModel;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace _eDnevnik.Web.ViewModel
{
    public class SjednicaDodajUrediVM
    {
        [Required(ErrorMessage = "Zahtjevano polje!")]
        public int SkolskaGodinaID { get; set; }
        public List<SelectListItem> SkolskeGodine { get; set; }

        public int SjednicaID { get; set; }
        [Required(ErrorMessage = "Zahtjevano polje!")]
        public DateTime DatumOdrzavanja { get; set; }
        [Required(ErrorMessage = "Zahtjevano polje!")]
        public string Naziv { get; set; }
    }
}
