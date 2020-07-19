using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace _eDnevnik.Data.EntityModel
{
    public class Predaje
    {
        public int ID { get; set; }

        [ForeignKey("ProfesorID")]
        public Profesor Profesor { get; set; }
        public int ProfesorID { get; set; }


        [ForeignKey("PredmetID")]
        public Predmet Predmet { get; set; }
        public int PredmetID { get; set; }

        [ForeignKey("OdjeljenjeID")]
        public Odjeljenje Odjeljenje { get; set; }
        public int OdjeljenjeID { get; set; }
    }
}
