using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
namespace ControlEscolarWeb.Models
{
    public class Alumno
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(25)]
        public string? Matricula { get; set; }

        // IDENTIFICACION
        [Required]
        [MaxLength(150)]
        public string NombreCompleto { get; set; } = string.Empty;

        [MaxLength(20)]
        public string Curp { get; set; } = string.Empty;

        public DateTime? FechaNacimiento { get; set; }

        [MaxLength(20)]
        public string Genero { get; set; } = string.Empty;

        // DOMICILIO / INE
        [MaxLength(150)]
        public string CalleNumero { get; set; } = string.Empty;

        [MaxLength(100)]
        public string Colonia { get; set; } = string.Empty;

        [MaxLength(10)]
        public string CodigoPostal { get; set; } = string.Empty;

        [MaxLength(100)]
        public string MunicipioEntidad { get; set; } = string.Empty;

        // DATOS ESCOLARES
        [MaxLength(120)]
        public string Horario { get; set; } = string.Empty; // Ej. Sábado Matutino, L-M-V Vespertino

        [MaxLength(100)]
        public string Campus { get; set; } = "Campus Noceda";

        public DateTime FechaRegistro { get; set; } = DateTime.Now;

        // CONTACTO
        [MaxLength(30)]
        public string Telefono { get; set; } = string.Empty;

        [MaxLength(100)]
        public string Correo { get; set; } = string.Empty;

        // SITUACION
        [MaxLength(30)]
        public string Estatus { get; set; } = "ACTIVO";

        public virtual ICollection<CalificacionModulo> Calificaciones { get; set; } = new List<CalificacionModulo>();
    }
}
