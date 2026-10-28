-- =========================================================================================
-- SCRIPT DE POBLADO DE PRUEBA (25 ALUMNOS COMPLETOS + 8 MÓDULOS DE CALIFICACIONES C/U)
-- Sistema de Control Escolar - Colegio Profesional de Campeche (CPC)
-- Base de datos: ControlEscolarDb
-- =========================================================================================

USE [ControlEscolarDb];
GO

SET NOCOUNT ON;

-- Tabla temporal para cargar los 25 alumnos de prueba de forma segura (sin duplicar si ya existen)
DECLARE @AlumnosSeed TABLE (
    Matricula NVARCHAR(25) NULL,
    NombreCompleto NVARCHAR(150),
    Curp NVARCHAR(20),
    FechaNacimiento DATETIME2 NULL,
    Genero NVARCHAR(20),
    CalleNumero NVARCHAR(150),
    Colonia NVARCHAR(100),
    CodigoPostal NVARCHAR(10),
    MunicipioEntidad NVARCHAR(100),
    Horario NVARCHAR(120),
    Campus NVARCHAR(100),
    FechaRegistro DATETIME2,
    Telefono NVARCHAR(30),
    Correo NVARCHAR(100),
    Estatus NVARCHAR(30),
    Cal1 DECIMAL(4,2) NULL,
    Cal2 DECIMAL(4,2) NULL,
    Cal3 DECIMAL(4,2) NULL,
    Cal4 DECIMAL(4,2) NULL,
    Cal5 DECIMAL(4,2) NULL,
    Cal6 DECIMAL(4,2) NULL,
    Cal7 DECIMAL(4,2) NULL,
    Cal8 DECIMAL(4,2) NULL
);

