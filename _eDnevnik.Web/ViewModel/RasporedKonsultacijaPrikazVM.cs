using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _eDnevnik.Web.ViewModel
{
    public class RasporedKonsultacijaPrikazVM
    {
        public List<Row> rasporedi { get; set; }
        public class Row
        {
            public int RasporedKID { get; set; }

            public string Napomena { get; set; }

            public int SkolskaGodinaID { get; set; }

            public string SkolskaGodina { get; set; }

            public string imefajla { get; set; }
        }

        
    }
}
