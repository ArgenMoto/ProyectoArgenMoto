using Application.Interfaces.Commands;
using Application.Interfaces.Queries;
using Application.Interfaces.Services;
using Application.UseCase;
using Infraestructure.Commands;
using Infraestructure.Persistense;
using Infraestructure.Queries;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var connectionStrings = new[]
{
    builder.Configuration.GetConnectionString("DefaultConnection1"),
    builder.Configuration.GetConnectionString("DefaultConnection2"),
    builder.Configuration.GetConnectionString("DefaultConnection3"),
    builder.Configuration.GetConnectionString("DefaultConnection4")
};

string? selectedConnectionString = null;

foreach (var connectionString in connectionStrings)
{
    try
    {
        // Intenta conectarte a la base de datos
        var optionsBuilder = new DbContextOptionsBuilder<ArgenMotoDbContext>();
        optionsBuilder.UseSqlServer(connectionString);

        using (var context = new ArgenMotoDbContext(optionsBuilder.Options))
        {
            if (context.Database.CanConnect()) // Verifica si se puede conectar
            {
                selectedConnectionString = connectionString;
                Console.WriteLine($"Conexión: {connectionString}");
                break;
            }
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error conectando con la cadena: {connectionString}. Error: {ex.Message}");
    }
}

if (selectedConnectionString != null)
{
    builder.Services.AddDbContext<ArgenMotoDbContext>(options =>
    {
        options.UseSqlServer(selectedConnectionString);
    });
}
else
{
    throw new Exception("No se pudo conectar a ninguna de las bases de datos.");
}
builder.Services.AddScoped<IProveedorQuery, ProveedorQuery>();
builder.Services.AddScoped<IProveedorService, ProveedorServices>();
builder.Services.AddScoped<IProveedorCommand, ProveedorCommand>();

builder.Services.AddScoped<IVendedorQuery, VendedorQuery>();
builder.Services.AddScoped<IVendedorService, VendedorServices>();
builder.Services.AddScoped<IVendedorCommand, VendedorCommand>();

builder.Services.AddScoped<IClienteQuery, ClienteQuery>();
builder.Services.AddScoped<IClienteService, ClienteServices>();
builder.Services.AddScoped<IClienteCommand, ClienteCommand>();

builder.Services.AddScoped<IProductoQuery, ProductoQuery>();
builder.Services.AddScoped<IProductoService, ProductoServices>();
builder.Services.AddScoped<IProductoCommand, ProductoCommand>();

// Habilitar CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigins",
        builder =>
        {
            builder.WithOrigins("http://localhost:5500", "http://127.0.0.1:5500")
                   .AllowAnyHeader()
                   .AllowAnyMethod();
        });
});

var app = builder.Build();
// Comentario de cambio
// Estoy trabajando en mi rama Cliente
// Estoy Trabajando en mi rama Producto
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Usar CORS
app.UseCors("AllowSpecificOrigins");

app.UseAuthorization();

app.MapControllers();

app.Run();