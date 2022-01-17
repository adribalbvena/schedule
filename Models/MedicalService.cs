using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace tp_nt1.Models
{
    public class MedicalService
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [MaxLength(50, ErrorMessage = "{0} admite un máximo de {1} caracteres")]
        [Display(Name = "Especialidad")]
        public string Name { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [MaxLength(300, ErrorMessage = "{0} admite un máximo de {1} caracteres")]
        [Display(Name = "Descripción")]
        public string Description { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Duración")]
        public int Duration { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Precio")]
        public decimal Price { get; set; }
        [Display(Name = "Profesionales")]
        public List<Professional> Professionals { get; set; }
    }
}
