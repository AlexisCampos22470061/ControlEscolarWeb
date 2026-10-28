using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ControlEscolarWeb.Models;

namespace ControlEscolarWeb.Data
{
    public static class DbInitializer
    {
        private static readonly string[] NombresModulos = new[]
        {
            "Español",
            "Matemáticas",
            "Química",
            "Física",
            "Historia Universal",
            "Historia de México",
            "Biología",
            "Inglés"
        };

        public static async Task SeedAsync(ApplicationDbContext context)
        {
            var alumnosPrueba = new List<(Alumno Alumno, decimal?[] Calificaciones)>
            {
                // 1. Alumno exacto de la credencial de referencia (CPC)
                (
                    new Alumno
                    {
                        Matricula = "26286000186",
                        NombreCompleto = "SOSA GUZMAN LUIS ALFONSO",
                        Curp = "SOGL970330HCCSZS04",
                        FechaNacimiento = new DateTime(1997, 3, 30),
                        Genero = "Masculino",
                        CalleNumero = "C 5 SN ENTRE 10 Y 12",
                        Colonia = "ESPERANZA",
                        CodigoPostal = "24030",
                        MunicipioEntidad = "CAMPECHE, CAMPECHE",
                        Horario = "Sábado Matutino (08:00 - 13:00)",
                        Campus = "Campus Noceda",
                        FechaRegistro = new DateTime(2026, 7, 22),
                        Telefono = "981 206 1301",
                        Correo = "luis.sosa@colegioprofesionalcampeche.edu.mx",
                        Estatus = "ACTIVO"
                    },
                    new decimal?[] { 9.0m, 8.5m, 9.0m, 8.0m, 9.5m, 9.0m, 8.5m, 9.0m }
                ),

                // 2. Alumna egresada (FINALIZADO) con las 8 materias acreditadas
                (
                    new Alumno
                    {
                        Matricula = "26286000187",
                        NombreCompleto = "COVARRUBIAS CHE SILVIA PAOLA",
                        Curp = "COCS070927MMCVHL01",
                        FechaNacimiento = new DateTime(2007, 9, 27),
                        Genero = "Femenino",
                        CalleNumero = "AV. GOBERNADORES NO. 145 ENTRE 45 Y 47",
                        Colonia = "SANTA ANA",
                        CodigoPostal = "24050",
                        MunicipioEntidad = "CAMPECHE, CAMPECHE",
                        Horario = "Martes y Jueves Matutino",
                        Campus = "Campus Noceda",
                        FechaRegistro = new DateTime(2026, 1, 15),
                        Telefono = "981 111 1159",
                        Correo = "silvia.covarrubias@hotmail.com",
                        Estatus = "FINALIZADO"
                    },
                    new decimal?[] { 9.5m, 9.0m, 8.5m, 9.0m, 10.0m, 9.5m, 9.0m, 9.5m }
                ),

                // 3. Alumno activo con materias en curso (algunas evaluadas y otras pendientes)
                (
                    new Alumno
                    {
                        Matricula = "26286000188",
                        NombreCompleto = "CAMPOS BERZUNZA LUIS RAFAEL",
                        Curp = "CABL950611HCCMRS06",
                        FechaNacimiento = new DateTime(1995, 6, 11),
                        Genero = "Masculino",
                        CalleNumero = "CALLE 10 NO. 234 ENTRE 59 Y 61",
                        Colonia = "CENTRO",
                        CodigoPostal = "24000",
                        MunicipioEntidad = "CAMPECHE, CAMPECHE",
                        Horario = "Sábado Matutino (Ceneval)",
                        Campus = "Campus Noceda",
                        FechaRegistro = new DateTime(2026, 5, 10),
                        Telefono = "981 123 4567",
                        Correo = "campos.rafael@prepa.edu.mx",
                        Estatus = "ACTIVO"
                    },
                    new decimal?[] { 8.0m, 9.0m, 8.0m, 8.5m, 8.0m, null, null, null }
                ),

                // 4. Alumno activo vespertino
                (
                    new Alumno
                    {
                        Matricula = "26286000189",
                        NombreCompleto = "CEBALLOS PACHECO RODRIGO AUGUSTO",
                        Curp = "CEPR060910HCCBCDA9",
                        FechaNacimiento = new DateTime(2006, 9, 10),
                        Genero = "Masculino",
                        CalleNumero = "CALLE LAZARO CARDENAS NO. 88",
                        Colonia = "LAS FLORES",
                        CodigoPostal = "24097",
                        MunicipioEntidad = "CAMPECHE, CAMPECHE",
                        Horario = "L-M-V Vespertino (16:00 - 19:00)",
                        Campus = "Campus Noceda",
                        FechaRegistro = new DateTime(2026, 6, 3),
                        Telefono = "981 987 6543",
                        Correo = "ceballos.rodrigo@prepa.edu.mx",
                        Estatus = "ACTIVO"
                    },
                    new decimal?[] { 8.0m, 8.5m, 7.5m, 8.0m, 9.0m, 8.0m, 8.5m, 8.0m }
                ),

                // 5. Familia García 1 (para probar búsqueda con múltiples coincidencias)
                (
                    new Alumno
                    {
                        Matricula = "26286000190",
                        NombreCompleto = "GARCIA PEREZ JUAN CARLOS",
                        Curp = "GAPJ020415HCCGRJ08",
                        FechaNacimiento = new DateTime(2002, 4, 15),
                        Genero = "Masculino",
                        CalleNumero = "AV. CENTRAL NO. 56 DEPTO 2",
                        Colonia = "BARRIO DE SAN ROMAN",
                        CodigoPostal = "24040",
                        MunicipioEntidad = "CAMPECHE, CAMPECHE",
                        Horario = "Sábado Vespertino (14:00 - 19:00)",
                        Campus = "Campus Noceda",
                        FechaRegistro = new DateTime(2026, 8, 12),
                        Telefono = "981 145 7890",
                        Correo = "juan.garcia@gmail.com",
                        Estatus = "ACTIVO"
                    },
                    new decimal?[] { 7.5m, 8.0m, 7.0m, 6.5m, 8.5m, 8.0m, null, null }
                ),

                // 6. Familia García 2 (para probar búsqueda con múltiples coincidencias)
                (
                    new Alumno
                    {
                        Matricula = "26286000191",
                        NombreCompleto = "GARCIA LOPEZ MARIA FERNANDA",
                        Curp = "GALM041122MCCLPR03",
                        FechaNacimiento = new DateTime(2004, 11, 22),
                        Genero = "Femenino",
                        CalleNumero = "CALLE NIEBLA NO. 19 FRACC. FRACCIORAMA 2000",
                        Colonia = "FRACCIORAMA 2000",
                        CodigoPostal = "24090",
                        MunicipioEntidad = "CAMPECHE, CAMPECHE",
                        Horario = "Domingo Intensivo (08:00 - 14:00)",
                        Campus = "Campus Noceda",
                        FechaRegistro = new DateTime(2026, 8, 14),
                        Telefono = "981 234 5678",
                        Correo = "maria.garcia@outlook.com",
                        Estatus = "ACTIVO"
                    },
                    new decimal?[] { 9.5m, 10.0m, 9.0m, 9.5m, 9.0m, 10.0m, 9.5m, 10.0m }
                ),

                // 7. Familia García 3 (con algunas materias no acreditadas para probar alertas rojas)
                (
                    new Alumno
                    {
                        Matricula = "26286000192",
                        NombreCompleto = "GARCIA RAMIREZ PEDRO ANTONIO",
                        Curp = "GARP010805HCCRMP05",
                        FechaNacimiento = new DateTime(2001, 8, 5),
                        Genero = "Masculino",
                        CalleNumero = "CALLE 18 NO. 71 ENTRE 3 Y 5",
                        Colonia = "SAN FRANCISCO",
                        CodigoPostal = "24010",
                        MunicipioEntidad = "CAMPECHE, CAMPECHE",
                        Horario = "L-M-V Matutino (09:00 - 12:00)",
                        Campus = "Campus Noceda",
                        FechaRegistro = new DateTime(2026, 4, 20),
                        Telefono = "981 345 6789",
                        Correo = "pedro.garcia@yahoo.com",
                        Estatus = "INACTIVO"
                    },
                    new decimal?[] { 6.0m, 5.0m, 5.5m, 6.0m, 5.0m, null, null, null }
                ),

                // 8. Alumna activa de Champotón
                (
                    new Alumno
                    {
                        Matricula = "26286000193",
                        NombreCompleto = "PECH DZIB DANIELA GUADALUPE",
                        Curp = "PEDD050219MCCZDN02",
                        FechaNacimiento = new DateTime(2005, 2, 19),
                        Genero = "Femenino",
                        CalleNumero = "CALLE 34 NO. 112 POR 29 Y 31",
                        Colonia = "CENTRO",
                        CodigoPostal = "24400",
                        MunicipioEntidad = "CHAMPOTON, CAMPECHE",
                        Horario = "Sábado Matutino (08:00 - 13:00)",
                        Campus = "Campus Noceda",
                        FechaRegistro = new DateTime(2026, 9, 1),
                        Telefono = "982 104 5521",
                        Correo = "daniela.pech@gmail.com",
                        Estatus = "ACTIVO"
                    },
                    new decimal?[] { 8.5m, 9.0m, 8.5m, 8.0m, 9.0m, 8.5m, 9.0m, 8.5m }
                ),

                // 9. Alumno egresado de Ciudad del Carmen
                (
                    new Alumno
                    {
                        Matricula = "26286000194",
                        NombreCompleto = "MAY CAAMAL JORGE ALBERTO",
                        Curp = "MACJ991203HCCMJR09",
                        FechaNacimiento = new DateTime(1999, 12, 3),
                        Genero = "Masculino",
                        CalleNumero = "AV. ISLA DE TRIS NO. 310",
                        Colonia = "PLAYA NORTE",
                        CodigoPostal = "24115",
                        MunicipioEntidad = "CARMEN, CAMPECHE",
                        Horario = "Domingo Online",
                        Campus = "Campus Noceda",
                        FechaRegistro = new DateTime(2026, 2, 10),
                        Telefono = "938 112 9087",
                        Correo = "jorge.may@gmail.com",
                        Estatus = "FINALIZADO"
                    },
                    new decimal?[] { 9.0m, 8.5m, 8.0m, 8.5m, 9.0m, 9.0m, 8.5m, 9.0m }
                ),

                // 10. Alumna con último consecutivo 195 (para que el siguiente autogenerado sea 26286000196)
                (
                    new Alumno
                    {
                        Matricula = "26286000195",
                        NombreCompleto = "CHAN UC VALERIA MONSERRAT",
                        Curp = "CAUV060714MCCNVL04",
                        FechaNacimiento = new DateTime(2006, 7, 14),
                        Genero = "Femenino",
                        CalleNumero = "CALLE PERU NO. 42 ENTRE TAMAULIPAS Y SONORA",
                        Colonia = "SANTA ANA",
                        CodigoPostal = "24050",
                        MunicipioEntidad = "CAMPECHE, CAMPECHE",
                        Horario = "Martes y Jueves Vespertino",
                        Campus = "Campus Noceda",
                        FechaRegistro = new DateTime(2026, 10, 5),
                        Telefono = "981 412 3390",
                        Correo = "valeria.chan@gmail.com",
                        Estatus = "ACTIVO"
                    },
                    new decimal?[] { 9.0m, 9.5m, 8.5m, 9.0m, null, null, null, null }
                ),

                // 11. Alumno de nuevo ingreso con Matrícula EN TRÁMITE (null)
                (
                    new Alumno
                    {
                        Matricula = null,
                        NombreCompleto = "HERNANDEZ TUN CARLOS EDUARDO",
                        Curp = "HETC080125HCCTCR07",
                        FechaNacimiento = new DateTime(2008, 1, 25),
                        Genero = "Masculino",
                        CalleNumero = "CALLE 12 NO. 55 POR 15 Y 17",
                        Colonia = "SAMULA",
                        CodigoPostal = "24090",
                        MunicipioEntidad = "CAMPECHE, CAMPECHE",
                        Horario = "Sábado Matutino (08:00 - 13:00)",
                        Campus = "Campus Noceda",
                        FechaRegistro = DateTime.Now,
                        Telefono = "981 556 7788",
                        Correo = "carlos.hernandez@gmail.com",
                        Estatus = "ACTIVO"
                    },
                    new decimal?[] { 8.0m, 7.5m, null, null, null, null, null, null }
                )
            };

            foreach (var item in alumnosPrueba)
            {
                var datos = item.Alumno;
                Alumno? existente = null;

                if (!string.IsNullOrWhiteSpace(datos.Matricula))
                {
                    existente = await context.Alumnos
                        .Include(a => a.Calificaciones)
                        .FirstOrDefaultAsync(a => a.Matricula == datos.Matricula);
                }

                if (existente == null)
                {
                    existente = await context.Alumnos
                        .Include(a => a.Calificaciones)
                        .FirstOrDefaultAsync(a => a.Curp == datos.Curp || a.NombreCompleto == datos.NombreCompleto);
                }

                if (existente == null)
                {
                    context.Alumnos.Add(datos);
                    await context.SaveChangesAsync();
                    existente = datos;
                }
                else
                {
                    existente.Matricula = datos.Matricula;
                    existente.NombreCompleto = datos.NombreCompleto;
                    existente.Curp = datos.Curp;
                    existente.FechaNacimiento = datos.FechaNacimiento;
                    existente.Genero = datos.Genero;
                    existente.CalleNumero = datos.CalleNumero;
                    existente.Colonia = datos.Colonia;
                    existente.CodigoPostal = datos.CodigoPostal;
                    existente.MunicipioEntidad = datos.MunicipioEntidad;
                    existente.Horario = datos.Horario;
                    existente.Campus = datos.Campus;
                    existente.FechaRegistro = datos.FechaRegistro;
                    existente.Telefono = datos.Telefono;
                    existente.Correo = datos.Correo;
                    existente.Estatus = datos.Estatus;
                    await context.SaveChangesAsync();
                }

                // Asegurar y poblar las 8 materias
                for (int i = 0; i < NombresModulos.Length; i++)
                {
                    int numModulo = i + 1;
                    var calExistente = await context.CalificacionesModulos
                        .FirstOrDefaultAsync(c => c.AlumnoId == existente.Id && c.NumeroModulo == numModulo);

                    if (calExistente == null)
                    {
                        context.CalificacionesModulos.Add(new CalificacionModulo
                        {
                            AlumnoId = existente.Id,
                            NumeroModulo = numModulo,
                            NombreModulo = NombresModulos[i],
                            Calificacion = item.Calificaciones[i],
                            TipoAplicacion = "Ordinario"
                        });
                    }
                    else if (!calExistente.Calificacion.HasValue && item.Calificaciones[i].HasValue)
                    {
                        calExistente.Calificacion = item.Calificaciones[i];
                    }
                }

                await context.SaveChangesAsync();
            }
        }
    }
}

