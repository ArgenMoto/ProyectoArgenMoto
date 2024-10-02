﻿// <auto-generated />
using System;
using Infraestructure.Persistense;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infraestructure.Migrations
{
    [DbContext(typeof(ArgenMotoDbContext))]
    [Migration("20240925005748_init")]
    partial class init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Domain.Entities.Cliente", b =>
                {
                    b.Property<int>("ClienteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ClienteId"));

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DNI")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ClienteId");

                    b.ToTable("Cliente", (string)null);

                    b.HasData(
                        new
                        {
                            ClienteId = 1,
                            Apellido = "Pérez",
                            DNI = "12345678",
                            Nombre = "Juan"
                        },
                        new
                        {
                            ClienteId = 2,
                            Apellido = "García",
                            DNI = "23456789",
                            Nombre = "Ana"
                        },
                        new
                        {
                            ClienteId = 3,
                            Apellido = "Martínez",
                            DNI = "34567890",
                            Nombre = "Luis"
                        },
                        new
                        {
                            ClienteId = 4,
                            Apellido = "Lopez",
                            DNI = "45678901",
                            Nombre = "Marta"
                        },
                        new
                        {
                            ClienteId = 5,
                            Apellido = "Fernández",
                            DNI = "56789012",
                            Nombre = "Carlos"
                        });
                });

            modelBuilder.Entity("Domain.Entities.Documento", b =>
                {
                    b.Property<int>("DocumentoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DocumentoId"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DocumentoId");

                    b.ToTable("Documento", (string)null);

                    b.HasData(
                        new
                        {
                            DocumentoId = 1,
                            Descripcion = "Factura A"
                        },
                        new
                        {
                            DocumentoId = 2,
                            Descripcion = "Factura B"
                        },
                        new
                        {
                            DocumentoId = 3,
                            Descripcion = "Nota de Crédito"
                        },
                        new
                        {
                            DocumentoId = 4,
                            Descripcion = "Nota de Débito"
                        },
                        new
                        {
                            DocumentoId = 5,
                            Descripcion = "Recibo"
                        },
                        new
                        {
                            DocumentoId = 6,
                            Descripcion = "Orden de Compra"
                        });
                });

            modelBuilder.Entity("Domain.Entities.Factura", b =>
                {
                    b.Property<Guid>("FacturaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("DocumentoId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<int>("MedioPagoId")
                        .HasColumnType("int")
                        .HasColumnName("MedioDePago");

                    b.Property<int>("Total")
                        .HasColumnType("int");

                    b.Property<Guid>("VentaId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("FacturaId");

                    b.HasIndex("DocumentoId");

                    b.HasIndex("MedioPagoId");

                    b.HasIndex("VentaId")
                        .IsUnique();

                    b.ToTable("Factura", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Item", b =>
                {
                    b.Property<int>("ItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ItemId"));

                    b.Property<int>("Cantidad")
                        .HasColumnType("int");

                    b.Property<int>("PrecioTotalItem")
                        .HasColumnType("int");

                    b.Property<int>("ProductoId")
                        .HasColumnType("int")
                        .HasColumnName("Producto");

                    b.Property<Guid>("VentaId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("Venta");

                    b.HasKey("ItemId");

                    b.HasIndex("ProductoId");

                    b.HasIndex("VentaId");

                    b.ToTable("ItemDetalle", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.MedioPago", b =>
                {
                    b.Property<int>("MedioPagoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MedioPagoId"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MedioPagoId");

                    b.ToTable("MedioPago");

                    b.HasData(
                        new
                        {
                            MedioPagoId = 1,
                            Descripcion = "Efectivo"
                        },
                        new
                        {
                            MedioPagoId = 2,
                            Descripcion = "Tarjeta de Crédito"
                        },
                        new
                        {
                            MedioPagoId = 3,
                            Descripcion = "Tarjeta de Débito"
                        },
                        new
                        {
                            MedioPagoId = 4,
                            Descripcion = "Transferencia Bancaria"
                        },
                        new
                        {
                            MedioPagoId = 5,
                            Descripcion = "PayPal"
                        });
                });

            modelBuilder.Entity("Domain.Entities.OrdenDeCompra", b =>
                {
                    b.Property<Guid>("OrdenId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Cantidad")
                        .HasColumnType("int");

                    b.Property<int>("Precio")
                        .HasColumnType("int");

                    b.Property<int>("ProductoId")
                        .HasColumnType("int")
                        .HasColumnName("Producto");

                    b.Property<int>("ProveedorId")
                        .HasColumnType("int")
                        .HasColumnName("Proveedor");

                    b.Property<int>("Total")
                        .HasColumnType("int");

                    b.HasKey("OrdenId");

                    b.HasIndex("ProductoId");

                    b.HasIndex("ProveedorId");

                    b.ToTable("OrdenDeCompra", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Producto", b =>
                {
                    b.Property<int>("ProductoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductoId"));

                    b.Property<string>("Nombre")
                           .IsRequired()
                           .HasColumnType("nvarchar(max)");

                    b.Property<string>("Marca")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Modelo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumeroMotor")
                         .IsRequired()
                        .HasColumnType("int");

                    b.Property<int>("NumeroChasis")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<int>("Cilindro")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<int>("Fecha")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<string>("Rubro")
                       .IsRequired()
                       .HasColumnType("nvarchar(max)");

                    b.Property<int>("PrecioUnitario")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<int>("StockMinimo")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<int>("StockMaximo")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<int>("StockActual")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<string>("Imagen")
                       .IsRequired()
                       .HasColumnType("nvarchar(max)");

                    b.HasKey("ProductoId");

                    b.ToTable("Producto", (string)null);

                    b.HasData(
                       new
                       {
                           ProductoId = 1,
                           Nombre = "Yamaha MT-07",
                           Marca = "Yamaha",
                           Descripcion = "Motocicleta deportiva ligera y ágil.",
                           Modelo = "MT-07",
                           NumeroMotor = 123456,
                           NumeroChasis = 789012,
                           Cilindro = 689,
                           Fecha = 2024,
                           Rubro = "Motocicleta",
                           PrecioUnitario = 150000,
                           StockMinimo = 3,
                           StockMaximo = 100,
                           StockActual = 6,
                           Imagen = "https://i.postimg.cc/rpJWcK0L/2023-Yamaha-MT07-A-EU-Cyan-Storm-360-Degrees-001-03.jpg"
                       },
                       new
                       {
                           ProductoId = 2,
                           Nombre = "Honda CB500F",
                           Marca = "Honda",
                           Descripcion = "Motocicleta naked para uso urbano y carretera.",
                           Modelo = "CB500F",
                           NumeroMotor = 223344,
                           NumeroChasis = 334455,
                           Cilindro = 500,
                           Fecha = 2024,
                           Rubro = "Motocicleta",
                           PrecioUnitario = 180000,
                           StockMinimo = 3,
                           StockMaximo = 100,
                           StockActual = 7,
                           Imagen = "https://i.postimg.cc/50KCYTS7/honda-cb-500-f.jpg"
                       },

                      new
                      {
                          ProductoId = 3,
                          Nombre = "Kawasaki Ninja 400",
                          Marca = "Kawasaki",
                          Descripcion = "Motocicleta deportiva de baja cilindrada.",
                          Modelo = "Ninja 400",
                          NumeroMotor = 556677,
                          NumeroChasis = 889900,
                          Cilindro = 399,
                          Fecha = 2024,
                          Rubro = "Motocicleta",
                          PrecioUnitario = 200000,
                          StockMinimo = 3,
                          StockMaximo = 100,
                          StockActual = 10,
                          Imagen = "https://i.postimg.cc/tJVY1TTJ/ninja400-KRT-1-1.jpg"
                      },

                      new
                      {
                          ProductoId = 4,
                          Nombre = "Suzuki V-Strom 650",
                          Marca = "Suzuki",
                          Descripcion = "Motocicleta adventure de media cilindrada.",
                          Modelo = "V-Strom 650",
                          NumeroMotor = 998877,
                          NumeroChasis = 665544,
                          Cilindro = 645,
                          Fecha = 2024,
                          Rubro = "Motocicleta",
                          PrecioUnitario = 160000,
                          StockMinimo = 3,
                          StockMaximo = 100,
                          StockActual = 8,
                          Imagen = "https://i.postimg.cc/NjtkchJm/muo3kk8n0sjdherhbjzvqyytgylzz8hcmvkfdusy.jpg"
                      },
                      new
                      {
                          ProductoId = 5,
                          Nombre = "BMW R 1250 GS",
                          Marca = "BMW",
                          Descripcion = "Motocicleta adventure de alta gama.",
                          Modelo = "R 1250 GS",
                          NumeroMotor = 554433,
                          NumeroChasis = 223344,
                          Cilindro = 1254,
                          Fecha = 2024,
                          Rubro = "Motocicleta",
                          PrecioUnitario = 300000,
                          StockMinimo = 3,
                          StockMaximo = 100,
                          StockActual = 4,
                          Imagen = "https://i.postimg.cc/W4WGgd2w/image.jpg"
                      },

                      new
                      {
                          ProductoId = 6,
                          Nombre = "Ducati Monster 821",
                          Marca = "Ducati",
                          Descripcion = "Motocicleta naked de alto rendimiento.",
                          Modelo = "Monster 821",
                          NumeroMotor = 112233,
                          NumeroChasis = 445566,
                          Cilindro = 821,
                          Fecha = 2024,
                          Rubro = "Motocicleta",
                          PrecioUnitario = 250000,
                          StockMinimo = 3,
                          StockMaximo = 100,
                          StockActual = 4,
                          Imagen = "https://i.postimg.cc/RCn7JC2w/Monster-821-MY18-Red-01-Model-Preview-1050x650.png"
                      },

                      new
                      {
                          ProductoId = 7,
                          Nombre = "Harley-Davidson Iron 883",
                          Marca = "Harley-Davidson",
                          Descripcion = "Motocicleta cruiser clásica.",
                          Modelo = "Iron 883",
                          NumeroMotor = 778899,
                          NumeroChasis = 123456,
                          Cilindro = 883,
                          Fecha = 2024,
                          Rubro = "Motocicleta",
                          PrecioUnitario = 400000,
                          StockMinimo = 3,
                          StockMaximo = 100,
                          StockActual = 5,
                          Imagen = "https://i.postimg.cc/X7SwfS0m/54c33236a8ad91156a9e611375b4d973-a18dd478b82157f1.png"
                      });

                });

            modelBuilder.Entity("Domain.Entities.Proveedor", b =>
                {
                    b.Property<int>("ProveedorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProveedorId"));

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProveedorId");

                    b.ToTable("Proveedor", (string)null);

                    b.HasData(
                        new
                        {
                            ProveedorId = 1,
                            Direccion = "Av. Libertador 1234",
                            Nombre = "Moto Parts Ltd.",
                            Telefono = "011-12345678"
                        },
                        new
                        {
                            ProveedorId = 2,
                            Direccion = "Calle Falsa 5678",
                            Nombre = "Moto Accessories S.A.",
                            Telefono = "011-23456789"
                        },
                        new
                        {
                            ProveedorId = 3,
                            Direccion = "Avenida Rivadavia 4321",
                            Nombre = "Motorcycle World",
                            Telefono = "011-34567890"
                        },
                        new
                        {
                            ProveedorId = 4,
                            Direccion = "Calle Moreno 8765",
                            Nombre = "Bike Gear Co.",
                            Telefono = "011-45678901"
                        },
                        new
                        {
                            ProveedorId = 5,
                            Direccion = "Calle Alem 9876",
                            Nombre = "Moto Supplies Inc.",
                            Telefono = "011-56789012"
                        });
                });

            modelBuilder.Entity("Domain.Entities.Vendedor", b =>
                {
                    b.Property<int>("VendedorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("VendedorId"));

                    b.Property<string>("VendedorNombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VendedorApellido")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VendedorPuesto")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("VendedorDni")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<string>("VendedorDomicilio")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VendedorLocalidad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VendedorProvincia")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("VendedorTelefono")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<string>("VendedorEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");
                    b.HasKey("VendedorId");

                    b.ToTable("Vendedor", (string)null);

                    b.HasData(
                        new
                        {
                            VendedorId = 1,
                            Nombre = "Pedro",
                            Puesto = "Vendedor Principal"
                        },
                        new
                        {
                            VendedorId = 2,
                            Nombre = "Laura",
                            Puesto = "Vendedora"
                        },
                        new
                        {
                            VendedorId = 3,
                            Nombre = "Andrés",
                            Puesto = "Vendedor"
                        },
                        new
                        {
                            VendedorId = 4,
                            Nombre = "Sofía",
                            Puesto = "Vendedora"
                        },
                        new
                        {
                            VendedorId = 5,
                            Nombre = "Miguel",
                            Puesto = "Vendedor"
                        });
                });

            modelBuilder.Entity("Domain.Entities.Venta", b =>
                {
                    b.Property<Guid>("VentaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("ClienteId")
                        .HasColumnType("int")
                        .HasColumnName("cliente");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<int>("TotalVenta")
                        .HasColumnType("int");

                    b.Property<int>("VendedorId")
                        .HasColumnType("int")
                        .HasColumnName("Vendedor");

                    b.HasKey("VentaId");

                    b.HasIndex("ClienteId");

                    b.HasIndex("VendedorId");

                    b.ToTable("Venta", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Factura", b =>
                {
                    b.HasOne("Domain.Entities.Documento", "Documento")
                        .WithMany("Facturas")
                        .HasForeignKey("DocumentoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.MedioPago", "MedioPago")
                        .WithMany("Facturas")
                        .HasForeignKey("MedioPagoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Venta", "Venta")
                        .WithOne("factura")
                        .HasForeignKey("Domain.Entities.Factura", "VentaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Documento");

                    b.Navigation("MedioPago");

                    b.Navigation("Venta");
                });

            modelBuilder.Entity("Domain.Entities.Item", b =>
                {
                    b.HasOne("Domain.Entities.Producto", "Producto")
                        .WithMany("Items")
                        .HasForeignKey("ProductoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Venta", "Venta")
                        .WithMany("Items")
                        .HasForeignKey("VentaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Producto");

                    b.Navigation("Venta");
                });

            modelBuilder.Entity("Domain.Entities.OrdenDeCompra", b =>
                {
                    b.HasOne("Domain.Entities.Producto", "Producto")
                        .WithMany("OrdenesDeCompra")
                        .HasForeignKey("ProductoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Proveedor", "Proveedor")
                        .WithMany("OrdenesDeCompra")
                        .HasForeignKey("ProveedorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Producto");

                    b.Navigation("Proveedor");
                });

            modelBuilder.Entity("Domain.Entities.Venta", b =>
                {
                    b.HasOne("Domain.Entities.Cliente", "Cliente")
                        .WithMany("Ventas")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Vendedor", "Vendedor")
                        .WithMany("Ventas")
                        .HasForeignKey("VendedorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");

                    b.Navigation("Vendedor");
                });

            modelBuilder.Entity("Domain.Entities.Cliente", b =>
                {
                    b.Navigation("Ventas");
                });

            modelBuilder.Entity("Domain.Entities.Documento", b =>
                {
                    b.Navigation("Facturas");
                });

            modelBuilder.Entity("Domain.Entities.MedioPago", b =>
                {
                    b.Navigation("Facturas");
                });

            modelBuilder.Entity("Domain.Entities.Producto", b =>
                {
                    b.Navigation("Items");

                    b.Navigation("OrdenesDeCompra");
                });

            modelBuilder.Entity("Domain.Entities.Proveedor", b =>
                {
                    b.Navigation("OrdenesDeCompra");
                });

            modelBuilder.Entity("Domain.Entities.Vendedor", b =>
                {
                    b.Navigation("Ventas");
                });

            modelBuilder.Entity("Domain.Entities.Venta", b =>
                {
                    b.Navigation("Items");

                    b.Navigation("factura")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
