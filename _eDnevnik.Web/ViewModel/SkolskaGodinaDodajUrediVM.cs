using _eDnevnik.Data.EntityModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace _eDnevnik.Web.ViewModel
{
    public class SkolskaGodinaDodajUrediVM
    {
        public int SkolskaGodinaID { get; set; }
        [Required(ErrorMessage = "Zahtjevano polje!")]
        [RegularExpression(@"^\d{4}/\d{4}$", ErrorMessage = "Nepravilan izrazd xxxx/xxxx")]
        public string Naziv { get; set; }
        [Required(ErrorMessage = "Zahtjevano polje!")]
        public DateTime DatumPocetka { get; set; }
        [Required(ErrorMessage = "Zahtjevano polje!")]
        public DateTime DatumZavrsetka { get; set; }
    }
}
