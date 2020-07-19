using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _eDnevnik.Web.ViewModel
{
    public class ProfesorSekcijaDodajVM
    {
        public int SekcijaID { get; set; }

        public List<SelectListItem> sekcije { get; set; }

        public int OdjeljenjeID { get; set; }

        public List<SelectListItem> odjeljenja { get; set; }

        public int UcenikID { get; set; }

        public List<SelectListItem> ucenici { get; set; }
    }
}
