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
    public class RasporedKonsultacijaDodajUrediVM
    {
        public int RasporedKID { get; set; }

        public string Napomena { get; set; }
        public byte[] RasporedFile { get; set; }

        [Required(ErrorMessage = "Zahtjevano polje!")]
        public IFormFile MyImage { get; set; }

        public string imefajla { get; set; }

        [Required(ErrorMessage = "Zahtjevano polje!")]
        public int SkolskaGodinaID { get; set; }
        public List<SelectListItem> SkolskeGodine { get; set; }
    }
}
