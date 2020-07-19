using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace _eDnevnik.Web.ViewModel
{
    public class LoginDodajUrediVM
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Morate unijeti korisničko ime.")]
        public string KorisnickoIme { get; set; }
        [Required(ErrorMessage = "Morate unijeti šifru.")]
        [StringLength(20, ErrorMessage = "Šifra mora sadržavati minimalno 12 karaktera.", MinimumLength = 12)]
        public string Sifra { get; set; }

    }
}
