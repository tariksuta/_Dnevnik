using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _eDnevnik.Web.ViewModel
{
    public class SekcijaPrikazSekcijaVM
    {
        public List<Row> sekcije { get; set; }
        public class Row
        {
            public int SekcijaID { get; set; }
            public string Naziv { get; set; }
            public string Napomena { get; set; }
            public string Koordinator { get; set; }
        }
    }
}
