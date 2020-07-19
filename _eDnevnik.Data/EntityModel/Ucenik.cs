using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace _eDnevnik.Data.EntityModel
{
    public class Ucenik
    {
        public int ID { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Spol { get; set; }
        public DateTime DatumRodjenja { get; set; }
        public string JMBG { get; set; }

        [ForeignKey("RoditeljID")]
        public Roditelj Roditelj { get; set; }
        public int RoditeljID { get; set; }
        
        [ForeignKey("VladanjeID")]
        public Vladanje Vladanje { get; set; }
        public int VladanjeID { get; set; }

        [ForeignKey("OpcinaID")]
        public Opcina Opcina { get; set; }
        public int OpcinaID { get; set; }
    }
}
