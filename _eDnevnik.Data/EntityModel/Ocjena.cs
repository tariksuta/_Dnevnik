using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace _eDnevnik.Data.EntityModel
{
    public class Ocjena
    {
        public int ID { get; set; }
        public string OcjenaOpisno { get; set; }
        public int OcjenaBrojcano { get; set; }
        public DateTime DatumUnosaOcjene { get; set; }

        [ForeignKey("SlusaPredmetID")]
        public SlusaPredmet SlusaPredmet { get; set; }
        public int SlusaPredmetID { get; set; }

        [ForeignKey("CasID")]
        public Cas Cas { get; set; }
        public int CasID { get; set; }
    }
}
