using _eDnevnik.Data.EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _eDnevnik.Web.ViewModel
{
    public class UcenikRoditeljPrikazVM
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
            public int RodteljID { get; set; }

        public List<RowsO> ListaOcjena { get; set; }
        public class RowsO
        {
            public int OcjenaID { get; set; }
            public int SlusaPredmetID { get; set; }
            public int CasID { get; set; }

            public int OcjenaBrojcano { get; set; }
            public string OcjenaOpisno { get; set; }
            public string Predmet { get; set; }
            public string Profesor { get; set; }
            public DateTime Datum { get; set; }
        }

        public List<RowsI> ListaIzostanaka { get; set; }
        public class RowsI
        {
            public int IzostanakID { get; set; }
            public int SlusaPredmetID { get; set; }
            public int CasID { get; set; }
            
            public string Napomena { get; set; }
            public bool Opravdan { get; set; }
            public DateTime DatumIzostanka { get; set; }
            public string Profesor { get; set; }
            public string Predmet { get; set; }
        }
    }

}

