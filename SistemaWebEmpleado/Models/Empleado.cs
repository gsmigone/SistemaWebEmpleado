using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using SistemaWebEmpleado.Validations;

namespace SistemaWebEmpleado.Models
{
    public class Empleado
    {
        public int EmpleadoId { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Apellido { get; set; }
        [Required]
        public string DNI { get; set; }
        [Required]
        [CheckValidLegajo]
        public string Legajo { get; set; }
        [Required]
        [DisplayName("Título")]
        public string Titulo { get; set; }
    }
}
