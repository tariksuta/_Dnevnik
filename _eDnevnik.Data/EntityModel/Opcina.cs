using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace _eDnevnik.Data.EntityModel
{
    public class Opcina
    {
        public int ID { get; set; }
        public string Naziv { get; set; }

        [ForeignKey("GradID")]
        public Grad Grad { get; set; }
        public int GradID { get; set; }
    }
}
