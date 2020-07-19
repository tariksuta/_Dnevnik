using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _eDnevnik.Web.ViewModel
{
    public class OpcinaPrikazVM
    {
        public List<Rows> ListaOpcina { get; set; }
        public class Rows
        {
            public int OpcinaID { get; set; }
            public string Naziv { get; set; }
            public string Grad { get; set; }
            public string Drzava { get; set; }
        }
    }
}
