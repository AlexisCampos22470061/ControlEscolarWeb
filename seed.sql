INSERT INTO Alumnos (NombreCompleto, Matricula, Curp, Genero, CalleNumero, Colonia, CodigoPostal, MunicipioEntidad, Horario, Campus, FechaRegistro, Telefono, Correo, Estatus) 
VALUES 
('Juan Pérez Gómez', '20260001', 'PEGJ010101HDFR01', 'Masculino', 'Av. Reforma 123', 'Centro', '06000', 'CDMX', 'DOM ONLINE', 'Campus Noceda', GETDATE(), '5551234567', 'juan@example.com', 'ACTIVO'),
('María López Campos', NULL, 'LOCM020202MDFR02', 'Femenino', 'Calle Pino 45', 'Juárez', '06600', 'CDMX', 'SAB VESP', 'Campus Noceda', GETDATE(), '5559876543', 'maria@example.com', 'ACTIVO'),
('Carlos Ruiz Lara', '20250089', 'RULC990909HDFR03', 'Masculino', 'Insurgentes Sur 900', 'Del Valle', '03100', 'CDMX', 'LMV MAT', 'Campus Noceda', GETDATE(), '5551112233', 'carlos@example.com', 'FINALIZADO');

DECLARE @Id1 INT = (SELECT Id FROM Alumnos WHERE NombreCompleto = 'Juan Pérez Gómez');
DECLARE @Id2 INT = (SELECT Id FROM Alumnos WHERE NombreCompleto = 'María López Campos');
DECLARE @Id3 INT = (SELECT Id FROM Alumnos WHERE NombreCompleto = 'Carlos Ruiz Lara');

-- Insert subjects for Juan (ACTIVO, some grades)
INSERT INTO CalificacionesModulos (AlumnoId, NumeroModulo, NombreModulo, Calificacion, TipoAplicacion) VALUES
(@Id1, 1, 'ESPAÑOL', 8.5, 'Ordinario'),
(@Id1, 2, 'MATEMÁTICAS', 9.0, 'Ordinario'),
(@Id1, 3, 'QUÍMICA', NULL, 'Ordinario'),
(@Id1, 4, 'FÍSICA', NULL, 'Ordinario'),
(@Id1, 5, 'HISTORIA UNIVERSAL (HIST UNIVR)', NULL, 'Ordinario'),
(@Id1, 6, 'HISTORIA DE MÉXICO (HIST MEXICO)', NULL, 'Ordinario'),
(@Id1, 7, 'BIOLOGÍA', NULL, 'Ordinario'),
(@Id1, 8, 'INGLÉS', NULL, 'Ordinario');

-- Insert subjects for María (ACTIVO, new, no grades, no matricula)
INSERT INTO CalificacionesModulos (AlumnoId, NumeroModulo, NombreModulo, Calificacion, TipoAplicacion) VALUES
(@Id2, 1, 'ESPAÑOL', NULL, 'Ordinario'),
(@Id2, 2, 'MATEMÁTICAS', NULL, 'Ordinario'),
(@Id2, 3, 'QUÍMICA', NULL, 'Ordinario'),
(@Id2, 4, 'FÍSICA', NULL, 'Ordinario'),
(@Id2, 5, 'HISTORIA UNIVERSAL (HIST UNIVR)', NULL, 'Ordinario'),
(@Id2, 6, 'HISTORIA DE MÉXICO (HIST MEXICO)', NULL, 'Ordinario'),
(@Id2, 7, 'BIOLOGÍA', NULL, 'Ordinario'),
(@Id2, 8, 'INGLÉS', NULL, 'Ordinario');

-- Insert subjects for Carlos (FINALIZADO, all grades)
INSERT INTO CalificacionesModulos (AlumnoId, NumeroModulo, NombreModulo, Calificacion, TipoAplicacion) VALUES
(@Id3, 1, 'ESPAÑOL', 9.0, 'Ordinario'),
(@Id3, 2, 'MATEMÁTICAS', 8.5, 'Ordinario'),
(@Id3, 3, 'QUÍMICA', 9.5, 'Ordinario'),
(@Id3, 4, 'FÍSICA', 8.0, 'Ordinario'),
(@Id3, 5, 'HISTORIA UNIVERSAL (HIST UNIVR)', 10.0, 'Ordinario'),
(@Id3, 6, 'HISTORIA DE MÉXICO (HIST MEXICO)', 9.0, 'Ordinario'),
(@Id3, 7, 'BIOLOGÍA', 9.0, 'Ordinario'),
(@Id3, 8, 'INGLÉS', 8.5, 'Ordinario');

