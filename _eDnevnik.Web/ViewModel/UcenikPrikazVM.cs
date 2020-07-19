using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _eDnevnik.Web.ViewModel
{
    public class UcenikPrikazVM
    {
        public List<Rows> ListaUcenika { get; set; }
        public class Rows
        {
            public int UcenikID { get; set; }
            public string Ime { get; set; }
            public string Prezime { get; set; }
            public string Spol { get; set; }
            public DateTime DatumRodjenja { get; set; }
            public string JMBG { get; set; }
            public string Roditelj { get; set; }
            public string Vladanje { get; set; }
            public string Opcina { get; set; }
        }
    }
}
