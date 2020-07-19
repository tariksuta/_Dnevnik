using _eDnevnik.Data.EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _eDnevnik.Web.ViewModel
{
    public class ProfesoraPrikazVM
    {

       public List<Row> Profesori { get; set; }

        public class Row
        {
            public  int ProfesorID { get; set; }

            public string Ime { get; set; }

            public string Prezime { get; set; }
            public string Spol { get; set; }
            public string JMBG { get; set; }

            public string DatumRodjenja { get; set; }

            public string Opcina { get; set; }
            public string RasporedKonsultacija { get; set; }

            public int OdjeljenjeID { get; set; }
            public string NazivSlike { get; set; }


        }
    }
}
