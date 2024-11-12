using EntityDAL.DAL.DBContext;
using EntityDAL.DAL.Repositories.Contratos;
using EntityDAL.DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using EntityBLL.BLL;




var builder = WebApplication.CreateBuilder(args);


// Configuración de CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("PermitirTodo", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});


//Se encarga de registrar el contexto de base de datos (DBDProductos) en el contenedor de servicios de ASP.NET Core.
// Configura el DbContext utilizando la cadena de conexión desde appsettings.json es para la ejecución normal de la aplicación
builder.Services.AddDbContext<DBDPersona>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
        b => b.MigrationsAssembly("EntityDAL"))); 





// Añadir servicios para controlar el registro
builder.Services.AddScoped<IProductoRepository, ProductoRepository>(); 
builder.Services.AddScoped<IProductoService, ProductoService>();


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


// Aplicar la política de CORS
app.UseCors("PermitirTodo");

// Configurar el pipeline HTTP aquí
app.UseAuthorization();
// Configurar el pipeline HTTP aquí (si es necesario)
app.MapControllers();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}



app.Run();
