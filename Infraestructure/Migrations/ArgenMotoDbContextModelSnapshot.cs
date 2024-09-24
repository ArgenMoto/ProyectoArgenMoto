﻿// <auto-generated />
using System;
using Infraestructure.Persistense;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infraestructure.Migrations
{
    [DbContext(typeof(ArgenMotoDbContext))]
    partial class ArgenMotoDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

                    b.Property<decimal>("PrecioTotalItem")
                        .HasColumnType("decimal(18,2)");

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

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Imagen")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Marca")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PrecioUnitario")
                        .HasColumnType("int");

                    b.Property<string>("Rubro")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Stock")
                        .HasColumnType("int");

                    b.HasKey("ProductoId");

                    b.ToTable("Producto", (string)null);

                    b.HasData(
                        new
                        {
                            ProductoId = 1,
                            Descripcion = "Motocicleta deportiva ligera y ágil.",
                            Imagen = "https://i.postimg.cc/rpJWcK0L/2023-Yamaha-MT07-A-EU-Cyan-Storm-360-Degrees-001-03.jpg",
                            Marca = "Yamaha",
                            Nombre = "Yamaha MT-07",
                            PrecioUnitario = 150000,
                            Rubro = "Motocicleta",
                            Stock = 5
                        },
                        new
                        {
                            ProductoId = 2,
                            Descripcion = "Motocicleta naked para uso urbano y carretera.",
                            Imagen = "https://i.postimg.cc/50KCYTS7/honda-cb-500-f.jpg",
                            Marca = "Honda",
                            Nombre = "Honda CB500F",
                            PrecioUnitario = 180000,
                            Rubro = "Motocicleta",
                            Stock = 7
                        },
                        new
                        {
                            ProductoId = 3,
                            Descripcion = "Motocicleta deportiva de baja cilindrada.",
                            Imagen = "https://i.postimg.cc/tJVY1TTJ/ninja400-KRT-1-1.jpg",
                            Marca = "Kawasaki",
                            Nombre = "Kawasaki Ninja 400",
                            PrecioUnitario = 200000,
                            Rubro = "Motocicleta",
                            Stock = 10
                        },
                        new
                        {
                            ProductoId = 4,
                            Descripcion = "Motocicleta adventure de media cilindrada.",
                            Imagen = "https://i.postimg.cc/NjtkchJm/muo3kk8n0sjdherhbjzvqyytgylzz8hcmvkfdusy.jpg",
                            Marca = "Suzuki",
                            Nombre = "Suzuki V-Strom 650",
                            PrecioUnitario = 160000,
                            Rubro = "Motocicleta",
                            Stock = 8
                        },
                        new
                        {
                            ProductoId = 5,
                            Descripcion = "Motocicleta adventure de alta gama.",
                            Imagen = "https://i.postimg.cc/W4WGgd2w/image.jpg",
                            Marca = "BMW",
                            Nombre = "BMW R 1250 GS",
                            PrecioUnitario = 300000,
                            Rubro = "Motocicleta",
                            Stock = 3
                        },
                        new
                        {
                            ProductoId = 6,
                            Descripcion = "Motocicleta naked de alto rendimiento.",
                            Imagen = "https://i.postimg.cc/RCn7JC2w/Monster-821-MY18-Red-01-Model-Preview-1050x650.png",
                            Marca = "Ducati",
                            Nombre = "Ducati Monster 821",
                            PrecioUnitario = 250000,
                            Rubro = "Motocicleta",
                            Stock = 4
                        },
                        new
                        {
                            ProductoId = 7,
                            Descripcion = "Motocicleta cruiser clásica.",
                            Imagen = "https://i.postimg.cc/X7SwfS0m/54c33236a8ad91156a9e611375b4d973-a18dd478b82157f1.png",
                            Marca = "Harley-Davidson",
                            Nombre = "Harley-Davidson Iron 883",
                            PrecioUnitario = 400000,
                            Rubro = "Motocicleta",
                            Stock = 2
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

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Puesto")
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

                    b.Property<int>("Cantidad")
                        .HasColumnType("int");

                    b.Property<int>("ClienteId")
                        .HasColumnType("int")
                        .HasColumnName("cliente");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<int>("Total")
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
