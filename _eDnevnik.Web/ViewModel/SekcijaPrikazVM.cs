using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _eDnevnik.Web.ViewModel
{
    public class SekcijaPrikazVM
    {
        public List<Row> sekcije { get; set; }
        public class Row
        {
            public int SekcijaID { get; set; }

            public int ProfesorID { get; set; }
            public string Profesor { get; set; }
            public string Napomena { get; set; }

            public string Naziv { get; set; }
        }
       
    }
}
