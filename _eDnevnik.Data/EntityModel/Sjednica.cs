using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace _eDnevnik.Data.EntityModel
{
    public class Sjednica
    {
        public int ID { get; set; }
        public DateTime DatumOdrzavanja { get; set; }
        public string Naziv { get; set; }

        [ForeignKey("SkolskaGodinaID")]
        public SkolskaGodina SkolskaGodina { get; set; }
        public int SkolskaGodinaID { get; set; }

    }
}
