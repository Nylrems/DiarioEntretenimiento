
using DiarioEntretenimiento.LogicaNegocio.Servicios;

var builder = WebApplication.CreateBuilder(args);

// Habilitando el uso de Controladores (lectura del EntretenimientoController)
builder.Services.AddControllers();

// Configurando Swagger (esto sirve para probar la API)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Inyección de dependencias (La parte más importante de la arquitectura)
// Aquí se crea el ServicioEntretenimiento.
string cadenaConexion = builder.Configuration.GetConnectionString("DefaultConnetion");

// Con "AddScoped" se crea una nueva instancia por cada petición HTTP.
builder.Services.AddScoped<ServicioEntretenimiento>(provider =>
    new ServicioEntretenimiento(cadenaConexion));

// Configurando el CORS (para la comunicación con React)
builder.Services.AddCors(options =>
{
    options.AddPolicy("NuevaPolitica", app =>
    {
        app.AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});

var app = builder.Build();

// Configuración de Swagger solo para dev
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Con esto activamos la política de CORS definida arriba
app.UseCors("NuevaPolitica");

app.UseAuthorization();

//Mapea los controladores: esto buscan las clases que heredan de ControllerBase
// y expone las rutas como (api/entretenimiento)
app.MapControllers();

app.Run();