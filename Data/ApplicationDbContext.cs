using Microsoft.EntityFrameworkCore;
using ControlEscolarWeb.Models;

namespace ControlEscolarWeb.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Alumno> Alumnos => Set<Alumno>();
        public DbSet<CalificacionModulo> CalificacionesModulos => Set<CalificacionModulo>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Mapear nombres de tablas explícitamente para que coincidan con tus scripts/consultas
            modelBuilder.Entity<Alumno>().ToTable("Alumnos");
            modelBuilder.Entity<CalificacionModulo>().ToTable("CalificacionesModulos");

            // Restricción de Unicidad
            modelBuilder.Entity<CalificacionModulo>()
                .HasIndex(c => new { c.AlumnoId, c.NumeroModulo })
                .IsUnique();
        }
    }
}
