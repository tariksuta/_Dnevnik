using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _eDnevnik.Web.ViewModel
{
    public class CasPrikazOdjeljenjeVM
    {
        public List<Row> casovi { get; set; }
        public class Row
        {
            public int CasID { get; set; }

            public int BrojCasa { get; set; }

            public string NastavnaJedinica { get; set; }

            public string DatumOdrzavanja { get; set; }

            public int PredajeID { get; set; }

            public int Odjeljenje { get; set; }

            public string   Profesor { get; set; }
        }
    }
}
