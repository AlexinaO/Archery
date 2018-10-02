using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Archery.Models
{
    public class Bow
    {
        [Required]
        [Display(Name = "Type d'arc")]
        public string Name { get; set; }
        [Display(Name = "Tournoi")]
        public ICollection<Tournament> Tournaments { get; set; }
    }
}