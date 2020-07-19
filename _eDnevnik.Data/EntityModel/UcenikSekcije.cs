using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace _eDnevnik.Data.EntityModel
{
    public class UcenikSekcije
    {   
        public int ID { get; set; }
        public DateTime DatumUclanjenja { get; set; }

        [ForeignKey("UcenikID")]
        public Ucenik Ucenik { get; set; }
        public int UcenikID { get; set; }

        [ForeignKey("SekcijaID")]
        public Sekcija Sekcija { get; set; }
        public int SekcijaID { get; set; }
    }
}
