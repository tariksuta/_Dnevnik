using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _eDnevnik.Web.ViewModel
{
    public class AdministratorPrikazVM
    {
        public List<Rows> ListaAdministratora{ get; set; }
        public class Rows
        {
            public int AdministratorID { get; set; }
            public string Ime { get; set; }
            public string Prezime { get; set; }
            public string Spol { get; set; }
            public DateTime DatumRodjenja { get; set; }
            public string JMBG { get; set; }
            public string Telefon { get; set; }
            public string Email { get; set; }
            public string Opcina { get; set; }
            public string Login { get; set; }//da li treba?
            public string NazivSlike { get; set; }

        }

    }
    
}
