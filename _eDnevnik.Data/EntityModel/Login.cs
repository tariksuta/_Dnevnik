using System;
using System.Collections.Generic;
using System.Text;

namespace _eDnevnik.Data.EntityModel
{
    public class Login//Da li ju trebaju naslijediti klase profesor roditelj administrator ili povezat sa fk
    {
        public int ID { get; set; }
        public string KorisnickoIme { get; set; }
        public string Sifra { get; set; }
        public bool ZapamtiSifru { get; set; }
    }
}
