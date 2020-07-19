using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _eDnevnik.Web.ViewModel
{
    public class RasporedKonsultacijaRoditeljPrikazVM
    {
        public List<Row> rasporedi { get; set; }
        public class Row
        {
            public int ProfesorID { get; set; }
            public string Ime { get; set; }
            public string Prezime { get; set; }
            public string Napomena { get; set; }
            public string SkolskaGodina { get; set; }
            public string imefajla { get; set; }
        }

        
    }
}
