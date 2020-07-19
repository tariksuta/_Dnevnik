using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _eDnevnik.Web.ViewModel
{
    public class SkolskaGodinaPrikazVM
    {
        public List<Rows> ListaSkolskihGodina { get; set; }
        public partial class Rows
        {
            public int ID { get; set; }
            public string Naziv { get; set; }
            public DateTime DatumPocetka { get; set; }
            public DateTime DatumZavrsetka { get; set; }
        }

    }
}
