using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace _eDnevnik.Web.ViewModel
{
    public class ProfesorDodajIzostanakVM
    {

        public int IzostanakID { get; set; }

        public int CasID { get; set; }

        public int BrojCasa { get; set; }

        [Required(ErrorMessage = "Zahtjevano polje.")]
        [DataType(DataType.Date)]
        public DateTime Odrzavanja { get; set; }

        [Required(ErrorMessage = "Zahtjevano polje.")]
        public string Napomena { get; set; }

        [Required(ErrorMessage = "Zahtjevano polje.")]
        public int SlusaPredmetID { get; set; }
        public List<SelectListItem> slusapredemt { get; set; }



    }
}
