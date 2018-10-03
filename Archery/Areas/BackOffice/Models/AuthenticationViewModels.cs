using System.ComponentModel.DataAnnotations;

namespace Archery.Areas.BackOffice.Models
{
    public class AuthenticationLoginViewModels
    {
        [Required(ErrorMessage = "Le champ {0} est obligatoire")]
        public string Mail { get; set; }

        [Required(ErrorMessage = "Le champ {0} est obligatoire")]
        public string Password { get; set; }
    }
}