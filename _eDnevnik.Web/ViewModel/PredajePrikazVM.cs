using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _eDnevnik.Web.ViewModel
{
    public class PredajePrikazVM
    {
        public List<Rows> ListaPredaje { get; set; }
        public class Rows
        {
            public int PredajeID { get; set; }
            public string Predmet { get; set; }
            public string Profesor { get; set; }
            public string Odjeljenje { get; set; }
        }
    }
}
