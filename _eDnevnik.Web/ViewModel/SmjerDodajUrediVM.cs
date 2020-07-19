using _eDnevnik.Data.EntityModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace _eDnevnik.Web.ViewModel
{
    public class SmjerDodajUrediVM
    {
        public int SmjerID { get; set; }

        [Required(ErrorMessage = "Zahtjevano polje.")]
        [StringLength(10, ErrorMessage = "Naziv minimalno 3 karaktera.", MinimumLength = 3)]
        public string Naziv { get; set; }
        
        [RegularExpression(@"^(III|IV)$", ErrorMessage = "Nepravilan izraz III ili IV")]
        public string Stepen { get; set; }
        
        [Required(ErrorMessage = "Zahtjevano polje.")]
        public string Zvanje { get; set; }

        [Required(ErrorMessage = "Zahtjevano polje.")]
        public string Oznaka { get; set; }

    }
}
