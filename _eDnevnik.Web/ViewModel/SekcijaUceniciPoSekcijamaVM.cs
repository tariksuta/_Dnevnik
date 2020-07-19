using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _eDnevnik.Web.ViewModel
{
    public class SekcijaUceniciPoSekcijamaVM
    {

      
        public int SekcijaID { get; set; }

        public List<Row> ucenici { get; set; }
        public class Row
        {
            public int UcenikSekcijaID { get; set; }
            public int UcenikID { get; set; }

            public string Ime { get; set; }

            public string Prezime { get; set; }

            public int Razred { get; set; }

            public string DatumUclanjenja { get; set; }

        }
    }
}
