using _eDnevnik.Data.EntityModel;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _eDnevnik.Web.ViewModel
{
    public class RazrednikUcenikDodajUrediVM
    {
        public List<SelectListItem> Opcina { get; set; }
        public List<SelectListItem> Roditelj { get; set; }
        public List<SelectListItem> Vladanje { get; set; }
        public Ucenik Ucenik { get; set; }
    }
}
