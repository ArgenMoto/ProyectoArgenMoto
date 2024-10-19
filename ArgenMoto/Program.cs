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
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection2"));
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
builder.Services.AddScoped<IItemQuery, ItemQuery>();

builder.Services.AddScoped<IDocumentoQuery, DocumentoQuery>();
builder.Services.AddScoped<IDocumentoService, DocumentoServices>();
builder.Services.AddScoped<IMedioPagoQuery, MedioPagoQuery>();

builder.Services.AddScoped<IVentaCommand, VentaCommand>();
builder.Services.AddScoped<IVentaService, VentaServices>();

builder.Services.AddScoped<IMedioPagoQuery, MedioPagoQuery>();
builder.Services.AddScoped<IMedioPagoCommand, MedioPagoCommand>();
builder.Services.AddScoped<IMedioPagoService, MedioPagoServices>();

builder.Services.AddScoped<IFacturaCommand, FacturaCommand>();
builder.Services.AddScoped<IFacturaService, FacturaServices>();
builder.Services.AddScoped<IFacturaQuery, FacturaQuery>();

builder.Services.AddScoped<IOrdenDeCompraProductoCommand, OrdenDeCompraProductoCommand>();

builder.Services.AddScoped<IOrdenDeCompraService, OrdenDeCompraServices>();
builder.Services.AddScoped<IOrdenDeCompraCommand, OrdenDeCompraCommand>();
builder.Services.AddScoped<IOrdenDeCompraQuery, OrdenDeCompraQuery>();

builder.Services.AddScoped<IArticuloQuery, ArticuloQuery>();
builder.Services.AddScoped<IArticuloService, ArticuloServices>();
builder.Services.AddScoped<IArticuloCommand, ArticuloCommand>();
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