using System;
using System.Collections.Generic;
using System.Text;

namespace _eDnevnik.Data.EntityModel
{
    public class SkolskaGodina
    {
        public int ID { get; set; }
        public string Naziv { get; set; }
        public DateTime DatumPocetka { get; set; }
        public DateTime DatumZavrsetka { get; set; }
    }
}
