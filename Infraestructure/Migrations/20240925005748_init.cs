using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    ClienteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DNI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.ClienteId);
                });

            migrationBuilder.CreateTable(
                name: "Documento",
                columns: table => new
                {
                    DocumentoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Documento", x => x.DocumentoId);
                });

            migrationBuilder.CreateTable(
                name: "MedioPago",
                columns: table => new
                {
                    MedioPagoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedioPago", x => x.MedioPagoId);
                });

            migrationBuilder.CreateTable(
                name: "Producto",
                columns: table => new
                {
                    ProductoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Marca = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PrecioUnitario = table.Column<int>(type: "int", nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false),
                    Imagen = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rubro = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Producto", x => x.ProductoId);
                });

            migrationBuilder.CreateTable(
                name: "Proveedor",
                columns: table => new
                {
                    ProveedorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proveedor", x => x.ProveedorId);
                });

            migrationBuilder.CreateTable(
                 name: "Vendedor",
                 columns: table => new
                 {
                     VendedorId = table.Column<int>(type: "int", nullable: false)
                         .Annotation("SqlServer:Identity", "1, 1"),
                     VendedorNombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                     VendedorApellido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                     VendedorPuesto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                     VendedorDni = table.Column<int>(type: "int", nullable: false),
                     VendedorDomicilio = table.Column<string>(type: "nvarchar(max)", nullable: false),
                     VendedorLocalidad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                     VendedorProvincia = table.Column<string>(type: "nvarchar(max)", nullable: false),
                     VendedorTelefono = table.Column<int>(type: "int", nullable: false),
                     VendedorEmail = table.Column<string>(type: "nvarchar(max)", nullable: false)

                 },
                 constraints: table =>
                {
                    table.PrimaryKey("PK_Vendedor", x => x.VendedorId);
                });

            migrationBuilder.CreateTable(
                name: "OrdenDeCompra",
                columns: table => new
                {
                    OrdenId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Precio = table.Column<int>(type: "int", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    Total = table.Column<int>(type: "int", nullable: false),
                    Producto = table.Column<int>(type: "int", nullable: false),
                    Proveedor = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdenDeCompra", x => x.OrdenId);
                    table.ForeignKey(
                        name: "FK_OrdenDeCompra_Producto_Producto",
                        column: x => x.Producto,
                        principalTable: "Producto",
                        principalColumn: "ProductoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrdenDeCompra_Proveedor_Proveedor",
                        column: x => x.Proveedor,
                        principalTable: "Proveedor",
                        principalColumn: "ProveedorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Venta",
                columns: table => new
                {
                    VentaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalVenta = table.Column<int>(type: "int", nullable: false),
                    cliente = table.Column<int>(type: "int", nullable: false),
                    Vendedor = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Venta", x => x.VentaId);
                    table.ForeignKey(
                        name: "FK_Venta_Cliente_cliente",
                        column: x => x.cliente,
                        principalTable: "Cliente",
                        principalColumn: "ClienteId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Venta_Vendedor_Vendedor",
                        column: x => x.Vendedor,
                        principalTable: "Vendedor",
                        principalColumn: "VendedorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Factura",
                columns: table => new
                {
                    FacturaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VentaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Total = table.Column<int>(type: "int", nullable: false),
                    DocumentoId = table.Column<int>(type: "int", nullable: false),
                    MedioDePago = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Factura", x => x.FacturaId);
                    table.ForeignKey(
                        name: "FK_Factura_Documento_DocumentoId",
                        column: x => x.DocumentoId,
                        principalTable: "Documento",
                        principalColumn: "DocumentoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Factura_MedioPago_MedioDePago",
                        column: x => x.MedioDePago,
                        principalTable: "MedioPago",
                        principalColumn: "MedioPagoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Factura_Venta_VentaId",
                        column: x => x.VentaId,
                        principalTable: "Venta",
                        principalColumn: "VentaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ItemDetalle",
                columns: table => new
                {
                    ItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Venta = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Producto = table.Column<int>(type: "int", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    PrecioTotalItem = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemDetalle", x => x.ItemId);
                    table.ForeignKey(
                        name: "FK_ItemDetalle_Producto_Producto",
                        column: x => x.Producto,
                        principalTable: "Producto",
                        principalColumn: "ProductoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemDetalle_Venta_Venta",
                        column: x => x.Venta,
                        principalTable: "Venta",
                        principalColumn: "VentaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Cliente",
                columns: new[] { "ClienteId", "Apellido", "DNI", "Nombre" },
                values: new object[,]
                {
                    { 1, "Pérez", "12345678", "Juan" },
                    { 2, "García", "23456789", "Ana" },
                    { 3, "Martínez", "34567890", "Luis" },
                    { 4, "Lopez", "45678901", "Marta" },
                    { 5, "Fernández", "56789012", "Carlos" }
                });

            migrationBuilder.InsertData(
                table: "Documento",
                columns: new[] { "DocumentoId", "Descripcion" },
                values: new object[,]
                {
                    { 1, "Factura A" },
                    { 2, "Factura B" },
                    { 3, "Nota de Crédito" },
                    { 4, "Nota de Débito" },
                    { 5, "Recibo" },
                    { 6, "Orden de Compra" }
                });

            migrationBuilder.InsertData(
                table: "MedioPago",
                columns: new[] { "MedioPagoId", "Descripcion" },
                values: new object[,]
                {
                    { 1, "Efectivo" },
                    { 2, "Tarjeta de Crédito" },
                    { 3, "Tarjeta de Débito" },
                    { 4, "Transferencia Bancaria" },
                    { 5, "PayPal" }
                });

            migrationBuilder.InsertData(
                table: "Producto",
                columns: new[] { "ProductoId", "Descripcion", "Imagen", "Marca", "Nombre", "PrecioUnitario", "Rubro", "Stock" },
                values: new object[,]
                {
                    { 1, "Motocicleta deportiva ligera y ágil.", "https://i.postimg.cc/rpJWcK0L/2023-Yamaha-MT07-A-EU-Cyan-Storm-360-Degrees-001-03.jpg", "Yamaha", "Yamaha MT-07", 150000, "Motocicleta", 5 },
                    { 2, "Motocicleta naked para uso urbano y carretera.", "https://i.postimg.cc/50KCYTS7/honda-cb-500-f.jpg", "Honda", "Honda CB500F", 180000, "Motocicleta", 7 },
                    { 3, "Motocicleta deportiva de baja cilindrada.", "https://i.postimg.cc/tJVY1TTJ/ninja400-KRT-1-1.jpg", "Kawasaki", "Kawasaki Ninja 400", 200000, "Motocicleta", 10 },
                    { 4, "Motocicleta adventure de media cilindrada.", "https://i.postimg.cc/NjtkchJm/muo3kk8n0sjdherhbjzvqyytgylzz8hcmvkfdusy.jpg", "Suzuki", "Suzuki V-Strom 650", 160000, "Motocicleta", 8 },
                    { 5, "Motocicleta adventure de alta gama.", "https://i.postimg.cc/W4WGgd2w/image.jpg", "BMW", "BMW R 1250 GS", 300000, "Motocicleta", 3 },
                    { 6, "Motocicleta naked de alto rendimiento.", "https://i.postimg.cc/RCn7JC2w/Monster-821-MY18-Red-01-Model-Preview-1050x650.png", "Ducati", "Ducati Monster 821", 250000, "Motocicleta", 4 },
                    { 7, "Motocicleta cruiser clásica.", "https://i.postimg.cc/X7SwfS0m/54c33236a8ad91156a9e611375b4d973-a18dd478b82157f1.png", "Harley-Davidson", "Harley-Davidson Iron 883", 400000, "Motocicleta", 2 }
                });

            migrationBuilder.InsertData(
                table: "Proveedor",
                columns: new[] { "ProveedorId", "Direccion", "Nombre", "Telefono" },
                values: new object[,]
                {
                    { 1, "Av. Libertador 1234", "Moto Parts Ltd.", "011-12345678" },
                    { 2, "Calle Falsa 5678", "Moto Accessories S.A.", "011-23456789" },
                    { 3, "Avenida Rivadavia 4321", "Motorcycle World", "011-34567890" },
                    { 4, "Calle Moreno 8765", "Bike Gear Co.", "011-45678901" },
                    { 5, "Calle Alem 9876", "Moto Supplies Inc.", "011-56789012" }
                });

            migrationBuilder.InsertData(
                table: "Vendedor",
                columns: new[] { "VendedorId", "VendedorNombre", "VendedorApellido", "VendedorPuesto", "VendedorDni", "VendedorDomicilio", "VendedorLocalidad", "VendedorProvincia", "VendedorTelefono", "VendedorEmail" },
                values: new object[,]
                {
                    {1,"Pedro", "Gomez","Vendedor Principal", 33456789, "Calle 30 2659", "Berazategui", "Buenos Aires", 1523467895, "pedro@gmail.com"},
                    {2,"Laura","Rodriguez","Vendedora", 40256897,"Calle 132 4567", "Berazategui","Buenos Aires", 1547896321, "laura@gmail.com"},
                    {3,"Andrés", "Gimenez","Vendedor", 38526478,"Calle 145 5047","Berazategui","Buenos Aires", 1578451236, "andres@gmail.com"},
                    {4,"Sofía","Saucedo","Vendedora", 23456789,"Calle 38 4568", "Berazategui", "Buenos Aires", 1547526389, "sofia@gmail.com"},
                    {5,"Miguel", "Souto","Vendedor ", 34568791,"Calle 33 2356", "Berazategui","Buenos Aires",1545678912, "miguel@gmail.com"}
                });

            migrationBuilder.CreateIndex(
                name: "IX_Factura_DocumentoId",
                table: "Factura",
                column: "DocumentoId");

            migrationBuilder.CreateIndex(
                name: "IX_Factura_MedioDePago",
                table: "Factura",
                column: "MedioDePago");

            migrationBuilder.CreateIndex(
                name: "IX_Factura_VentaId",
                table: "Factura",
                column: "VentaId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ItemDetalle_Producto",
                table: "ItemDetalle",
                column: "Producto");

            migrationBuilder.CreateIndex(
                name: "IX_ItemDetalle_Venta",
                table: "ItemDetalle",
                column: "Venta");

            migrationBuilder.CreateIndex(
                name: "IX_OrdenDeCompra_Producto",
                table: "OrdenDeCompra",
                column: "Producto");

            migrationBuilder.CreateIndex(
                name: "IX_OrdenDeCompra_Proveedor",
                table: "OrdenDeCompra",
                column: "Proveedor");

            migrationBuilder.CreateIndex(
                name: "IX_Venta_cliente",
                table: "Venta",
                column: "cliente");

            migrationBuilder.CreateIndex(
                name: "IX_Venta_Vendedor",
                table: "Venta",
                column: "Vendedor");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Factura");

            migrationBuilder.DropTable(
                name: "ItemDetalle");

            migrationBuilder.DropTable(
                name: "OrdenDeCompra");

            migrationBuilder.DropTable(
                name: "Documento");

            migrationBuilder.DropTable(
                name: "MedioPago");

            migrationBuilder.DropTable(
                name: "Venta");

            migrationBuilder.DropTable(
                name: "Producto");

            migrationBuilder.DropTable(
                name: "Proveedor");

            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "Vendedor");
        }
    }
}
