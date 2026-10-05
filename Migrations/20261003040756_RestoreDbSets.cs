using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ControlEscolarWeb.Migrations
{
    /// <inheritdoc />
    public partial class RestoreDbSets : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Alumnos",
                columns: table => new
                {
                    Matricula = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    NombreCompleto = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Curp = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Horario = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    Campus = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Correo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Estatus = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alumnos", x => x.Matricula);
                });

            migrationBuilder.CreateTable(
                name: "CalificacionesModulos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MatriculaAlumno = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    NumeroModulo = table.Column<int>(type: "int", nullable: false),
                    NombreModulo = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Calificacion = table.Column<decimal>(type: "decimal(4,2)", nullable: true),
                    TipoAplicacion = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CalificacionesModulos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CalificacionesModulos_Alumnos_MatriculaAlumno",
                        column: x => x.MatriculaAlumno,
                        principalTable: "Alumnos",
                        principalColumn: "Matricula",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Alumnos",
                columns: new[] { "Matricula", "Campus", "Correo", "Curp", "Estatus", "Horario", "NombreCompleto", "Telefono" },
                values: new object[,]
                {
                    { "24286000031", "Campus Noceda", "campos.rafael@prepa.edu.mx", "CABL950611HCCMRS06", "ACTIVO", "Sábado Matutino (Ceneval)", "CAMPOS BERZUNZA LUIS RAFAEL", "981 123 4567" },
                    { "24286000063", "Campus Noceda", "ceballos.rodrigo@prepa.edu.mx", "CEPR060910HCCBCDA9", "ACTIVO", "L-M-V Vespertino", "CEBALLOS PACHECO RODRIGO AUGUSTO", "981 987 6543" },
                    { "260431000080", "0431 - Col. Profesional", "america.robert@hotmail.com", "COCS070927MMCVHL01", "ACTIVO", "Martes y Jueves - Matutino", "COVARRUBIAS CHE SILVIA PAOLA", "981 111 1159" }
                });

            migrationBuilder.InsertData(
                table: "CalificacionesModulos",
                columns: new[] { "Id", "Calificacion", "MatriculaAlumno", "NombreModulo", "NumeroModulo", "TipoAplicacion" },
                values: new object[,]
                {
                    { 1, 8.0m, "24286000031", "Matemáticas", 1, "Ordinario" },
                    { 2, 9.0m, "24286000031", "Español y Habilidad Lectora", 2, "Ordinario" },
                    { 3, 8.0m, "24286000031", "Física", 3, "Ordinario" },
                    { 4, 8.0m, "24286000031", "Química", 4, "Ordinario" },
                    { 5, 8.0m, "24286000031", "Biología", 5, "Ordinario" },
                    { 6, 9.0m, "24286000031", "Historia de México", 6, "Ordinario" },
                    { 7, 8.0m, "24286000031", "Historia Universal y Sociedad", 7, "Ordinario" },
                    { 8, 8.0m, "24286000031", "Inglés", 8, "Ordinario" },
                    { 9, 8.0m, "260431000080", "Matemáticas", 1, "Ordinario" },
                    { 10, 9.0m, "260431000080", "Español y Habilidad Lectora", 2, "Ordinario" },
                    { 11, 7.0m, "260431000080", "Física", 3, "Ordinario" },
                    { 12, 8.0m, "260431000080", "Química", 4, "Ordinario" },
                    { 13, 8.0m, "260431000080", "Biología", 5, "Ordinario" },
                    { 14, 9.0m, "260431000080", "Historia de México", 6, "Ordinario" },
                    { 15, 8.0m, "260431000080", "Historia Universal y Sociedad", 7, "Ordinario" },
                    { 16, 9.0m, "260431000080", "Inglés", 8, "Ordinario" },
                    { 17, 8.0m, "24286000063", "Matemáticas", 1, "Ordinario" },
                    { 18, 8.0m, "24286000063", "Español y Habilidad Lectora", 2, "Ordinario" },
                    { 19, 7.0m, "24286000063", "Física", 3, "Ordinario" },
                    { 20, 8.0m, "24286000063", "Química", 4, "Ordinario" },
                    { 21, 9.0m, "24286000063", "Biología", 5, "Ordinario" },
                    { 22, 8.0m, "24286000063", "Historia de México", 6, "Ordinario" },
                    { 23, 8.0m, "24286000063", "Historia Universal y Sociedad", 7, "Ordinario" },
                    { 24, 8.0m, "24286000063", "Inglés", 8, "Ordinario" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Alumnos_NombreCompleto",
                table: "Alumnos",
                column: "NombreCompleto");

            migrationBuilder.CreateIndex(
                name: "IX_CalificacionesModulos_MatriculaAlumno",
                table: "CalificacionesModulos",
                column: "MatriculaAlumno");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CalificacionesModulos");

            migrationBuilder.DropTable(
                name: "Alumnos");
        }
    }
}
