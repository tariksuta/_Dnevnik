using _eDnevnik.Data.EntityModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace _eDnevnik.Web.ViewModel
{
    public class PredmetDodajUrediVM
    {
        public int PredmetID { get; set; }

        [Required(ErrorMessage = "Zahtjevano polje.")]
        public string Naziv { get; set; }
        
        [Range(1,9, ErrorMessage = "Opseg od 1 do 9")]
        public int Razred { get; set; }

        [Required(ErrorMessage = "Zahtjevano polje.")]
        public string Oznaka { get; set; }
    }
}
