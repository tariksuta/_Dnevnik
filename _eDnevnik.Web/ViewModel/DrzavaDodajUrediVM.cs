using _eDnevnik.Data.EntityModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace _eDnevnik.Web.ViewModel
{
    public class DrzavaDodajUrediVM
    {
        public int DrzavaID{ get; set; }

        [Required(ErrorMessage = "Zahtjevano polje!")]
        [StringLength(30, ErrorMessage = "Naziv minimalno 3 karaktera.", MinimumLength = 3)]
        public string Naziv { get; set; }
    }
}
