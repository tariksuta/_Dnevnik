using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace _eDnevnik.Data.EntityModel
{
    public class Sekcija
    {
        public int ID { get; set; }
        public string Naziv { get; set; }
        public string Napomena { get; set; }

        [ForeignKey("KoordinatorID")]
        public Profesor Koordinator { get; set; }
        public int KoordinatorID { get; set; }
    }
}
