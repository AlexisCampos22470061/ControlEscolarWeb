using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ControlEscolarWeb.Migrations
{
    /// <inheritdoc />
    public partial class UpdatePrimaryKeyAndAddDireccion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CalificacionesModulos_Alumnos_MatriculaAlumno",
                table: "CalificacionesModulos");

            migrationBuilder.DropIndex(
                name: "IX_CalificacionesModulos_MatriculaAlumno",
                table: "CalificacionesModulos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Alumnos",
                table: "Alumnos");

            migrationBuilder.DropIndex(
                name: "IX_Alumnos_NombreCompleto",
                table: "Alumnos");

            migrationBuilder.DeleteData(
                table: "CalificacionesModulos",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "CalificacionesModulos",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "CalificacionesModulos",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "CalificacionesModulos",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "CalificacionesModulos",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "CalificacionesModulos",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "CalificacionesModulos",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "CalificacionesModulos",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "CalificacionesModulos",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "CalificacionesModulos",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "CalificacionesModulos",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "CalificacionesModulos",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "CalificacionesModulos",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "CalificacionesModulos",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "CalificacionesModulos",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "CalificacionesModulos",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "CalificacionesModulos",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "CalificacionesModulos",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "CalificacionesModulos",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "CalificacionesModulos",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "CalificacionesModulos",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "CalificacionesModulos",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "CalificacionesModulos",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "CalificacionesModulos",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Alumnos",
                keyColumn: "Matricula",
                keyValue: "24286000031");

            migrationBuilder.DeleteData(
                table: "Alumnos",
                keyColumn: "Matricula",
                keyValue: "24286000063");

            migrationBuilder.DeleteData(
                table: "Alumnos",
                keyColumn: "Matricula",
                keyValue: "260431000080");

            migrationBuilder.DropColumn(
                name: "MatriculaAlumno",
                table: "CalificacionesModulos");

            migrationBuilder.AddColumn<int>(
                name: "AlumnoId",
                table: "CalificacionesModulos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Matricula",
                table: "Alumnos",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(25)",
                oldMaxLength: 25);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Alumnos",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "Direccion",
                table: "Alumnos",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Alumnos",
                table: "Alumnos",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_CalificacionesModulos_AlumnoId",
                table: "CalificacionesModulos",
                column: "AlumnoId");

            migrationBuilder.AddForeignKey(
                name: "FK_CalificacionesModulos_Alumnos_AlumnoId",
                table: "CalificacionesModulos",
                column: "AlumnoId",
                principalTable: "Alumnos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CalificacionesModulos_Alumnos_AlumnoId",
                table: "CalificacionesModulos");

            migrationBuilder.DropIndex(
                name: "IX_CalificacionesModulos_AlumnoId",
                table: "CalificacionesModulos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Alumnos",
                table: "Alumnos");

            migrationBuilder.DropColumn(
                name: "AlumnoId",
                table: "CalificacionesModulos");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Alumnos");

            migrationBuilder.DropColumn(
                name: "Direccion",
                table: "Alumnos");

            migrationBuilder.AddColumn<string>(
                name: "MatriculaAlumno",
                table: "CalificacionesModulos",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Matricula",
                table: "Alumnos",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(25)",
                oldMaxLength: 25,
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Alumnos",
                table: "Alumnos",
                column: "Matricula");

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
                name: "IX_CalificacionesModulos_MatriculaAlumno",
                table: "CalificacionesModulos",
                column: "MatriculaAlumno");

            migrationBuilder.CreateIndex(
                name: "IX_Alumnos_NombreCompleto",
                table: "Alumnos",
                column: "NombreCompleto");

            migrationBuilder.AddForeignKey(
                name: "FK_CalificacionesModulos_Alumnos_MatriculaAlumno",
                table: "CalificacionesModulos",
                column: "MatriculaAlumno",
                principalTable: "Alumnos",
                principalColumn: "Matricula",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