INSERT INTO @AlumnosSeed VALUES
-- 1 al 15: Alumnos con matrículas 26286000171 a 26286000185
('26286000171', ' AGUILAR PUC JORGE EDUARDO', 'AUPJ010312HCCPGJ01', '2001-03-12', 'Masculino', 'CALLE 14 NO. 89 ENTRE 51 Y 53', 'CENTRO', '24000', 'CAMPECHE, CAMPECHE', 'Sábado Matutino (08:00 - 13:00)', 'Campus Noceda', '2026-01-10', '981 102 3344', 'jorge.aguilar@gmail.com', 'FINALIZADO', 9.0, 8.5, 9.0, 8.5, 9.5, 9.0, 8.5, 9.0),
('26286000172', 'BALAM CAHUICH ANDREA GUADALUPE', 'BACA030724MCCCHA04', '2003-07-24', 'Femenino', 'AV. LOPEZ MATEOS NO. 210', 'BOSQUES DE CAMPECHE', '24030', 'CAMPECHE, CAMPECHE', 'L-M-V Matutino (09:00 - 12:00)', 'Campus Noceda', '2026-01-14', '981 118 9920', 'andrea.balam@outlook.com', 'FINALIZADO', 9.5, 9.0, 9.5, 9.0, 10.0, 9.5, 9.5, 10.0),
('26286000173', 'CANUL CHI ROBERTO CARLOS', 'CACR001105HCCNCR08', '2000-11-05', 'Masculino', 'CALLE 22 NO. 45 POR 19 Y 21', 'SAN ROMAN', '24040', 'CAMPECHE, CAMPECHE', 'Sábado Vespertino (14:00 - 19:00)', 'Campus Noceda', '2026-02-02', '981 130 4455', 'roberto.canul@gmail.com', 'ACTIVO', 8.0, 7.5, 8.0, 7.0, 8.5, 8.0, NULL, NULL),
('26286000174', 'CASTILLO DZUL MARIANA ISABEL', 'CADM050518MCCSDM02', '2005-05-18', 'Femenino', 'CALLE COAHUILA NO. 115', 'SANTA ANA', '24050', 'CAMPECHE, CAMPECHE', 'Martes y Jueves Matutino', 'Campus Noceda', '2026-02-11', '981 142 6781', 'mariana.castillo@hotmail.com', 'ACTIVO', 9.0, 9.5, 8.5, 9.0, 9.0, 8.5, 9.0, NULL),
('26286000175', 'CHE KU MIGUEL ANGEL', 'CEKM980929HCCKMA09', '1998-09-29', 'Masculino', 'CALLE 8 NO. 33 ENTRE 63 Y 65', 'SAN FRANCISCO', '24010', 'CAMPECHE, CAMPECHE', 'Domingo Intensivo (08:00 - 14:00)', 'Campus Noceda', '2026-02-19', '981 155 8832', 'miguel.che@gmail.com', 'INACTIVO', 6.5, 5.5, 5.0, 6.0, NULL, NULL, NULL, NULL),
('26286000176', 'DOMINGUEZ EK KARLA PATRICIA', 'DOEK040214MCCMKR05', '2004-02-14', 'Femenino', 'AV. SOLIDARIDAD NACIONAL NO. 78', 'FIDEL VELAZQUEZ', '24023', 'CAMPECHE, CAMPECHE', 'L-M-V Vespertino (16:00 - 19:00)', 'Campus Noceda', '2026-03-04', '981 167 2390', 'karla.dominguez@gmail.com', 'ACTIVO', 8.5, 8.0, 8.5, 8.0, 9.0, 8.5, 8.0, 8.5),
('26286000177', 'ESTRELLA POOT FERNANDO JOSE', 'ESPF020808HCCPFJ03', '2002-08-08', 'Masculino', 'CALLE NARDO NO. 14 FRACC. JARDINES', 'JARDINES', '24060', 'CAMPECHE, CAMPECHE', 'Sábado Matutino (08:00 - 13:00)', 'Campus Noceda', '2026-03-15', '981 178 4512', 'fernando.estrella@gmail.com', 'ACTIVO', 7.5, 8.0, 7.5, 8.0, 7.0, 8.0, 7.5, 8.0),
('26286000178', 'GOMEZ HUCHIN DIANA LAURA', 'GOHD060130MCCMDL06', '2006-01-30', 'Femenino', 'CALLE 16 NO. 102 POR 41', 'GUADALUPE', '24010', 'CAMPECHE, CAMPECHE', 'Martes y Jueves Vespertino', 'Campus Noceda', '2026-03-28', '981 189 6011', 'diana.gomez@outlook.com', 'ACTIVO', 9.0, 9.0, 8.5, 9.5, 9.0, NULL, NULL, NULL),
('26286000179', 'HERRERA UCAN ALEJANDRO', 'HEUA990417HCCUAL01', '1999-04-17', 'Masculino', 'CALLE 27 NO. 64 ENTRE 12 Y 14', 'CENTRO', '24500', 'LERMA, CAMPECHE', 'Sábado Matutino (08:00 - 13:00)', 'Campus Noceda', '2026-04-05', '981 190 7744', 'alejandro.herrera@gmail.com', 'FINALIZADO', 8.5, 8.5, 8.0, 8.5, 9.0, 8.5, 8.5, 9.0),
('26286000180', 'JIMENEZ YAM PAOLA CRISTINA', 'JIYP051021MCCYPC07', '2005-10-21', 'Femenino', 'AV. PATRICIO TRUEBA NO. 305', 'SAN RAFAEL', '24090', 'CAMPECHE, CAMPECHE', 'Domingo Online', 'Campus Noceda', '2026-04-18', '981 201 3388', 'paola.jimenez@gmail.com', 'ACTIVO', 9.5, 9.0, 9.0, 9.5, 9.5, 9.0, 9.5, 9.0),
('26286000181', 'LOPEZ CHABLE RICARDO MANUEL', 'LOCR011211HCCPCH02', '2001-12-11', 'Masculino', 'CALLE MONTECARLO NO. 29', 'BELLAVISTA', '24020', 'CAMPECHE, CAMPECHE', 'Sábado Vespertino (14:00 - 19:00)', 'Campus Noceda', '2026-05-02', '981 212 9045', 'ricardo.lopez@hotmail.com', 'ACTIVO', 8.0, 7.5, 8.0, 7.5, NULL, NULL, NULL, NULL),
('26286000182', 'LOPEZPEREZ ANA SOFIA', 'LOPA070303MCCPAS08', '2007-03-03', 'Femenino', 'CALLE QUINTANA ROO NO. 83', 'SANTA LUCIA', '24020', 'CAMPECHE, CAMPECHE', 'L-M-V Matutino (09:00 - 12:00)', 'Campus Noceda', '2026-05-14', '981 223 1167', 'anasofia.lopez@gmail.com', 'ACTIVO', 10.0, 9.5, 9.5, 10.0, 9.5, 10.0, 9.5, 10.0),
('26286000183', 'MARTINEZ COHUO HECTOR IVAN', 'MACH000625HCCRHI04', '2000-06-25', 'Masculino', 'CALLE 20 NO. 150 POR 33', 'SEYBAPLAYA', '24460', 'CHAMPOTON, CAMPECHE', 'Domingo Intensivo (08:00 - 14:00)', 'Campus Noceda', '2026-05-29', '982 108 4410', 'hector.martinez@gmail.com', 'INACTIVO', 5.0, 6.0, 5.5, NULL, NULL, NULL, NULL, NULL),
('26286000184', 'NOVELO NOH GABRIELA', 'NONG030909MCCNNG05', '2003-09-09', 'Femenino', 'AV. RESURGIMIENTO NO. 190', 'MIRADOR', '24035', 'CAMPECHE, CAMPECHE', 'Sábado Matutino (08:00 - 13:00)', 'Campus Noceda', '2026-06-10', '981 244 5590', 'gabriela.novelo@gmail.com', 'ACTIVO', 8.5, 9.0, 8.0, 8.5, 8.5, 9.0, 8.5, 9.0),
('26286000185', 'ORTIZ MEX EMMANUEL', 'OIME020116HCCMXE06', '2002-01-16', 'Masculino', 'CALLE 49 NO. 61 ENTRE 14 Y 16', 'CENTRO', '24000', 'CAMPECHE, CAMPECHE', 'L-M-V Vespertino (16:00 - 19:00)', 'Campus Noceda', '2026-06-25', '981 255 6601', 'emmanuel.ortiz@gmail.com', 'ACTIVO', 8.0, 8.0, 7.5, 8.5, 8.0, 7.5, 8.0, NULL),

