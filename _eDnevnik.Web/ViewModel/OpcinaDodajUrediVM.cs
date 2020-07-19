using _eDnevnik.Data.EntityModel;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace _eDnevnik.Web.ViewModel
{
    public class OpcinaDodajUrediVM
    {
        [Required(ErrorMessage = "Zahtjevano polje!")]
        public int GradID { get; set; }
        public List<SelectListItem> Gradovi { get; set; }

        public int OpcinaID { get; set; }

        [Required(ErrorMessage = "Zahtjevano polje!")]
        [StringLength(30, ErrorMessage = "Naziv minimalno 3 karaktera.", MinimumLength = 3)]
        public string Naziv { get; set; }

    }
}
