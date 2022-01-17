using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tp_nt1.Models
{
    public abstract class User
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [MaxLength(50, ErrorMessage = "{0} admite un máximo de {1} caracteres")]
        [MinLength(2, ErrorMessage = "{0} debe tener un mínimo de {1} caracteres")]
        [RegularExpression(@"[a-zA-Z áéíóú]*", ErrorMessage = "El campo {0} sólo admite caracteres alfabéticos")]
        [Display(Name = "Nombre")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [MaxLength(50, ErrorMessage = "{0} admite un máximo de {1} caracteres")]
        [MinLength(2, ErrorMessage = "{0} debe tener un mínimo de {1} caracteres")]
        [RegularExpression(@"[a-zA-Z áéíóú]*", ErrorMessage = "El campo {0} sólo admite caracteres alfabéticos")]
        [Display(Name = "Apellido")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [MaxLength(100, ErrorMessage = "{0} admite un máximo de {1} caracteres")]
        [EmailAddress(ErrorMessage = "El campo {0} debe ser un email válido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [MaxLength(200, ErrorMessage = "{0} admite un máximo de {1} caracteres")]
        [Display(Name = "Dirección")]
        public string Address { get; set; }

        [Display(Name = "Fecha de Creación")]
        public DateTime CreationDate { get; set; }

        [RegularExpression(@"[0-9/-]*", ErrorMessage = "El campo {0} sólo admite números y guiones")]
        [Display(Name = "Teléfono")]
        public string Phone { get; set; }

        public byte[] Password { get; set; }

        [NotMapped]
        public string FullName => $"{this.FirstName} {this.LastName}";

        public abstract Role Role { get; }
    }
}
