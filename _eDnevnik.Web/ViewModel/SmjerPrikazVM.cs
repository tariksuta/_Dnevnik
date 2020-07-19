using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _eDnevnik.Web.ViewModel
{
    public class SmjerPrikazVM
    {
        public List<Rows> ListaSmjerova { get; set; }

        public partial class Rows
        {
            public int ID { get; set; }
            public string Naziv { get; set; }
            public string Stepen { get; set; }
            public string Zvanje { get; set; }
            public string Oznaka { get; set; }
        }
    }
}

