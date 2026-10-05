using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ControlEscolarWeb.Models
{
    public class CalificacionModulo
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(25)]
        public string MatriculaAlumno { get; set; } = string.Empty;

        [ForeignKey(nameof(MatriculaAlumno))]
        public virtual Alumno? Alumno { get; set; }

        public int NumeroModulo { get; set; } // 1 al 8

        [Required]
        [MaxLength(150)]
        public string NombreModulo { get; set; } = string.Empty;

        [Column(TypeName = "decimal(4,2)")]
        public decimal? Calificacion { get; set; }

        [MaxLength(50)]
        public string TipoAplicacion { get; set; } = "Ordinario";
    }
}