-- 16 al 25: Alumnos institucionales principales (26286000186 al 26286000195)
('26286000186', 'SOSA GUZMAN LUIS ALFONSO', 'SOGL970330HCCSZS04', '1997-03-30', 'Masculino', 'C 5 SN ENTRE 10 Y 12', 'ESPERANZA', '24030', 'CAMPECHE, CAMPECHE', 'Sábado Matutino (08:00 - 13:00)', 'Campus Noceda', '2026-07-22', '981 206 1301', 'luis.sosa@colegioprofesionalcampeche.edu.mx', 'ACTIVO', 9.0, 8.5, 9.0, 8.0, 9.5, 9.0, 8.5, 9.0),
('26286000187', 'COVARRUBIAS CHE SILVIA PAOLA', 'COCS070927MMCVHL01', '2007-09-27', 'Femenino', 'AV. GOBERNADORES NO. 145 ENTRE 45 Y 47', 'SANTA ANA', '24050', 'CAMPECHE, CAMPECHE', 'Martes y Jueves Matutino', 'Campus Noceda', '2026-01-15', '981 111 1159', 'silvia.covarrubias@hotmail.com', 'FINALIZADO', 9.5, 9.0, 8.5, 9.0, 10.0, 9.5, 9.0, 9.5),
('26286000188', 'CAMPOS BERZUNZA LUIS RAFAEL', 'CABL950611HCCMRS06', '1995-06-11', 'Masculino', 'CALLE 10 NO. 234 ENTRE 59 Y 61', 'CENTRO', '24000', 'CAMPECHE, CAMPECHE', 'Sábado Matutino (Ceneval)', 'Campus Noceda', '2026-05-10', '981 123 4567', 'campos.rafael@prepa.edu.mx', 'ACTIVO', 8.0, 9.0, 8.0, 8.5, 8.0, NULL, NULL, NULL),
('26286000189', 'CEBALLOS PACHECO RODRIGO AUGUSTO', 'CEPR060910HCCBCDA9', '2006-09-10', 'Masculino', 'CALLE LAZARO CARDENAS NO. 88', 'LAS FLORES', '24097', 'CAMPECHE, CAMPECHE', 'L-M-V Vespertino (16:00 - 19:00)', 'Campus Noceda', '2026-06-03', '981 987 6543', 'ceballos.rodrigo@prepa.edu.mx', 'ACTIVO', 8.0, 8.5, 7.5, 8.0, 9.0, 8.0, 8.5, 8.0),
('26286000190', 'GARCIA PEREZ JUAN CARLOS', 'GAPJ020415HCCGRJ08', '2002-04-15', 'Masculino', 'AV. CENTRAL NO. 56 DEPTO 2', 'BARRIO DE SAN ROMAN', '24040', 'CAMPECHE, CAMPECHE', 'Sábado Vespertino (14:00 - 19:00)', 'Campus Noceda', '2026-08-12', '981 145 7890', 'juan.garcia@gmail.com', 'ACTIVO', 7.5, 8.0, 7.0, 6.5, 8.5, 8.0, NULL, NULL),
('26286000191', 'GARCIA LOPEZ MARIA FERNANDA', 'GALM041122MCCLPR03', '2004-11-22', 'Femenino', 'CALLE NIEBLA NO. 19 FRACC. FRACCIORAMA 2000', 'FRACCIORAMA 2000', '24090', 'CAMPECHE, CAMPECHE', 'Domingo Intensivo (08:00 - 14:00)', 'Campus Noceda', '2026-08-14', '981 234 5678', 'maria.garcia@outlook.com', 'ACTIVO', 9.5, 10.0, 9.0, 9.5, 9.0, 10.0, 9.5, 10.0),
('26286000192', 'GARCIA RAMIREZ PEDRO ANTONIO', 'GARP010805HCCRMP05', '2001-08-05', 'Masculino', 'CALLE 18 NO. 71 ENTRE 3 Y 5', 'SAN FRANCISCO', '24010', 'CAMPECHE, CAMPECHE', 'L-M-V Matutino (09:00 - 12:00)', 'Campus Noceda', '2026-04-20', '981 345 6789', 'pedro.garcia@yahoo.com', 'INACTIVO', 6.0, 5.0, 5.5, 6.0, 5.0, NULL, NULL, NULL),
('26286000193', 'PECH DZIB DANIELA GUADALUPE', 'PEDD050219MCCZDN02', '2005-02-19', 'Femenino', 'CALLE 34 NO. 112 POR 29 Y 31', 'CENTRO', '24400', 'CHAMPOTON, CAMPECHE', 'Sábado Matutino (08:00 - 13:00)', 'Campus Noceda', '2026-09-01', '982 104 5521', 'daniela.pech@gmail.com', 'ACTIVO', 8.5, 9.0, 8.5, 8.0, 9.0, 8.5, 9.0, 8.5),
('26286000194', 'MAY CAAMAL JORGE ALBERTO', 'MACJ991203HCCMJR09', '1999-12-03', 'Masculino', 'AV. ISLA DE TRIS NO. 310', 'PLAYA NORTE', '24115', 'CARMEN, CAMPECHE', 'Domingo Online', 'Campus Noceda', '2026-02-10', '938 112 9087', 'jorge.may@gmail.com', 'FINALIZADO', 9.0, 8.5, 8.0, 8.5, 9.0, 9.0, 8.5, 9.0),
('26286000195', 'CHAN UC VALERIA MONSERRAT', 'CAUV060714MCCNVL04', '2006-07-14', 'Femenino', 'CALLE PERU NO. 42 ENTRE TAMAULIPAS Y SONORA', 'SANTA ANA', '24050', 'CAMPECHE, CAMPECHE', 'Martes y Jueves Vespertino', 'Campus Noceda', '2026-10-05', '981 412 3390', 'valeria.chan@gmail.com', 'ACTIVO', 9.0, 9.5, 8.5, 9.0, NULL, NULL, NULL, NULL),

