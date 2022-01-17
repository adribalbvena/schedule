using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace tp_nt1.Models
{
    public class Professional : User
    {
        public override Role Role => Role.Profesional;

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [MaxLength(50, ErrorMessage = "{0} admite un máximo de {1} caracteres")]
        [Display(Name = "Matrícula")]
        public string Enrollment { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [DisplayFormat(DataFormatString = "{0:HH:mm}")]
        [Display(Name = "Hora De Inicio")]
        public DateTime StartTime { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [DisplayFormat(DataFormatString = "{0:HH:mm}")]
        [Display(Name = "Hora De Finalización")]
        public DateTime EndTime { get; set; }

        [Display(Name = "Turnos")]
        public List<Turn> Turns { get; set; }

        [ForeignKey(nameof(MedicalService))]
        [Display(Name = "Prestación")]
        public Guid MedicalServiceId { get; set; }

        [Display(Name = "Prestación")]
        public MedicalService MedicalService { get; set; }

    }
}
