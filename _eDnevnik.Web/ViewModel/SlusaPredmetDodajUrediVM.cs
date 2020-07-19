using _eDnevnik.Data.EntityModel;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace _eDnevnik.Web.ViewModel
{
    public class SlusaPredmetDodajUrediVM
    {
        [Required(ErrorMessage = "Zahtjevano polje!")]
        public int OdjeljenjeUcenikID { get; set; }
        public List<SelectListItem> OdjeljenjeUcenik { get; set; }

        [Required(ErrorMessage = "Zahtjevano polje!")]
        public int PredajeID { get; set; }
        public List<SelectListItem> Predaje { get; set; }

        public int SlusaPredmetID { get; set; }

        [Range(0, 5, ErrorMessage = "Brojevi od 1 - 5!")]
        public int ZakljucnaOcjenaNaPolugodistu { get; set; }

        [Range(0, 5, ErrorMessage = "Brojevi od 1 - 5!")]
        public int ZakljucnaOcjenaNaKraju { get; set; }
    }
}
