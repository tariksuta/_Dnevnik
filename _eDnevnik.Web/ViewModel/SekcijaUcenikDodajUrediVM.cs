using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace _eDnevnik.Web.ViewModel
{
    public class SekcijaUcenikDodajUrediVM
    {
        public int UcenikSekcijaID { get; set; }

        public int SekcijaID { get; set; }
        public List<SelectListItem> ucenici { get; set; }

        public int UcenikID { get; set; }

        [DataType(DataType.Date)]
        public DateTime DatumUclanjenja { get; set; }
    }
}
