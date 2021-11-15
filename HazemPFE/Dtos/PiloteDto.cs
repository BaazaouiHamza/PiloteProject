using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HazemPFE.Dtos
{
    public class PiloteDto
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
        [Display(Name = "Indicatif Radio")]
        public string Indicatif_Radio { get; set; }
    }
}