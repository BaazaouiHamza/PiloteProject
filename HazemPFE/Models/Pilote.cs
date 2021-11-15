using System.ComponentModel.DataAnnotations;

namespace HazemPFE.Models
{
    public class Pilote
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Nom { get; set; }

        [Required]
        [StringLength(255)]
        public string Prenom { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name ="Indicatif Radio")]
        public string Indicatif_Radio { get; set; }
    }
}