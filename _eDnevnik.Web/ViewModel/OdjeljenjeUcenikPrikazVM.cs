using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _eDnevnik.Web.ViewModel
{
    public class OdjeljenjeUcenikPrikazVM
    {
        public List<Rows> ListaOdjeljenjeUcenik { get; set; }
        public class Rows
        {
            public int OdjeljenjeUcenikID { get; set; }
            public string Odjeljenje { get; set; }
            public string Ucenik { get; set; }
            public int BrojUDnevniku { get; set; }
        }
    }
}
