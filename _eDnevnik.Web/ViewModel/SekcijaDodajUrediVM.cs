using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace _eDnevnik.Web.ViewModel
{
    public class SekcijaDodajUrediVM
    {
        public int SekcijaID { get; set; }
        [Required(ErrorMessage = "Zahtjevano polje!")]
        public string Naziv { get; set; }
        public string Napomena { get; set; }
        [Required(ErrorMessage = "Zahtjevano polje!")]
        public int KoordinatorID { get; set; }
        public List<SelectListItem> koordinatori { get; set; }
    }
}
