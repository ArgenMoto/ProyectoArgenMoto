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


builder.Services.AddDbContext<ArgenMotoDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection4"));
});

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

builder.Services.AddScoped<IItemCommand, ItemCommand>();
builder.Services.AddScoped<IFacturaCommand, FacturaCommand>();

builder.Services.AddScoped<IDocumentoQuery, DocumentoQuery>();
builder.Services.AddScoped<IMedioPagoQuery, MedioPagoQuery>();

builder.Services.AddScoped<IVentaCommand, VentaCommand>();
builder.Services.AddScoped<IVentaService, VentaServices>();

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