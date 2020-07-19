using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace _eDnevnik.Data.EntityModel
{
    public class Cas
    {
        public int ID { get; set; }
        public int BrojCasa { get; set; }
        public string NastavnaJedinica { get; set; }
        public DateTime DatumOdrzavanja { get; set; }

        [ForeignKey("PredajeID")]
        public Predaje Predaje { get; set; }
        public int PredajeID { get; set; }
    }
}
