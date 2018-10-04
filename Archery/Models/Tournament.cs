using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Archery.Models
{
    public class Tournament : BaseModel
    {
        [Required]
        [Display(Name = "Nom")]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Lieu")]
        [StringLength(250)]
        [DataType(DataType.MultilineText)]
        public string Location { get; set; }

        [Required]
        [Display(Name = "Début")]
        public DateTime StartDate { get; set; }

        [Required]
        [Display(Name = "Fin")]
        public DateTime EndDate { get; set; }

        [Required]
        [Display(Name = "Nombre d'archer max")]
        public int ArcherCount { get; set; }

        [Display(Name = "Prix")]
        public decimal? Price { get; set; }

        [Display(Name = "Armes")]
        public ICollection<Bow> Bows { get; set; }

        //public Tournament()
        //{
        //    Bows = new List<Bow>;
        //}

        [Display(Name = "Tireur")]
        public ICollection<Shooter> Shooters { get; set; }

        [Display(Name = "Description")]
        [DataType(DataType.MultilineText)]
        [AllowHtml]
        public string Description { get; set; }

        [Display(Name = "Images")]
        public ICollection<TournamentPicture> Pictures { get; set; }
    }
}