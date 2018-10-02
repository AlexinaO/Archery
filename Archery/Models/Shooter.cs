﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Archery.Models
{
    public class Shooter : BaseModel
    {
        [Required]
        [Display(Name = "Tournoi")]
        public int TournamentID { get; set; }
        [ForeignKey("TournamentID")]
        public Tournament Tournament { get; set; }
        [Required]
        [Display(Name = "Arme")]
        public int WeaponID { get; set; }
        [ForeignKey("WeaponID")]
        public Bow Bow { get; set; }
        [Required]
        [Display(Name = "Archer")]
        public int ArcherID { get; set; }
        [ForeignKey("ArcherID")]
        public Archer Archer { get; set; }
        [Display(Name = "Départ")]
        public DateTime? Departure { get; set; }
    }
}