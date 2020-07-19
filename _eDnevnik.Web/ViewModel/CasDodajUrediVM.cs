using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace _eDnevnik.Web.ViewModel
{
    public class CasDodajUrediVM
    {
        public int CasID { get; set; }

        [Required(ErrorMessage = "Obavezno polje")]
        public int BrojCasa { get; set; }
        public string NastavnaJedinica { get; set; }

        [DataType(DataType.Date)]
        public DateTime DatumOdrzavanja { get; set; }

        public int PredajeID { get; set; }
        public int ProfesorID { get; set; }

        public List<SelectListItem> predaje { get; set; }

    }
}
