using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _eDnevnik.Web.ViewModel
{
    public class OdjeljenjeDetaljiVM
    {
        public int OdjeljenjeID { get; set; }
        public int Razred { get; set; }
        public string Oznaka { get; set; }
        public bool PrebacenUViseOdjeljenje { get; set; }

        public string SkolskaGodina { get; set; }

        public string Razrednik { get; set; }

        public string Smjer { get; set; }

    }
}
