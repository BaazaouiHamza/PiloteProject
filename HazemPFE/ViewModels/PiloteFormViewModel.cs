using HazemPFE.Models;
using System.ComponentModel.DataAnnotations;

namespace HazemPFE.ViewModels
{
    public class PiloteFormViewModel
    {
        public int? Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Nom { get; set; }

        [Required]
        [StringLength(255)]
        public string Prenom { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "Indicatif Radio")]
        public string Indicatif_Radio { get; set; }

        public string Title
        {
            get
            {
                return Id != 0 ? "Edit Pilote" : "New Pilote";
            }


        }
        public PiloteFormViewModel()
        {
            Id = 0;
        }

        public PiloteFormViewModel(Pilote pilote)
        {
            Id = pilote.Id;
            Nom = pilote.Nom;
            Prenom = pilote.Prenom;
            Indicatif_Radio = pilote.Indicatif_Radio;
        }

    }
}