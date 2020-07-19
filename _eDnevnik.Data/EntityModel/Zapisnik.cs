using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace _eDnevnik.Data.EntityModel
{
    public class Zapisnik
    {
        public int ID { get; set; }
        public string Sadrzaj { get; set; }
        public string Napomena { get; set; }

        [ForeignKey("AutorID")]
        public Administrator Autor { get; set; }
        public int AutorID { get; set; }

        [ForeignKey("SjednicaID")]
        public Sjednica Sjednica { get; set; }
        public int SjednicaID { get; set; }

        public byte[] RasporedFile { get; set; }//? za dodati neku sliku, dokument i sl.
        public string imefajla { get; set; }
    }
}
