using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _eDnevnik.Web.ViewModel
{
    public class SekcijaRoditeljPrikazVM
    {
        public List<Rows> ListaSekcija { get; set; }
        public class Rows
        {
            public int SekcijaID { get; set; }
            public string Profesor { get; set; }
            public string Napomena { get; set; }
            public string Naziv { get; set; }
            public string Uclanjen { get; set; }

        }

    }
}
