using _eDnevnik.Data.EntityModel;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace _eDnevnik.Web.ViewModel
{
    public class IzostanaDodajUrediVM
    {
        public List<SelectListItem> SlusaPredmet { get; set; }
        public List<SelectListItem> Cas { get; set; }
        public Izostanak Izostanak { get; set; }

        public int IzostanakID { get; set; }
        [Required(ErrorMessage = "Obavezno polje")]
        public string Napomena { get; set; }

        [DataType(DataType.Date)]
        public DateTime DatumIzostanka { get; set; }

        [Required(ErrorMessage = "Obavezno polje")]
        public bool Opravdan { get; set; }

        public int SlusaPredmetID { get; set; }
        public int CasID { get; set; }
    }
}