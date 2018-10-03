using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Archery.Models
{
    public class Bow : BaseModel
    {
        [Required]
        [Display(Name = "Type d'arc")]
        public string Name { get; set; }

        [Display(Name = "Tournoi")]
        public ICollection<Tournament> Tournaments { get; set; }
    }
}