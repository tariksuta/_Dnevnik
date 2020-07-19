using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace _eDnevnik.Data.EntityModel
{
    public class Izostanak
    {
        public int ID { get; set; }
        public string Napomena { get; set; }
        public DateTime DatumIzostanka { get; set; }
        public bool Opravdan { get; set; }

        [ForeignKey("SlusaPredmetID")]
        public SlusaPredmet SlusaPredmet { get; set; }
        public int SlusaPredmetID { get; set; }

        [ForeignKey("CasID")]
        public Cas Cas { get; set; }
        public int CasID { get; set; }
    }
}
