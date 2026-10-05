using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ControlEscolarWeb.Data;
using ControlEscolarWeb.Models;

namespace ControlEscolarWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        // Endpoint GET: api de búsqueda
        [HttpGet]
        public async Task<IActionResult> BuscarAlumno(string criterio)
        {
            if (string.IsNullOrWhiteSpace(criterio))
            {
                return BadRequest(new { error = "Ingresa una matrícula o nombre para buscar." });
            }

            criterio = criterio.Trim();

            var alumno = await _context.Alumnos
                .Include(a => a.Calificaciones)
                .FirstOrDefaultAsync(a => a.Matricula == criterio || 
                                          EF.Functions.Like(a.NombreCompleto, $"%{criterio}%"));

            if (alumno == null)
            {
                return NotFound(new { error = "No se encontró ningún alumno con ese criterio." });
            }

            var modulos = alumno.Calificaciones
                .OrderBy(m => m.NumeroModulo)
                .Select(m => new
                {
                    m.Id,
                    m.NumeroModulo,
                    m.NombreModulo,
                    m.Calificacion,
                    m.TipoAplicacion,
                    Acreditado = m.Calificacion.HasValue && m.Calificacion.Value >= 6.0m
                }).ToList();

            var calificacionesValidas = modulos
                .Where(m => m.Calificacion.HasValue)
                .Select(m => m.Calificacion!.Value)
                .ToList();

            decimal? promedio = calificacionesValidas.Any() 
                ? Math.Round(calificacionesValidas.Average(), 1) 
                : null;

            return Json(new
            {
                alumno = new
                {
                    alumno.Matricula,
                    alumno.NombreCompleto,
                    alumno.Curp,
                    alumno.Horario,
                    alumno.Campus,
                    alumno.Telefono,
                    alumno.Correo,
                    alumno.Estatus
                },
                modulos,
                promedio
            });
        }

        // Endpoint POST: guardar calificación
        [HttpPost]
        public async Task<IActionResult> GuardarCalificacion([FromBody] ActualizarCalificacionRequest request)
        {
            if (request == null || string.IsNullOrWhiteSpace(request.Matricula))
            {
                return BadRequest(new { error = "Datos incompletos." });
            }

            var calModulo = await _context.CalificacionesModulos
                .FirstOrDefaultAsync(c => c.MatriculaAlumno == request.Matricula && c.NumeroModulo == request.NumeroModulo);

            if (calModulo == null)
            {
                return NotFound(new { error = "Módulo no encontrado para este alumno." });
            }

            calModulo.Calificacion = request.Calificacion;
            await _context.SaveChangesAsync();

            return Json(new { success = true, mensaje = "Calificación guardada correctamente." });
        }
    }

    public class ActualizarCalificacionRequest
    {
        public string Matricula { get; set; } = string.Empty;
        public int NumeroModulo { get; set; }
        public decimal? Calificacion { get; set; }
    }
}
