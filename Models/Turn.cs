using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tp_nt1.Models
{
    public class Turn
    {
        [Key]
        public Guid Id { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}")]
        [Display(Name = "Fecha y Hora")]
        public DateTime Date { get; set; }

        [Display(Name = "Estado")]
        public bool Confirmed { get; set; }

        [Display(Name = "Activo")]
        public bool Active { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [Display(Name = "Fecha de creación")]
        public DateTime CreationDate { get; set; }

        [MaxLength(200, ErrorMessage = "{0} admite un máximo de {1} caracteres")]
        [Display(Name = "Descripción de cancelación")]
        public string CancelDescription { get; set; }

        [ForeignKey(nameof(Patient))]
        [Display(Name = "Paciente")]
        public Guid PatientId { get; set; }

        [Display(Name = "Paciente")]
        public Patient Patient { get; set; }

        [ForeignKey(nameof(Professional))]
        [Display(Name = "Profesional")]
        public Guid ProfessionalId { get; set; }

        [Display(Name = "Profesional")]
        public Professional Professional { get; set; }
    }
}

