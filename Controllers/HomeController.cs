using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ControlEscolarWeb.Data;
using ControlEscolarWeb.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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
            // Simple mock login check
            if (Request.Cookies["Auth"] == "true")
            {
                return RedirectToAction("Bienvenida");
            }
            return View();
        }

        [HttpPost]
        public IActionResult Login(string usuario, string password)
        {
            // Cuenta universal
            if (usuario == "admin" && password == "admin")
            {
                Response.Cookies.Append("Auth", "true");
                return RedirectToAction("Bienvenida");
            }
            
            ViewBag.Error = "Credenciales incorrectas. Usa admin / admin";
            return View("Index");
        }

        public IActionResult Logout()
        {
            Response.Cookies.Delete("Auth");
            return RedirectToAction("Index");
        }

        public IActionResult Bienvenida()
        {
            if (Request.Cookies["Auth"] != "true")
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Busqueda()
        {
            if (Request.Cookies["Auth"] != "true")
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> SeedData()
        {
            var garcias = new List<Alumno>
            {
                new Alumno { NombreCompleto = "Juan García Pérez", Matricula = "10001", Genero = "Masculino", Estatus = "ACTIVO", FechaRegistro = DateTime.Now },
                new Alumno { NombreCompleto = "María García López", Matricula = "10002", Genero = "Femenino", Estatus = "ACTIVO", FechaRegistro = DateTime.Now },
                new Alumno { NombreCompleto = "Pedro García Ramírez", Matricula = "10003", Genero = "Masculino", Estatus = "ACTIVO", FechaRegistro = DateTime.Now }
            };

            foreach(var g in garcias)
            {
                if (!await _context.Alumnos.AnyAsync(a => a.Matricula == g.Matricula))
                {
                    _context.Alumnos.Add(g);
                }
            }
            await _context.SaveChangesAsync();
            return Content("Datos de prueba (García) insertados correctamente.");
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

            // Buscar todos los que coincidan
            var alumnosMatch = await _context.Alumnos
                .Where(a => a.Matricula == criterio || 
                            EF.Functions.Like(a.NombreCompleto, $"%{criterio}%"))
                .Select(a => new { a.Id, a.Matricula, a.NombreCompleto, a.Estatus })
                .ToListAsync();

            if (!alumnosMatch.Any())
            {
                return NotFound(new { error = "No se encontró ningún alumno con ese criterio." });
            }

            return Json(new { alumnos = alumnosMatch });
        }

        // Endpoint GET: Obtener detalle del alumno por ID
        [HttpGet]
        public async Task<IActionResult> GetAlumnoDetalle(int id)
        {
            var alumno = await _context.Alumnos
                .Include(a => a.Calificaciones)
                .FirstOrDefaultAsync(a => a.Id == id);

            if (alumno == null) return NotFound();

            // Asegurar las 8 materias
            bool addedModules = false;
            string[] nombresModulos = new string[] 
            {
                "Español", "Matemáticas", "Química", "Física", 
                "Historia Universal", "Historia de México", "Biología", "Inglés"
            };

            for (int i = 0; i < nombresModulos.Length; i++)
            {
                int numModulo = i + 1;
                if (!alumno.Calificaciones.Any(m => m.NumeroModulo == numModulo))
                {
                    _context.CalificacionesModulos.Add(new CalificacionModulo
                    {
                        AlumnoId = alumno.Id,
                        NumeroModulo = numModulo,
                        NombreModulo = nombresModulos[i]
                    });
                    addedModules = true;
                }
            }

            if (addedModules)
            {
                await _context.SaveChangesAsync();
                alumno = await _context.Alumnos
                    .Include(a => a.Calificaciones)
                    .FirstOrDefaultAsync(a => a.Id == alumno.Id);
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
                    alumno.Id,
                    alumno.Matricula,
                    alumno.NombreCompleto,
                    alumno.Curp,
                    alumno.FechaNacimiento,
                    alumno.Genero,
                    alumno.CalleNumero,
                    alumno.Colonia,
                    alumno.CodigoPostal,
                    alumno.MunicipioEntidad,
                    alumno.FechaRegistro,
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
            if (request == null || request.AlumnoId <= 0)
            {
                return BadRequest(new { error = "Datos incompletos." });
            }

            var calModulo = await _context.CalificacionesModulos
                .FirstOrDefaultAsync(c => c.AlumnoId == request.AlumnoId && c.NumeroModulo == request.NumeroModulo);

            if (calModulo == null)
            {
                return NotFound(new { error = "Módulo no encontrado para este alumno." });
            }

            calModulo.Calificacion = request.Calificacion;
            await _context.SaveChangesAsync();

            return Json(new { success = true, mensaje = "Calificación guardada correctamente." });
        }

        // Endpoint POST: Cambiar estatus
        [HttpPost]
        public async Task<IActionResult> CambiarEstatus([FromBody] CambiarEstatusRequest request)
        {
            if (request == null || request.AlumnoId <= 0 || string.IsNullOrEmpty(request.Estatus))
            {
                return BadRequest(new { error = "Datos incompletos." });
            }

            var alumno = await _context.Alumnos.FindAsync(request.AlumnoId);
            if (alumno == null)
            {
                return NotFound(new { error = "Alumno no encontrado." });
            }

            string[] validStatuses = { "Activo", "Inactivo", "Finalizado" };
            var estatusNormalizado = request.Estatus.Trim();
            
            var validStatus = validStatuses.FirstOrDefault(s => s.Equals(estatusNormalizado, StringComparison.OrdinalIgnoreCase));

            if (validStatus == null)
            {
                return BadRequest(new { error = "Estado no válido." });
            }

            alumno.Estatus = validStatus;
            await _context.SaveChangesAsync();

            return Json(new { success = true, mensaje = "Estatus actualizado correctamente." });
        }
    }

    public class ActualizarCalificacionRequest
    {
        public int AlumnoId { get; set; }
        public int NumeroModulo { get; set; }
        public decimal? Calificacion { get; set; }
    }

    public class CambiarEstatusRequest
    {
        public int AlumnoId { get; set; }
        public string Estatus { get; set; }
    }
}
