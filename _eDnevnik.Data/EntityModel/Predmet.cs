using System;
using System.Collections.Generic;
using System.Text;

namespace _eDnevnik.Data.EntityModel
{
    public class Predmet
    {
        public int ID { get; set; }
        public string Naziv { get; set; }
        public string Oznaka { get; set; }
        public int Razred { get; set; }
    }
}
