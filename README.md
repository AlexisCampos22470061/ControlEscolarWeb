# Sistema de Control Escolar - Colegio Profesional de Campeche (CPC)

Plataforma web desarrollada en **ASP.NET Core (.NET 8)** para la consulta ágil de expedientes estudiantiles, gestión de matrícula y registro del historial académico de 8 módulos correspondientes al plan de bachillerato modular / CENEVAL.

---

## 📌 Contexto del Proyecto

El sistema fue diseñado como parte del proyecto de **Residencia Profesional** para la carrera de **Ingeniería en Sistemas Computacionales** en el **Colegio Profesional de Campeche (CPC)**. Su objetivo principal es sustituir el manejo manual en hojas de cálculo dispersas (`DOCUMENTACION ETAPA 2026.xlsx`) y la navegación fragmentada del portal web heredado (SPACAM), centralizando la información en una interfaz intuitiva, moderna y eficiente.

---

## ✨ Características Principales

- **Búsqueda Instantánea:** Consulta en un solo paso mediante matrícula o por nombre/apellido (ej. *Campos*, *Covarrubias*, *24286000031*).
- **Ficha Concentrada del Alumno:** Despliegue inmediato de matrícula, CURP, campus/sede, turno/horario, datos de contacto y estatus escolar.
- **Historial Académico Modular (8 Módulos):**
  1. Matemáticas
  2. Español y Habilidad Lectora
  3. Física
  4. Química
  5. Biología
  6. Historia de México
  7. Historia Universal y Sociedad
  8. Inglés
- **Captura y Persistencia en Tiempo Real:** Edición y guardado de calificaciones módulo por módulo mediante peticiones asíncronas (`Fetch/AJAX`), recalculando el promedio ponderado y estatus de acreditación al instante sin recargar la página.
- **Directorio General Administrativo (`/Alumnos`):** Tabla con filtrado dinámico en tiempo real y acciones completas de gestión (edición, consulta y eliminación).
- **Carga de Datos:** Poblado inicial automatizado con más de 260 registros estudiantiles organizados por etapas y turnos.

---

## 🛠️ Stack Tecnológico

- **Framework Backend:** ASP.NET Core MVC (.NET 8)
- **Lenguaje:** C# 12
- **ORM / Acceso a Datos:** Entity Framework Core 8.0 (Code-First)
- **Base de Datos:** Microsoft SQL Server (LocalDB / Express)
- **Frontend / UI:** Razor Views (`.cshtml`), Tailwind CSS (vía CDN), FontAwesome 6
- **Entorno de Desarrollo:** Visual Studio 2022

---

## 📂 Estructura del Proyecto

```text
ControlEscolarWeb/
│
├── Controllers/
│   ├── HomeController.cs        # Endpoints de consulta rápida y actualización de calificaciones
│   └── AlumnosController.cs     # CRUD administrativo del directorio general de alumnos
│
├── Data/
│   └── ApplicationDbContext.cs  # Contexto de EF Core, índices y seed data inicial
│
├── Models/
│   ├── Alumno.cs                # Entidad de expediente estudiantil
│   └── CalificacionModulo.cs    # Entidad de materias/módulos vinculada 1:N
│
├── Views/
│   ├── Home/
│   │   └── Index.cshtml         # Interfaz de consulta rápida por matrícula y notas
│   ├── Alumnos/
│   │   └── Index.cshtml         # Directorio general con buscador en vivo
│   └── Shared/
│       └── _Layout.cshtml       # Plantilla base con barra de navegación unificada
│
├── appsettings.json             # Cadena de conexión a SQL Server LocalDB
├── Program.cs                   # Configuración del pipeline HTTP y EnsureCreated()
└── ControlEscolarWeb.csproj     # Dependencias de paquetes NuGet
```

---

## 🚀 Requisitos Previos

- Windows 10/11
- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [Visual Studio 2022](https://visualstudio.microsoft.com/) con la carga de trabajo **ASP.NET y desarrollo web** instalada
- Instancia activa de **SQL Server LocalDB** (incluida con Visual Studio)

---

## ⚙️ Puesta en Marcha

### 1. Clonar o descomprimir el proyecto
Abre la solución `ControlEscolarWeb.sln` directamente en Visual Studio.

### 2. Verificar la cadena de conexión
En el archivo `appsettings.json`, asegúrate de contar con la cadena de conexión predeterminada:
```json
"ConnectionStrings": {
  "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=ControlEscolarDb;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True"
}
```

### 3. Ejecutar la aplicación
Presiona **F5** (o selecciona el botón verde de reproducción en Visual Studio).
- `Program.cs` ejecutará `EnsureCreated()`, generando automáticamente la base de datos `ControlEscolarDb`, las tablas y los registros iniciales con los 8 módulos.
- Se abrirá automáticamente el navegador en `https://localhost:xxxx`.

---

## 🗄️ Carga de Registros Completos (Opcional)

Si deseas importar los más de 260 alumnos desde el script generado:
1. En Visual Studio, ve a **Ver** -> **Explorador de objetos de SQL Server** (`Ctrl + \, Ctrl + S`).
2. Expande `(localdb)\MSSQLLocalDB` -> `Bases de datos` -> `ControlEscolarDb`.
3. Haz clic derecho sobre `ControlEscolarDb` y selecciona **Nueva consulta...**.
4. Pega el contenido de `insertar_datos.sql` y presiona **Ejecutar** (`Ctrl + Shift + E`).

---

## 👨‍💻 Autor

- **Alexis Rogerio Campos Esquivel**  
  Estudiante de Ingeniería en Sistemas Computacionales  
  *Instituto Tecnológico de Campeche (TecNM)*  
  Residencia Profesional en el **Colegio Profesional de Campeche (CPC)**
