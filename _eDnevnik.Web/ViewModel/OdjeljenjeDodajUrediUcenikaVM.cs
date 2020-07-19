using _eDnevnik.Data.EntityModel;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace _eDnevnik.Web.ViewModel
{
    public class OdjeljenjeDodajUrediUcenikaVM
    {
        public int OdjeljenjeUcenikID { get; set; }

        [Required(ErrorMessage = "Zahtijevano polje.")]
        public int OdjeljenjeID { get; set; }
        //public List<SelectListItem> Odjeljenja { get; set; }


        [Required(ErrorMessage = "Zahtijevano polje.")]
        public int UcenikID { get; set; }
        public List<SelectListItem> Ucenici { get; set; }


        [Required(ErrorMessage = "Zahtijevano polje.")]
        public int BrojUDnevniku { get; set; }
    }
}

