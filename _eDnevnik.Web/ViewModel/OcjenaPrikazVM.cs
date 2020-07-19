using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _eDnevnik.Web.ViewModel
{
    public class OcjenaPrikazVM
    {
        public List<Rows> ListaOcjena { get; set; }
        public class Rows
        {
            public int OcjenaID { get; set; }
            public string OcjenaOpisno { get; set; }
            public int OcjenaBrojcano { get; set; }
            public string DatumUnosaOcjene { get; set; }
            public string SlusaPredmet { get; set; }
            public string Cas { get; set; }

        }
    }
}
