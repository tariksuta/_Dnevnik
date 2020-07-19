using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _eDnevnik.Web.ViewModel
{
    public class IzostanakPrikazVM
    {
        public List<Rows> ListaIzostanaka { get; set; }
        public class Rows
        {
            public int IzostanakID { get; set; }
            public string Napomena { get; set; }
            public string DatumIzostanka { get; set; }
            public bool Opravdan { get; set; }
            public string SlusaPredmet { get; set; }
            public string Cas { get; set; }

        }
    }
}
