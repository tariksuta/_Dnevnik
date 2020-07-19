using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _eDnevnik.Web.ViewModel
{
    public class RoditeljRoditeljPrikazVM
    {
            public int RoditeljID { get; set; }
            public string Ime { get; set; }
            public string Prezime { get; set; }
            public string Spol { get; set; }
            public DateTime DatumRodjenja { get; set; }
            public string JMBG { get; set; }
            public string Telefon { get; set; }
            public string Email { get; set; }
            public string Opcina { get; set; }
            public string NazivSlike { get; set; }

    }
}
