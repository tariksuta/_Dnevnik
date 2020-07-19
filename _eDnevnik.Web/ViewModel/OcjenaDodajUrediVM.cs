using _eDnevnik.Data.EntityModel;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace _eDnevnik.Web.ViewModel
{
    public class OcjenaDodajUrediVM
    {
        public List<SelectListItem> SlusaPredmet { get; set; }
        public List<SelectListItem> Cas { get; set; }
        public Ocjena Ocjena { get; set; }

        public int OcjenaID { get; set; }

        [Required(ErrorMessage = "Obavezno polje")]
        public string OcjenaOpisno { get; set; }
        [Required(ErrorMessage = "Obavezno polje")]
        [Range(1, 5, ErrorMessage = "Ocjene od 1 do 5")]
        public int OcjenaBrojcano { get; set; }
        [DataType(DataType.Date)]
        public DateTime DatumUnosOcjene { get; set; }

        public int SlusaPredmetID { get; set; }

        public int CasID { get; set; }
    }
}