using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _eDnevnik.Web.ViewModel
{
    public class OdjeljenjePrikazUcenikaVM
    {
        public int OdjeljenjeID { get; set; }
        public List<Rows> ListaUcenika { get; set; }
        public class Rows
        {
            public int OdjeljenjeUcenikID { get; set; }
            public string ImePrezime { get; set; }
            public int BrojUDnevniku { get; set; }
            public string JMBG { get; set; }

            public string ImeRoditelja { get; set; }
        }

    }
}
