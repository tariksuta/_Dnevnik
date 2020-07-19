using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _eDnevnik.Web.ViewModel
{
    public class ProfesorInfo
    {
        public int ProfesorID { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }

        public string KorisničkoIme { get; set; }

        public string Opcina { get; set; }

        public string Grad { get; set; }

        public string Država { get; set; }

        public string OdjeljenjeOznaka { get; set; }

        public int Razred { get; set; }

        public string SkolskaGodina { get; set; }
        public string Smjer { get; set; }

        public string NapomenaRasporeda { get; set; }

        public string Rasporedfajl { get; set; }
        public string SkolskaGodinaRaspored { get; set; }
        public string NazivSlike { get; set; }
    }
}
