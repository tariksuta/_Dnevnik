using System;
using System.Collections.Generic;
using System.Text;

namespace _eDnevnik.Data.EntityModel
{
    public class Smjer
    {
        public int ID { get; set; }
        public string Naziv { get; set; }
        public string Stepen { get; set; }
        public string Zvanje { get; set; }
        public string Oznaka { get; set; }
    }
}
