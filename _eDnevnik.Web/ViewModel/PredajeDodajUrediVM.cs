using _eDnevnik.Data.EntityModel;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace _eDnevnik.Web.ViewModel
{
    public class PredajeDodajUrediVM
    {
        public int PredajeID { get; set; }

        [Required(ErrorMessage = "Zahtjevano polje!")]
        public int PredmetID { get; set; }
        public List<SelectListItem> Predmeti { get; set; }
        [Required(ErrorMessage = "Zahtjevano polje!")]
        public int ProfesorID { get; set; }
        public List<SelectListItem> Profesori { get; set; }
        [Required(ErrorMessage = "Zahtjevano polje!")]
        public int OdjeljenjeID { get; set; }
        public List<SelectListItem> Odjeljenja { get; set; }

    }
}
