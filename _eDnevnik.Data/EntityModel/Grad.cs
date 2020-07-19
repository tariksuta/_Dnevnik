using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace _eDnevnik.Data.EntityModel
{
    public class Grad
    {
        public int ID { get; set; }
        public string Naziv { get; set; }

        [ForeignKey("DrzavaID")]
        public Drzava Drzava { get; set; }
        public int DrzavaID { get; set; }
    }
}
