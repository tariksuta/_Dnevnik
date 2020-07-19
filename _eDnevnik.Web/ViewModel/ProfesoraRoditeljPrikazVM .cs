using _eDnevnik.Data.EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _eDnevnik.Web.ViewModel
{
    public class ProfesoraRoditeljPrikazVM
    {

       public List<Rows> ProfesoriPredmeti { get; set; }

        public class Rows
        {
            public int PredajeID { get; set; }
            public string Ime { get; set; }
            public string Prezime { get; set; }
            public string Predmet { get; set; }
            public int ZakljucnaOcjenaPolugodiste { get; set; }
            public int ZakljucnaOcjenaKraj { get; set; }
        }
    }
}
