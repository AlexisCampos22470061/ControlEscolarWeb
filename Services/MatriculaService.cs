using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ControlEscolarWeb.Data;

namespace ControlEscolarWeb.Services
{
    public interface IMatriculaService
    {
        Task<string> GenerarSiguienteMatriculaAsync(string codigoPlan = "286");
    }

    public class MatriculaService : IMatriculaService
    {
        private readonly ApplicationDbContext _context;
        private const int ConsecutivoBase = 196;

        public MatriculaService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<string> GenerarSiguienteMatriculaAsync(string codigoPlan = "286")
        {
            string yy = DateTime.Now.ToString("yy");
            string prefijo = $"{yy}{codigoPlan}";

            var matriculasDelAnio = await _context.Alumnos
                .Where(a => a.Matricula != null && a.Matricula.StartsWith(prefijo))
                .Select(a => a.Matricula!)
                .ToListAsync();

            int maxConsecutivo = 0;

            foreach (var mat in matriculasDelAnio)
            {
                if (mat.Length > prefijo.Length)
                {
                    string sufijo = mat.Substring(prefijo.Length);
                    if (int.TryParse(sufijo, out int numero) && numero > maxConsecutivo)
                    {
                        maxConsecutivo = numero;
                    }
                }
            }

            int siguienteConsecutivo = maxConsecutivo > 0 ? maxConsecutivo + 1 : ConsecutivoBase;

            return $"{prefijo}{siguienteConsecutivo:D6}";
        }
    }
}

