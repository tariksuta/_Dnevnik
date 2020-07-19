using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _eDnevnik.Web.ViewModel
{
    public class SelectListIndexVM
    {
        public int DrzavaID { get; set; }

        public List<SelectListItem> drzave { get; set; }

        public int GradID { get; set; }

        public int SekcijaID { get; set; }

        public List<SelectListItem> sekcije { get; set; }
    }
}
