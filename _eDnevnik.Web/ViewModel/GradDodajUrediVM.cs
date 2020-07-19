using _eDnevnik.Data.EntityModel;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace _eDnevnik.Web.ViewModel
{
    public class GradDodajUrediVM
    {
        [Required(ErrorMessage = "Zahtjevano polje!")]
        public int DrzavaID { get; set; }
        public List<SelectListItem> Drzave { get; set; }

        public int GradID { get; set; }

        [Required(ErrorMessage = "Zahtjevano polje!")]
        [StringLength(30, ErrorMessage = "Naziv minimalno 3 karaktera.", MinimumLength = 3)]
        public string Naziv { get; set; }
    }
}
