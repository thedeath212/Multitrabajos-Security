using Microsoft.EntityFrameworkCore;
using MultitrabajosSecurity.Data;
using MultitrabajosSecurity.Repositories;
using MultitrabajosSecurity.Services;

var builder = WebApplication.CreateBuilder(args);

// Agregar servicios al contenedor
builder.Services.AddControllers();

// Registrar el DbContext con la cadena de conexión
builder.Services.AddDbContext<Contexto>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Registrar servicios en el contenedor
builder.Services.AddScoped<IServiceLogin, ServiceLogin>();
builder.Services.AddScoped<IServiceUsers, ServiceUser>();

// Configurar autenticación (ajusta esto según tus necesidades)
builder.Services.AddAuthentication("CookieAuthentication")
    .AddCookie("CookieAuthentication", options =>
    {
        options.LoginPath = "/Account/Login";
        options.AccessDeniedPath = "/Account/AccessDenied";
    });

var app = builder.Build();

// Crear base de datos si no existe
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    try
    {
        var context = services.GetRequiredService<Contexto>();
        Dbinitial.Initialize(context);
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "An error occurred creating the DB.");
    }
}

// Usar autenticación
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
