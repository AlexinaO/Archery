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

        [Display(Name ="Nom")]
        public string FirstName { get; set; }

        [Display(Name = "Prénom")]
        public string LastName { get; set; }

        [Display(Name = "Mot de Passe")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name ="Confirmation du mot de Passe")]
        [DataType(DataType.Password)]
        public string ConfirmedPassword { get; set; }

        public string Mail { get; set; }

        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
    }
}