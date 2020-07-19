using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace _eDnevnik.Data.EntityModel
{
    public class OdjeljenjeUcenik
    {
        public int ID { get; set; }

        [ForeignKey("OdjeljenjeID")]
        public Odjeljenje Odjeljenje { get; set; }
        public int OdjeljenjeID { get; set; }

        [ForeignKey("UcenikID")]
        public Ucenik Ucenik { get; set; }
        public int UcenikID { get; set; }

        public int BrojUDnevniku { get; set; }
    }
}
