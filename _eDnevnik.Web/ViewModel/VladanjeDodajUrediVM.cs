using _eDnevnik.Data.EntityModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace _eDnevnik.Web.ViewModel
{
    public class VladanjeDodajUrediVM
    {
        public int VladanjeID { get; set; }

        [Required(ErrorMessage = "Zahtjevano polje!")]
        [Range(1, 5, ErrorMessage = "Brojevi od 1 - 5!")]
        public int VladanjeBrojcano { get; set; }

        [Required(ErrorMessage = "Zahtjevano polje!")]
        [StringLength(10, ErrorMessage = "Naziv minimalno 3 karaktera.", MinimumLength = 3)]
        public string VladanjeOpisno { get; set; }
        
        public string Napomena { get; set; }
    }
}
