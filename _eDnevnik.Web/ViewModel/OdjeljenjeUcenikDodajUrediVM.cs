using _eDnevnik.Data.EntityModel;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace _eDnevnik.Web.ViewModel
{
    public class OdjeljenjeUcenikDodajUrediVM
    {

        [Required(ErrorMessage = "Zahtjevano polje.")]
        public int OdjeljenjeUcenikID { get; set; }
        public List<SelectListItem> Odjeljenje { get; set; }
        
        [Required(ErrorMessage = "Zahtjevano polje.")]
        public int OdjeljenjeID { get; set; }
        public List<SelectListItem> Ucenik { get; set; }
        public int UcenikID { get; set; }
        
        [Required(ErrorMessage = "Zahtjevano polje.")]
        [Range(1,100)]
        public int BrojUDnevniku { get; set; }
    }
}
