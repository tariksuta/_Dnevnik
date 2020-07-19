using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _eDnevnik.Web.ViewModel
{
    public class GradPrikazVM
    {
        public List<Rows> ListaGradova{ get; set; }
        public class Rows
        {
            public int GradID { get; set; }
            public string Naziv { get; set; }
            public string Drzava { get; set; }
        }
    }
}
