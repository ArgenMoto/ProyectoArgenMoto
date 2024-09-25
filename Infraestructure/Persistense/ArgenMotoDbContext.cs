using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Persistense
{
    public class ArgenMotoDbContext : DbContext
    {
        public ArgenMotoDbContext() { }

        public ArgenMotoDbContext(DbContextOptions<ArgenMotoDbContext> options) : base(options) { }

        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Factura> Factura { get; set; }
        public DbSet<Proveedor> Proveedor { get; set; }
        public DbSet<Producto> Producto { get; set; }
        public DbSet<Venta> Venta { get; set; }
        public DbSet<OrdenDeCompra> OrdenDeCompra { get; set; }
        public DbSet<MedioPago> MedioPago { get; set; }
        public DbSet<Documento> Documento { get; set; }
        public DbSet<Vendedor> Vendedor { get; set; }
        public DbSet<Item> Item { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Producto>(entity =>
            {
                entity.ToTable("Producto");
                entity.HasKey(x => x.ProductoId);

            });

            modelBuilder.Entity<Proveedor>(entity =>
            {
                entity.ToTable("Proveedor");
                entity.HasKey(x => x.ProveedorId);

            });
            modelBuilder.Entity<Vendedor>(entity =>
            {
                entity.ToTable("Vendedor");
                entity.HasKey(x => x.VendedorId);

            });
            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.ToTable("Cliente");
                entity.HasKey(x => x.ClienteId);

            });
            modelBuilder.Entity<Item>(entity =>
            {
                entity.ToTable("ItemDetalle");
                entity.HasKey(x => x.ItemId);

                entity.Property(x => x.ProductoId)
                .HasColumnName("Producto");

                entity.Property(x => x.VentaId)
                .HasColumnName("Venta");

                entity.HasOne(x => x.Venta).WithMany(a => a.Items).HasForeignKey(x => x.VentaId);
                entity.HasOne(x => x.Producto).WithMany(a => a.Items).HasForeignKey(x => x.ProductoId);
            });
            modelBuilder.Entity<Documento>(entity =>
            {
                entity.ToTable("Documento");
                entity.HasKey(x => x.DocumentoId);
                ;
            });
            modelBuilder.Entity<OrdenDeCompra>(entity =>
            {
                entity.ToTable("OrdenDeCompra");

                entity.HasKey(x => x.OrdenId);

                entity.Property(x => x.ProductoId)
                .HasColumnName("Producto");

                entity.Property(x => x.ProveedorId)
                .HasColumnName("Proveedor");

                entity.HasOne(x => x.Producto).WithMany(a => a.OrdenesDeCompra).HasForeignKey(x => x.ProductoId);
                entity.HasOne(x => x.Proveedor).WithMany(a => a.OrdenesDeCompra).HasForeignKey(x => x.ProveedorId);

            });
            modelBuilder.Entity<Factura>(entity =>
            {
                entity.ToTable("Factura");
                entity.HasKey(x => x.FacturaId);

                entity.Property(x => x.MedioPagoId)
                .HasColumnName("MedioDePago");

                entity.HasOne(x => x.Documento).WithMany(a => a.Facturas).HasForeignKey(x => x.DocumentoId);
                entity.HasOne(x => x.MedioPago).WithMany(a => a.Facturas).HasForeignKey(x => x.MedioPagoId);

            });
            modelBuilder.Entity<Venta>(entity =>
            {
                entity.ToTable("Venta");

                entity.HasKey(x => x.VentaId);

                entity.Property(x => x.ClienteId)
                .HasColumnName("cliente");

                entity.Property(x => x.VendedorId)
                .HasColumnName("Vendedor");

                entity.HasOne(x => x.Cliente).WithMany(a => a.Ventas).HasForeignKey(x => x.ClienteId);
                entity.HasOne(x => x.Vendedor).WithMany(a => a.Ventas).HasForeignKey(x => x.VendedorId);
                entity.HasOne<Factura>(x => x.factura).WithOne(a => a.Venta).HasForeignKey<Factura>(x => x.VentaId);

                modelBuilder.Entity<Producto>().HasData(
                   new Producto { ProductoId = 1, Nombre = "Yamaha MT-07", Descripcion = "Motocicleta deportiva ligera y ágil.", Marca = "Yamaha", PrecioUnitario = 150000, Stock = 5, Imagen = "https://i.postimg.cc/rpJWcK0L/2023-Yamaha-MT07-A-EU-Cyan-Storm-360-Degrees-001-03.jpg", Rubro = "Motocicleta" },
                   new Producto { ProductoId = 2, Nombre = "Honda CB500F", Descripcion = "Motocicleta naked para uso urbano y carretera.", Marca = "Honda", PrecioUnitario = 180000, Stock = 7, Imagen = "https://i.postimg.cc/50KCYTS7/honda-cb-500-f.jpg", Rubro = "Motocicleta" },
                   new Producto { ProductoId = 3, Nombre = "Kawasaki Ninja 400", Descripcion = "Motocicleta deportiva de baja cilindrada.", Marca = "Kawasaki", PrecioUnitario = 200000, Stock = 10, Imagen = "https://i.postimg.cc/tJVY1TTJ/ninja400-KRT-1-1.jpg", Rubro = "Motocicleta" },
                   new Producto { ProductoId = 4, Nombre = "Suzuki V-Strom 650", Descripcion = "Motocicleta adventure de media cilindrada.", Marca = "Suzuki", PrecioUnitario = 160000, Stock = 8, Imagen = "https://i.postimg.cc/NjtkchJm/muo3kk8n0sjdherhbjzvqyytgylzz8hcmvkfdusy.jpg", Rubro = "Motocicleta" },
                   new Producto { ProductoId = 5, Nombre = "BMW R 1250 GS", Descripcion = "Motocicleta adventure de alta gama.", Marca = "BMW", PrecioUnitario = 300000, Stock = 3, Imagen = "https://i.postimg.cc/W4WGgd2w/image.jpg", Rubro = "Motocicleta" },
                   new Producto { ProductoId = 6, Nombre = "Ducati Monster 821", Descripcion = "Motocicleta naked de alto rendimiento.", Marca = "Ducati", PrecioUnitario = 250000, Stock = 4, Imagen = "https://i.postimg.cc/RCn7JC2w/Monster-821-MY18-Red-01-Model-Preview-1050x650.png", Rubro = "Motocicleta" },
                   new Producto { ProductoId = 7, Nombre = "Harley-Davidson Iron 883", Descripcion = "Motocicleta cruiser clásica.", Marca = "Harley-Davidson", PrecioUnitario = 400000, Stock = 2, Imagen = "https://i.postimg.cc/X7SwfS0m/54c33236a8ad91156a9e611375b4d973-a18dd478b82157f1.png", Rubro = "Motocicleta" }


               );

                modelBuilder.Entity<Cliente>().HasData(
                    new Cliente { ClienteId = 1, DNI = "12345678", Nombre = "Juan", Apellido = "Pérez" },
                    new Cliente { ClienteId = 2, DNI = "23456789", Nombre = "Ana", Apellido = "García" },
                    new Cliente { ClienteId = 3, DNI = "34567890", Nombre = "Luis", Apellido = "Martínez" },
                    new Cliente { ClienteId = 4, DNI = "45678901", Nombre = "Marta", Apellido = "Lopez" },
                    new Cliente { ClienteId = 5, DNI = "56789012", Nombre = "Carlos", Apellido = "Fernández" }
                );

                modelBuilder.Entity<Proveedor>().HasData(
                    new Proveedor { ProveedorId = 1, Nombre = "Moto Parts Ltd.", Direccion = "Av. Libertador 1234", Telefono = "011-12345678" },
                    new Proveedor { ProveedorId = 2, Nombre = "Moto Accessories S.A.", Direccion = "Calle Falsa 5678", Telefono = "011-23456789" },
                    new Proveedor { ProveedorId = 3, Nombre = "Motorcycle World", Direccion = "Avenida Rivadavia 4321", Telefono = "011-34567890" },
                    new Proveedor { ProveedorId = 4, Nombre = "Bike Gear Co.", Direccion = "Calle Moreno 8765", Telefono = "011-45678901" },
                    new Proveedor { ProveedorId = 5, Nombre = "Moto Supplies Inc.", Direccion = "Calle Alem 9876", Telefono = "011-56789012" }
                );

                modelBuilder.Entity<Vendedor>().HasData(
                    new Vendedor { VendedorId = 1, Nombre = "Pedro", Puesto = "Vendedor Principal" },
                    new Vendedor { VendedorId = 2, Nombre = "Laura", Puesto = "Vendedora" },
                    new Vendedor { VendedorId = 3, Nombre = "Andrés", Puesto = "Vendedor" },
                    new Vendedor { VendedorId = 4, Nombre = "Sofía", Puesto = "Vendedora" },
                    new Vendedor { VendedorId = 5, Nombre = "Miguel", Puesto = "Vendedor" }
                );

                modelBuilder.Entity<Documento>().HasData(
                    new Documento { DocumentoId = 1, Descripcion = "Factura A" },
                    new Documento { DocumentoId = 2, Descripcion = "Factura B" },
                    new Documento { DocumentoId = 3, Descripcion = "Nota de Crédito" },
                    new Documento { DocumentoId = 4, Descripcion = "Nota de Débito" },
                    new Documento { DocumentoId = 5, Descripcion = "Recibo" },
                    new Documento { DocumentoId = 6, Descripcion = "Orden de Compra" }
                );

                modelBuilder.Entity<MedioPago>().HasData(
                    new MedioPago { MedioPagoId = 1, Descripcion = "Efectivo" },
                    new MedioPago { MedioPagoId = 2, Descripcion = "Tarjeta de Crédito" },
                    new MedioPago { MedioPagoId = 3, Descripcion = "Tarjeta de Débito" },
                    new MedioPago { MedioPagoId = 4, Descripcion = "Transferencia Bancaria" },
                    new MedioPago { MedioPagoId = 5, Descripcion = "PayPal" }
                );
            });
        }
    }
}