-- 26 y 27: Alumnos sin matrícula (EN TRÁMITE)
(NULL, 'HERNANDEZ TUN CARLOS EDUARDO', 'HETC080125HCCTCR07', '2008-01-25', 'Masculino', 'CALLE 12 NO. 55 POR 15 Y 17', 'SAMULA', '24090', 'CAMPECHE, CAMPECHE', 'Sábado Matutino (08:00 - 13:00)', 'Campus Noceda', GETDATE(), '981 556 7788', 'carlos.hernandez@gmail.com', 'ACTIVO', 8.0, 7.5, NULL, NULL, NULL, NULL, NULL, NULL),
(NULL, 'RAMIREZ SOLIS WENDY NAYELI', 'RASW070619MCCSWR03', '2007-06-19', 'Femenino', 'AV. H. COLEGIO MILITAR NO. 130', 'AVIACION', '24070', 'CAMPECHE, CAMPECHE', 'Domingo Intensivo (08:00 - 14:00)', 'Campus Noceda', GETDATE(), '981 610 2233', 'wendy.ramirez@gmail.com', 'ACTIVO', 9.0, NULL, NULL, NULL, NULL, NULL, NULL, NULL);

-- 1. Insertar o actualizar alumnos
MERGE INTO [dbo].[Alumnos] AS Target
USING @AlumnosSeed AS Source
ON (Target.Curp = Source.Curp OR (Target.Matricula IS NOT NULL AND Target.Matricula = Source.Matricula))
WHEN MATCHED THEN
    UPDATE SET
        Target.Matricula = Source.Matricula,
        Target.NombreCompleto = TRIM(Source.NombreCompleto),
        Target.Curp = Source.Curp,
        Target.FechaNacimiento = Source.FechaNacimiento,
        Target.Genero = Source.Genero,
        Target.CalleNumero = Source.CalleNumero,
        Target.Colonia = Source.Colonia,
        Target.CodigoPostal = Source.CodigoPostal,
        Target.MunicipioEntidad = Source.MunicipioEntidad,
        Target.Horario = Source.Horario,
        Target.Campus = Source.Campus,
        Target.FechaRegistro = Source.FechaRegistro,
        Target.Telefono = Source.Telefono,
        Target.Correo = Source.Correo,
        Target.Estatus = Source.Estatus
