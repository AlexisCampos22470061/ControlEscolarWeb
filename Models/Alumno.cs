using System.ComponentModel.DataAnnotations;

namespace ControlEscolarWeb.Models
{
    public class Alumno
    {
        [Key]
        [MaxLength(25)]
        public string Matricula { get; set; } = string.Empty;

        [Required]
        [MaxLength(150)]
        public string NombreCompleto { get; set; } = string.Empty;

        [MaxLength(20)]
        public string Curp { get; set; } = string.Empty;

        [MaxLength(120)]
        public string Horario { get; set; } = string.Empty; // Ej. Sábado Matutino, L-M-V Vespertino

        [MaxLength(100)]
        public string Campus { get; set; } = "Campus Noceda";

        [MaxLength(30)]
        public string Telefono { get; set; } = string.Empty;

        [MaxLength(100)]
        public string Correo { get; set; } = string.Empty;

        [MaxLength(30)]
        public string Estatus { get; set; } = "ACTIVO";

        public virtual ICollection<CalificacionModulo> Calificaciones { get; set; } = new List<CalificacionModulo>();
    }
}
