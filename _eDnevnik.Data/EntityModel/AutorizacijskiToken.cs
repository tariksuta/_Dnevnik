﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace _eDnevnik.Data.EntityModel
{
    public class AutorizacijskiToken
    {
        public int ID { get; set; }
        public string Vrijednost { get; set; }

        [ForeignKey("LoginID")]
        public Login Login { get; set; }
        public int LoginID { get; set; }
        
        public DateTime VrijemeEvidentiranja { get; set; }
    }
}
