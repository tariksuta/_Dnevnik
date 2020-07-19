using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace _eDnevnik.Data.EntityModel
{
    public class RasporedKonsultacija
    {
        public int ID { get; set; }
        public string Napomena { get; set; }
        public byte[] RasporedFile { get; set; }//? za dodati neku sliku, dokument i sl.

        public string imefajla { get; set; }

        [ForeignKey("SkolskaGodinaID")]
        public SkolskaGodina SkolskaGodina { get; set; }
        public int SkolskaGodinaID { get; set; }
    }
}
