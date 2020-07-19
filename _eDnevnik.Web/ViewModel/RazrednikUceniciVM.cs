using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _eDnevnik.Web.ViewModel
{
    public class RazrednikUceniciVM
    {
        public String Odjeljenje { get; set; }
        public List<Row> ucenici { get; set; }
        public class Row
        {
            public int UcenikOdjeljenjeID { get; set; }
            public int UcenikID { get; set; }
            public int BrojUDnevniku { get; set; }
            public string Ime { get; set; }
            public string Prezime { get; set; }
            public string JMBG { get; set; }

            public string Vladanje { get; set; }
            public string Spol { get; set; }
            public string Roditelj { get; set; }
        }
      
    }
}
