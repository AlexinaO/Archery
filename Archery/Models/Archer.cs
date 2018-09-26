using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Archery.Models
{
    public class Archer: User
    {
        [Required(ErrorMessage = "Le champ {0} est obligatoire")]
        [Display (Name ="Numéro de licence")]
        public string LicenseNumber { get; set; }

    }
}