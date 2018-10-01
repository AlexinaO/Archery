using Archery.Validators;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Archery.Models
{
    public abstract class User
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Le champ {0} est obligatoire")]
        [Display(Name = "Nom")]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Le champ {0} est obligatoire")]
        [Display(Name = "Prénom")]
        [StringLength(50)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Le champ {0} est obligatoire")]
        [Display(Name = "Mot de Passe")]
        [DataType(DataType.Password)]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{6,}$", ErrorMessage = "{0} incorrect.")]
        [StringLength(150)]
        public string Password { get; set; }

        [NotMapped]
        [Display(Name = "Confirmation du mot de Passe")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "La confirmation n'est pas bonne.")]
        public string ConfirmedPassword { get; set; }

        [Index(IsUnique = true)]
        [Email(ErrorMessage = "Le mail existe déjà.")]
        [Required(ErrorMessage = "Le champ {0} est obligatoire")]
        [StringLength(150, ErrorMessage = "Le champ {0} doit contenir {1} caractères max.")]
        [Display(Name = "Adresse E-mail")]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" + @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" + @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "Le format n'est pas bon.")]
        public string Mail { get; set; }

        [Required(ErrorMessage = "Le champ {0} est obligatoire")]
        [Display(Name = "Date de Naissance")]
        [DataType(DataType.Date)]
        //[Age(9,ErrorMessage ="Pour ce champ {0}, vous devez avoir plus de {1} ans")]
        [Age(9, MaximumAge = 90, ErrorMessage = "Pour ce champ {0}, vous devez avoir plus de {1} ans et moins de {2} ans.")]
        [Column(TypeName = "datetime2")]
        public DateTime BirthDate { get; set; }
    }
}