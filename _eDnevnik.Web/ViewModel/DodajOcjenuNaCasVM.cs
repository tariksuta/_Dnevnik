using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace _eDnevnik.Web.ViewModel
{
    public class DodajOcjenuNaCasVM
    {
        public int CasID { get; set; }
        public int BrojCasa { get; set; }

        public int OcjenaID { get; set; }

        [Required(ErrorMessage = "Zahtjevano polje!")]
        public string OcjenaOpisno { get; set; }
        [Range(1, 5, ErrorMessage = "Opseg od 1 do 5")]
        public int OcjenaBrojcano { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Datum unosa")]
        public DateTime Datum { get; set; }

        [Required(ErrorMessage = "Zahtjevano polje!")]
        public int SlusaPredmetID { get; set; }

        public List<SelectListItem> slusapredmet { get; set; }
    }
}
