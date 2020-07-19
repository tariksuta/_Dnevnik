using _eDnevnik.Data.EntityModel;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _eDnevnik.Web.ViewModel
{
    public class ProfesorDodajUcenikaUSekcijuVM
    {

        public List<SelectListItem> Ucenici { get; set; }
      


        public List<Row> rows { get; set; } //  moglo je preko SelectListItem

        public class Row
        {
            public int SekcijaID { get; set; }

            public string Naziv { get; set; }
        }

        

    }
}
