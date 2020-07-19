using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _eDnevnik.Web.ViewModel
{
    public class SlusaPredmetPrikazVM
    {
        public List<Rows> ListaSlusaPredmet { get; set; }
        public class Rows
        {
            public int SlusaPredmetID { get; set; }
            public string OdjeljenjeUcenik { get; set; }
            public string Predaje { get; set; }
            public int ZakljucnaOcjenaNaPolugodistu { get; set; }
            public int ZakljucnaOcjenaNaKraju { get; set; }
        }
    }
}
