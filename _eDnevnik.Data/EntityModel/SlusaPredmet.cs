using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace _eDnevnik.Data.EntityModel
{
    public class SlusaPredmet
    {
        public int ID { get; set; }

        [ForeignKey("OdjeljenjeUcenikID")]
        public OdjeljenjeUcenik OdjeljenjeUcenik { get; set; }
        public int OdjeljenjeUcenikID { get; set; }

        [ForeignKey("PredajeID")]
        public Predaje Predaje { get; set; }
        public int PredajeID { get; set; }

        public int ZakljucnaOcjenaNaPolugodistu { get; set; }
        public int ZakljucnaOcjenaNaKraju { get; set; }
    }
}
