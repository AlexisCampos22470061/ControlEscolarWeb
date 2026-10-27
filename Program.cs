using Microsoft.EntityFrameworkCore;
using ControlEscolarWeb.Data;
using ControlEscolarWeb.Services;

var builder = WebApplication.CreateBuilder(args);

// Configuración de DbContext con SQL Server (LocalDB de Visual Studio)
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") 
    ?? "Server=(localdb)\\mssqllocaldb;Database=ControlEscolarDb;Trusted_Connection=True;MultipleActiveResultSets=true";

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddScoped<IMatriculaService, MatriculaService>();

// Add MVC
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Asegurar que la base de datos y la semilla se creen automáticamente al iniciar
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    context.Database.EnsureCreated();
}

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
