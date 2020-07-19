using _eDnevnik.Data.EntityModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace _eDnevnik.Web.ViewModel
{
    public class ZapisnikDodajUrediVM
    {
  
        [Required(ErrorMessage = "Zahtjevano polje!")]
        public int AutorID { get; set; }
        public List<SelectListItem> Autori { get; set; }

        [Required(ErrorMessage = "Zahtjevano polje!")]
        public int SjednicaID { get; set; }
        public List<SelectListItem> Sjednice { get; set; }

        public int ZapisnikID { get; set; }

        [Required(ErrorMessage = "Zahtjevano polje!")]
        public string Sadrzaj { get; set; }
        public string Napomena { get; set; }

        public byte[] RasporedFile { get; set; }

        [Required(ErrorMessage = "Zahtjevano polje!")]
        public IFormFile MyImage { get; set; }
        
        public string imefajla { get; set; }
    }
}