WHEN NOT MATCHED THEN
    INSERT (Matricula, NombreCompleto, Curp, FechaNacimiento, Genero, CalleNumero, Colonia, CodigoPostal, MunicipioEntidad, Horario, Campus, FechaRegistro, Telefono, Correo, Estatus)
    VALUES (Source.Matricula, TRIM(Source.NombreCompleto), Source.Curp, Source.FechaNacimiento, Source.Genero, Source.CalleNumero, Source.Colonia, Source.CodigoPostal, Source.MunicipioEntidad, Source.Horario, Source.Campus, Source.FechaRegistro, Source.Telefono, Source.Correo, Source.Estatus);

-- 2. Insertar o actualizar los 8 módulos de cada alumno
DECLARE @Modulos TABLE (NumeroModulo INT, NombreModulo NVARCHAR(150));
INSERT INTO @Modulos VALUES
(1, 'Español'),
(2, 'Matemáticas'),
(3, 'Química'),
(4, 'Física'),
(5, 'Historia Universal'),
(6, 'Historia de México'),
(7, 'Biología'),
(8, 'Inglés');

MERGE INTO [dbo].[CalificacionesModulos] AS Target
USING (
    SELECT 
        a.Id AS AlumnoId,
        m.NumeroModulo,
        m.NombreModulo,
        CASE m.NumeroModulo
            WHEN 1 THEN s.Cal1
            WHEN 2 THEN s.Cal2
            WHEN 3 THEN s.Cal3
            WHEN 4 THEN s.Cal4
            WHEN 5 THEN s.Cal5
            WHEN 6 THEN s.Cal6
            WHEN 7 THEN s.Cal7
            WHEN 8 THEN s.Cal8
        END AS Calificacion
    FROM @AlumnosSeed s
    INNER JOIN [dbo].[Alumnos] a ON a.Curp = s.Curp
    CROSS JOIN @Modulos m
) AS Source
ON (Target.AlumnoId = Source.AlumnoId AND Target.NumeroModulo = Source.NumeroModulo)
WHEN MATCHED THEN
    UPDATE SET
        Target.NombreModulo = Source.NombreModulo,
        Target.Calificacion = COALESCE(Target.Calificacion, Source.Calificacion)
WHEN NOT MATCHED THEN
    INSERT (AlumnoId, NumeroModulo, NombreModulo, Calificacion, TipoAplicacion)
    VALUES (Source.AlumnoId, Source.NumeroModulo, Source.NombreModulo, Source.Calificacion, 'Ordinario');

PRINT '27 alumnos completos y sus 216 registros de módulos (8 por alumno) insertados/actualizados con éxito.';
GO
