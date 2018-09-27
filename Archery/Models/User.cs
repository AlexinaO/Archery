using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Archery.Models
{
    public abstract class User
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Le champ {0} est obligatoire")]
        [Display(Name ="Nom")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Le champ {0} est obligatoire")]
        [Display(Name = "Prénom")]
        public string LastName { get; set; }


        [Required(ErrorMessage = "Le champ {0} est obligatoire")]
        [Display(Name = "Mot de Passe")]
        [DataType(DataType.Password)]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{6,}$", ErrorMessage = "{0} incorrect.")]
        public string Password { get; set; }

        [Display(Name ="Confirmation du mot de Passe")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage ="La confirmation n'est pas bonne.")]
        public string ConfirmedPassword { get; set; }

        [Required (ErrorMessage ="Le champ {0} est obligatoire")]
        [StringLength(150, ErrorMessage ="Le champ {0} doit contenir {1} caractères max.")]
        [Display(Name ="Adresse E-mail")]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" + @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" + @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "Le format n'est pas bon.")]
        public string Mail { get; set; }

        [Required(ErrorMessage = "Le champ {0} est obligatoire")]
        [Display(Name ="Date de Naissance")]
        [DataType(DataType.Date)]
        [Age(9,ErrorMessage ="Vous devez avoir plus de 9 ans")]
        public DateTime BirthDate { get; set; }
    }
}