using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ControlEscolarWeb.Data;
using ControlEscolarWeb.Models;
using ControlEscolarWeb.Services;

namespace ControlEscolarWeb.Controllers
{
    public class AlumnoesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IMatriculaService _matriculaService;

        public AlumnoesController(ApplicationDbContext context, IMatriculaService matriculaService)
        {
            _context = context;
            _matriculaService = matriculaService;
        }

        // GET: Alumnoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Alumnos.Include(a => a.Calificaciones).ToListAsync());
        }

        // GET: Alumnoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alumno = await _context.Alumnos
                .Include(a => a.Calificaciones)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (alumno == null)
            {
                return NotFound();
            }

            return View(alumno);
        }

        // GET: Alumnoes/Create
        public async Task<IActionResult> Create()
        {
            var siguienteMatricula = await _matriculaService.GenerarSiguienteMatriculaAsync();
            var modelo = new Alumno
            {
                Matricula = siguienteMatricula
            };
            return View(modelo);
        }

        // POST: Alumnoes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Matricula,NombreCompleto,Curp,FechaNacimiento,Genero,CalleNumero,Colonia,CodigoPostal,MunicipioEntidad,Horario,Campus,FechaRegistro,Telefono,Correo,Estatus")] Alumno alumno)
        {
            if (string.IsNullOrWhiteSpace(alumno.Matricula))
            {
                alumno.Matricula = null;
                ModelState.Remove(nameof(Alumno.Matricula));
            }
            else
            {
                alumno.Matricula = alumno.Matricula.Trim();
            }

            if (ModelState.IsValid)
            {
                _context.Add(alumno);
                await _context.SaveChangesAsync();
                
                // Initialize 8 default modules
                string[] nombresModulos = new string[] 
                {
                    "ESPAÑOL", "MATEMÁTICAS", "QUÍMICA", "FÍSICA", 
                    "HISTORIA UNIVERSAL (HIST UNIVR)", "HISTORIA DE MÉXICO (HIST MEXICO)", "BIOLOGÍA", "INGLÉS"
                };

                for (int i = 0; i < nombresModulos.Length; i++)
                {
                    _context.CalificacionesModulos.Add(new CalificacionModulo
                    {
                        AlumnoId = alumno.Id,
                        NumeroModulo = i + 1,
                        NombreModulo = nombresModulos[i]
                    });
                }
                
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            return View(alumno);
        }

        // GET: Alumnoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alumno = await _context.Alumnos.FindAsync(id);
            if (alumno == null)
            {
                return NotFound();
            }
            return View(alumno);
        }

        // POST: Alumnoes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Matricula,NombreCompleto,Curp,FechaNacimiento,Genero,CalleNumero,Colonia,CodigoPostal,MunicipioEntidad,Horario,Campus,FechaRegistro,Telefono,Correo,Estatus")] Alumno alumno)
        {
            if (id != alumno.Id)
            {
                return NotFound();
            }

            if (string.IsNullOrWhiteSpace(alumno.Matricula))
            {
                alumno.Matricula = null;
                ModelState.Remove(nameof(Alumno.Matricula));
            }
            else
            {
                alumno.Matricula = alumno.Matricula.Trim();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(alumno);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AlumnoExists(alumno.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(alumno);
        }

        // GET: Alumnoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alumno = await _context.Alumnos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (alumno == null)
            {
                return NotFound();
            }

            return View(alumno);
        }

        // POST: Alumnoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var alumno = await _context.Alumnos.FindAsync(id);
            if (alumno != null)
            {
                _context.Alumnos.Remove(alumno);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AlumnoExists(int id)
        {
            return _context.Alumnos.Any(e => e.Id == id);
        }
    }
}
