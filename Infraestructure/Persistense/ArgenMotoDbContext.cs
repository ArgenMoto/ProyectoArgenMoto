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
                   new Producto { ProductoId = 1, Nombre = "Yamaha MT-07", Marca = "Yamaha", Descripcion = "Motocicleta deportiva ligera y ágil.", Modelo = "MT-07", NumeroMotor = 123456, NumeroChasis = 789012, Cilindro = 689, Fecha = 2024, PrecioUnitario = 150000, Rubro = "Motocicleta", StockMinimo = 3, StockMaximo = 100, StockActual = 6 , Imagen = "https://i.postimg.cc/rpJWcK0L/2023-Yamaha-MT07-A-EU-Cyan-Storm-360-Degrees-001-03.jpg" },
                   new Producto { ProductoId = 2, Nombre = "Honda CB500F", Marca = "Honda", Descripcion = "Motocicleta naked para uso urbano y carretera.", Modelo = "CB500F", NumeroMotor = 223344, NumeroChasis = 334455, Cilindro = 500, Fecha = 2024, PrecioUnitario = 180000, Rubro = "Motocicleta", StockMinimo = 3, StockMaximo = 100, StockActual = 7, Imagen = "https://i.postimg.cc/50KCYTS7/honda-cb-500-f.jpg"},
                   new Producto { ProductoId = 3, Nombre = "Kawasaki Ninja 400", Marca = "Kawasaki", Descripcion = "Motocicleta deportiva de baja cilindrada.", Modelo = "Ninja 400", NumeroMotor = 556677, NumeroChasis = 889900, Cilindro = 399, Fecha = 2024, PrecioUnitario = 200000, Rubro = "Motocicleta", StockMinimo = 3, StockMaximo = 100, StockActual = 10, Imagen = "https://i.postimg.cc/tJVY1TTJ/ninja400-KRT-1-1.jpg"},
                   new Producto { ProductoId = 4, Nombre = "Suzuki V-Strom 650", Marca = "Suzuki", Descripcion = "Motocicleta adventure de media cilindrada.", Modelo = "V-Strom 650", NumeroMotor = 998877, NumeroChasis = 665544, Cilindro = 645, Fecha = 2024, PrecioUnitario = 160000, Rubro = "Motocicleta", StockMinimo = 3, StockMaximo = 100, StockActual = 8, Imagen = "https://i.postimg.cc/NjtkchJm/muo3kk8n0sjdherhbjzvqyytgylzz8hcmvkfdusy.jpg"},
                   new Producto { ProductoId = 5, Nombre = "BMW R 1250 GS", Marca = "BMW", Descripcion = "Motocicleta adventure de alta gama.", Modelo = "R 1250 GS", NumeroMotor = 554433, NumeroChasis = 223344, Cilindro = 1254, Fecha = 2024, PrecioUnitario = 300000, Rubro = "Motocicleta", StockMinimo = 3, StockMaximo = 100, StockActual = 4, Imagen = "https://i.postimg.cc/W4WGgd2w/image.jpg"},
                   new Producto { ProductoId = 6, Nombre = "Ducati Monster 821", Marca = "Ducati", Descripcion = "Motocicleta naked de alto rendimiento.", Modelo = "Monster 821", NumeroMotor = 112233, NumeroChasis = 445566, Cilindro = 821, Fecha = 2024, PrecioUnitario = 250000, Rubro = "Motocicleta", StockMinimo = 3, StockMaximo = 100, StockActual = 4, Imagen = "https://i.postimg.cc/RCn7JC2w/Monster-821-MY18-Red-01-Model-Preview-1050x650.png"},
                   new Producto { ProductoId = 7, Nombre = "Harley-Davidson Iron 883", Marca = "Harley-Davidson", Descripcion = "Motocicleta cruiser clásica.", Modelo = "Iron 883", NumeroMotor = 778899, NumeroChasis = 123456, Cilindro = 883, Fecha = 2024, PrecioUnitario = 400000, Rubro = "Motocicleta", StockMinimo = 3, StockMaximo = 100, StockActual = 5, Imagen = "https://i.postimg.cc/X7SwfS0m/54c33236a8ad91156a9e611375b4d973-a18dd478b82157f1.png"}


               );

                modelBuilder.Entity<Cliente>().HasData(
                    new Cliente { ClienteId = 1, DNI = 12345678, Nombre = "Juan", Apellido = "Pérez", Domicilio = "Calle 30 214", Localidad = "Quilmes", Provincia = "Buenos Aires", Telefono = 422589654, Email = "carlos@gmail.com" },
                    new Cliente { ClienteId = 2, DNI = 23456789, Nombre = "Ana", Apellido = "García",Domicilio = "Calle 30 231",Localidad = "Florencio Varela", Provincia = "Buenos Aires",Telefono = 45678932,Email = "garciana@gmail.com"},
                    new Cliente { ClienteId = 3, DNI = 34567890, Nombre = "Luis", Apellido = "Martínez",Domicilio = "Calle 12 1024",Localidad = "Berazategui", Provincia = "Buenos Aires",Telefono = 1124568935,Email = "luis@gmail.com" },
                    new Cliente { ClienteId = 4, DNI = 45678901, Nombre = "Marta", Apellido = "Lopez",Domicilio = "Calle 28 1235",Localidad = "Berazategui",Provincia = "Buenos Aires",Telefono = 1124567835, Email = "marta@yahoo.com"},
                    new Cliente { ClienteId = 5, DNI = 56789012, Nombre = "Carlos", Apellido = "Fernández",Domicilio = "Mitre 1234", Localidad = "Quilmes", Provincia = "Buenos Aires", Telefono = 1145623789,Email = "carlitos@yahoo.com"}
                );

                modelBuilder.Entity<Proveedor>().HasData(
                    new Proveedor {
                        ProveedorId = 1,
                        Cuit = "20234567897",
                        RazonSocial = "Moto Parts Ltd.",
                        Direccion = "Av. Libertador 1234",
                        Localidad = "Capital Federal",
                        Provincia = "Buenos Aires",
                        Apellido = "Perez",
                        Nombre = "Juan",
                        Telefono = 01112345678,
                        Email = "juan@gmail.com"
                    },
                    new Proveedor {
                        ProveedorId = 2,
                        Cuit = "20234567899",
                        RazonSocial = "Moto Accessories S.A.",
                        Direccion = "Calle Falsa 5678",
                        Localidad = "Quilmes",
                        Provincia = "Buenos Aires",
                        Apellido = "Torres",
                        Nombre = "Gabriel",
                        Telefono = 01123456789,
                        Email = "torres@yahoo,com"
                    },
                    new Proveedor {
                        ProveedorId = 3,
                        Cuit = "23415689741",
                        RazonSocial = "Motorcycle World",
                        Direccion = "Avenida Rivadavia 4321",
                        Localidad = "Florencio Varela",
                        Provincia = "Buenos Aires",
                        Apellido = "Sanchez",
                        Nombre = "Ramon",
                        Telefono = 0114567890,
                        Email = "ramon@gmail.com"
                    },
                    new Proveedor {
                        ProveedorId = 4,
                        Cuit = "20356457899",
                        RazonSocial = "Bike Gear Co.",
                        Direccion = "Calle Moreno 8765",
                        Localidad = "Capital Federal",
                        Provincia = "Buenos Aires",
                        Apellido = "Cuello",
                        Nombre = "Marcos",
                        Telefono = 01145678901,
                        Email = "marcos@gmail.com"
                    },
                    new Proveedor {
                        ProveedorId = 5,
                        Cuit = "23367894567",
                        RazonSocial = "Moto Supplies Inc.",
                        Direccion = "Calle Alem 9876",
                        Localidad = "La Plata",
                        Provincia = "Buenos Aires",
                        Apellido = "Bernis",
                        Nombre = "Jose",
                        Telefono = 01156789012,
                        Email = "bernis@hotmail.com"
                    }
                );

                modelBuilder.Entity<Vendedor>().HasData(
                    new Vendedor
                    {
                        VendedorId = 1,
                        VendedorNombre = "Pedro",
                        VendedorApellido = "Gomez",
                        VendedorPuesto = "Vendedor Principal",
                        VendedorDni = 33456789,
                        VendedorDomicilio = "Calle 30 2659",
                        VendedorLocalidad = "Berazategui",
                        VendedorProvincia = "Buenos Aires",
                        VendedorTelefono = 1523467895,
                        VendedorEmail = "pedro@gmail.com"
                    },
                    new Vendedor
                        {
                        VendedorId = 2,
                        VendedorNombre = "Laura",
                        VendedorApellido = "Rodriguez",
                        VendedorPuesto = "Vendedora",
                        VendedorDni = 40256897,
                        VendedorDomicilio = "Calle 132 4567",
                        VendedorLocalidad = "Berazategui",
                        VendedorProvincia = "Buenos Aires",
                        VendedorTelefono = 1547896321,
                        VendedorEmail = "laura@gmail.com"
                        },
                    new Vendedor
                    {
                        VendedorId = 3,
                        VendedorNombre = "Andrés",
                        VendedorApellido = "Gimenez",
                        VendedorPuesto = "Vendedor",
                        VendedorDni = 38526478,
                        VendedorDomicilio = "Calle 145 5047",
                        VendedorLocalidad = "Berazategui",
                        VendedorProvincia = "Buenos Aires",
                        VendedorTelefono = 1578451236,
                        VendedorEmail = "andres@gmail.com"
                    },
                    new Vendedor
                    {
                        VendedorId = 4,
                        VendedorNombre = "Sofía",
                        VendedorApellido = "Saucedo",
                        VendedorPuesto = "Vendedora",
                        VendedorDni = 23456789,
                        VendedorDomicilio = "Calle 38 4568",
                        VendedorLocalidad = "Berazategui",
                        VendedorProvincia = "Buenos Aires",
                        VendedorTelefono = 1547526389,
                        VendedorEmail = "sofia@gmail.com"
                    },
                    new Vendedor
                    {
                        VendedorId = 5,
                        VendedorNombre = "Miguel",
                        VendedorApellido = "Souto",
                        VendedorPuesto = "Vendedor ",
                        VendedorDni = 34568791,
                        VendedorDomicilio = "Calle 33 2356",
                        VendedorLocalidad = "Berazategui",
                        VendedorProvincia = "Buenos Aires",
                        VendedorTelefono = 1545678912,
                        VendedorEmail = "miguel@gmail.com"
                    }
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
