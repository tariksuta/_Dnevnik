using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace _eDnevnik.Data.EntityModel
{
    public class Administrator
    {
        public int ID { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public DateTime DatumRodjenja { get; set; }
        public string JMBG { get; set; }
        public string Telefon { get; set; }
        public string Email { get; set; }
        public string Spol { get; set; }

        [ForeignKey("OpcinaID")]
        public Opcina Opcina { get; set; }
        public int OpcinaID { get; set; }

        [ForeignKey("LoginID")]
        public Login Login { get; set; }
        public int LoginID { get; set; }

        public string NazivSlike { get; set; }

    }
}
