using _eDnevnik.Data.EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _eDnevnik.Web.ViewModel
{
    public class SjednicaPrikazVM
    {
        public List<Rows> ListaSjednica { get; set; }

        public partial class Rows
        {
            public int ID { get; set; }
            public DateTime DatumOdrzavanja { get; set; }
            public string Naziv { get; set; }
            public string SkolskaGodina { get; set; }
        }

    }
}
