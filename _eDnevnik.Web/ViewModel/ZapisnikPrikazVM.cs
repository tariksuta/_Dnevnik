using _eDnevnik.Data.EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _eDnevnik.Web.ViewModel
{
    public class ZapisnikPrikazVM
    {
        public List<Rows> ListaZapisnika { get; set; }
        public partial class Rows
        {
            public int ID { get; set; }
            public string Sadrzaj { get; set; }
            public string Napomena { get; set; }
            public string Autor { get; set; }
            public string Sjednica { get; set; }
            public string imefajla { get; set; }
        }
    }
}
