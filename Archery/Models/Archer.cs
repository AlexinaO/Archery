using System.ComponentModel.DataAnnotations;

namespace Archery.Models
{
    public class Archer : User
    {
        [Required(ErrorMessage = "Le champ {0} est obligatoire")]
        [Display(Name = "Numéro de licence")]
        [StringLength(15)]
        [RegularExpression(@"^([0-9]{6})" + "([A-Z]{1})$", ErrorMessage = "Le numéro de licence doit comporter 6 chiffres et terminer par une lettre majuscule")]
        public string LicenseNumber { get; set; }
    }
}