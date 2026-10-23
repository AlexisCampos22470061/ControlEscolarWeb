using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ControlEscolarWeb.Migrations
{
    /// <inheritdoc />
    public partial class AddUniqueConstraintToCalificaciones : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_CalificacionesModulos_AlumnoId",
                table: "CalificacionesModulos");

            migrationBuilder.CreateIndex(
                name: "IX_CalificacionesModulos_AlumnoId_NumeroModulo",
                table: "CalificacionesModulos",
                columns: new[] { "AlumnoId", "NumeroModulo" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_CalificacionesModulos_AlumnoId_NumeroModulo",
                table: "CalificacionesModulos");

            migrationBuilder.CreateIndex(
                name: "IX_CalificacionesModulos_AlumnoId",
                table: "CalificacionesModulos",
                column: "AlumnoId");
        }
    }
}
