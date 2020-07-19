using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace _eDnevnik.Data.EntityModel
{
    public class Odjeljenje
    {
        public int ID { get; set; }
        public int Razred { get; set; }
        public string Oznaka { get; set; }
        public bool PrebacenUViseOdjeljenje { get; set; }

        [ForeignKey("SkolskaGodinaID")]
        public SkolskaGodina SkolskaGodina { get; set; }
        public int SkolskaGodinaID { get; set; }

        [ForeignKey("RazrednikID")]
        public Profesor Razrednik { get; set; }
        public int RazrednikID { get; set; }
        
        [ForeignKey("SmjerID")]
        public Smjer Smjer { get; set; }
        public int SmjerID { get; set; }


    }
}
