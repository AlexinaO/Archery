using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Archery.Models
{
    public class TournamentPicture : BaseModel
    {
        [Required]
        [StringLength(150)]
        public string Name { get; set; }

        [Required]
        [StringLength(20)]
        public string ContentType { get; set; }

        [Required]
        public byte[] Content { get; set; } //pour un enregistrement en dossier, c'est l'url

        [Required]
        public int TournamentID { get; set; }

        [ForeignKey("TournamentID")]
        public Tournament Tournament { get; set; }
    }
}