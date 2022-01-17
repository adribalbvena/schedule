using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace tp_nt1.Models
{
    public class Patient : User
    {
        public override Role Role => Role.Paciente;

        [Required(ErrorMessage = "El campo {0} es requerido")]
        public int Dni { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [MaxLength(50, ErrorMessage = "{0} admite un máximo de {1} caracteres")]
        [MinLength(3, ErrorMessage = "{0} debe tener un mínimo de {1} caracteres")]
        [RegularExpression(@"[a-zA-Z áéíóú]*", ErrorMessage = "El campo {0} sólo admite caracteres alfabéticos.")]
        [Display(Name = "Obra Social")]
        public string HealthCarePlan { get; set; }

        public List<Turn> Turns { get; set; }

        public List<Form> Forms { get; set; }
    }
}
