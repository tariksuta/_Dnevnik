using _eDnevnik.Data.EntityModel;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace _eDnevnik.Web.ViewModel
{
    public class ProfesorSlusaPredmetDodajUrediVM
    {
        public List<SelectListItem> OdjeljenjeUcenik { get; set; }
        public List<SelectListItem> Predaje { get; set; }


        public int SlusaPredmetID { get; set; }

        public int OdjeljenjeUcenikID { get; set; }

        public int PredajeID { get; set; }

        [Required(ErrorMessage = "Zahtjevano polje.")]
        [Range(1, 5, ErrorMessage = "Ocjene od 1 do 5")]
        public int ZakljucnaOcjenaNaPolugodistu { get; set; }
        [Required(ErrorMessage = "Zahtjevano polje.")]
        [Range(1, 5, ErrorMessage = "Ocjene od 1 do 5")]
        public int ZakljucnaOcjenaNaKraju { get; set; }
    }
}
