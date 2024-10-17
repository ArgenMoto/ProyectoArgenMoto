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
                    DNI = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Domicilio = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Localidad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Provincia = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefono = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                name: "OrdenDeCompra",
                columns: table => new
                {
                    OrdenDeCompraId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PrecioTotal = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdenDeCompra", x => x.OrdenDeCompraId);
                });

            migrationBuilder.CreateTable(
                name: "Producto",
                columns: table => new
                {
                    ProductoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Marca = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Modelo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumeroMotor = table.Column<int>(type: "int", nullable: false),
                    NumeroChasis = table.Column<int>(type: "int", nullable: false),
                    Cilindro = table.Column<int>(type: "int", nullable: false),
                    Fecha = table.Column<int>(type: "int", nullable: false),
                    Rubro = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PrecioUnitario = table.Column<int>(type: "int", nullable: false),
                    StockMinimo = table.Column<int>(type: "int", nullable: false),
                    StockMaximo = table.Column<int>(type: "int", nullable: false),
                    StockActual = table.Column<int>(type: "int", nullable: false),
                    Imagen = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                    Cuit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RazonSocial = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Localidad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Provincia = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefono = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                name: "ArticulosProveedor",
                columns: table => new
                {
                    ArticuloProveedorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Marca = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Modelo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Producto = table.Column<int>(type: "int", nullable: false),
                    PrecioUnitario = table.Column<int>(type: "int", nullable: false),
                    Proveedor = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticulosProveedor", x => x.ArticuloProveedorId);
                    table.ForeignKey(
                        name: "FK_ArticulosProveedor_Producto_Producto",
                        column: x => x.Producto,
                        principalTable: "Producto",
                        principalColumn: "ProductoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArticulosProveedor_Proveedor_Proveedor",
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
                    fecha = table.Column<DateTime>(type: "datetime2(0)", nullable: false),
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
                name: "OrdenDeCompraProducto",
                columns: table => new
                {
                    OrdenDeCompraProductoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrdenDeCompra = table.Column<int>(type: "int", nullable: false),
                    ArticuloProveedorId = table.Column<int>(type: "int", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    TotalLinea = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdenDeCompraProducto", x => x.OrdenDeCompraProductoId);
                    table.ForeignKey(
                        name: "FK_OrdenDeCompraProducto_ArticulosProveedor_ArticuloProveedorId",
                        column: x => x.ArticuloProveedorId,
                        principalTable: "ArticulosProveedor",
                        principalColumn: "ArticuloProveedorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrdenDeCompraProducto_OrdenDeCompra_OrdenDeCompra",
                        column: x => x.OrdenDeCompra,
                        principalTable: "OrdenDeCompra",
                        principalColumn: "OrdenDeCompraId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Factura",
                columns: table => new
                {
                    FacturaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VentaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Fecha = table.Column<DateTime>(type: "date", nullable: false),
                    Total = table.Column<int>(type: "int", nullable: false),
                    Cobrado = table.Column<bool>(type: "bit", nullable: false),
                    DocumentoId = table.Column<int>(type: "int", nullable: false),
                    MedioDePagoId = table.Column<int>(type: "int", nullable: false)
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
                        column: x => x.MedioDePagoId,
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
                columns: new[] { "ClienteId", "Apellido", "DNI", "Domicilio", "Email", "Localidad", "Nombre", "Provincia", "Telefono" },
                values: new object[,]
                {
                    { 1, "Pérez", 12345678, "Calle 30 214", "carlos@gmail.com", "Quilmes", "Juan", "Buenos Aires", 422589654 },
                    { 2, "García", 23456789, "Calle 30 231", "garciana@gmail.com", "Florencio Varela", "Ana", "Buenos Aires", 45678932 },
                    { 3, "Martínez", 34567890, "Calle 12 1024", "luis@gmail.com", "Berazategui", "Luis", "Buenos Aires", 1124568935 },
                    { 4, "Lopez", 45678901, "Calle 28 1235", "marta@yahoo.com", "Berazategui", "Marta", "Buenos Aires", 1124567835 },
                    { 5, "Fernández", 56789012, "Mitre 1234", "carlitos@yahoo.com", "Quilmes", "Carlos", "Buenos Aires", 1145623789 }
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
                    { 5, "PayPal" },
                    { 6, "QR" }
                });

            migrationBuilder.InsertData(
                table: "Producto",
                columns: new[] { "ProductoId", "Cilindro", "Descripcion", "Fecha", "Imagen", "Marca", "Modelo", "Nombre", "NumeroChasis", "NumeroMotor", "PrecioUnitario", "Rubro", "StockActual", "StockMaximo", "StockMinimo" },
                values: new object[,]
                {
                    { 1, 689, "Motocicleta deportiva ligera y ágil.", 2024, "https://i.postimg.cc/rpJWcK0L/2023-Yamaha-MT07-A-EU-Cyan-Storm-360-Degrees-001-03.jpg", "Yamaha", "MT-07", "Yamaha MT-07", 789012, 123456, 150000, "Motocicleta", 6, 100, 3 },
                    { 2, 500, "Motocicleta naked para uso urbano y carretera.", 2024, "https://i.postimg.cc/50KCYTS7/honda-cb-500-f.jpg", "Honda", "CB500F", "Honda CB500F", 334455, 223344, 180000, "Motocicleta", 7, 100, 3 },
                    { 3, 399, "Motocicleta deportiva de baja cilindrada.", 2024, "https://i.postimg.cc/tJVY1TTJ/ninja400-KRT-1-1.jpg", "Kawasaki", "Ninja 400", "Kawasaki Ninja 400", 889900, 556677, 200000, "Motocicleta", 10, 100, 3 },
                    { 4, 645, "Motocicleta adventure de media cilindrada.", 2024, "https://i.postimg.cc/NjtkchJm/muo3kk8n0sjdherhbjzvqyytgylzz8hcmvkfdusy.jpg", "Suzuki", "V-Strom 650", "Suzuki V-Strom 650", 665544, 998877, 160000, "Motocicleta", 8, 100, 3 },
                    { 5, 1254, "Motocicleta adventure de alta gama.", 2024, "https://i.postimg.cc/W4WGgd2w/image.jpg", "BMW", "R 1250 GS", "BMW R 1250 GS", 223344, 554433, 300000, "Motocicleta", 4, 100, 3 },
                    { 6, 821, "Motocicleta naked de alto rendimiento.", 2024, "https://i.postimg.cc/RCn7JC2w/Monster-821-MY18-Red-01-Model-Preview-1050x650.png", "Ducati", "Monster 821", "Ducati Monster 821", 445566, 112233, 250000, "Motocicleta", 4, 100, 3 },
                    { 7, 883, "Motocicleta cruiser clásica.", 2024, "https://i.postimg.cc/X7SwfS0m/54c33236a8ad91156a9e611375b4d973-a18dd478b82157f1.png", "Harley-Davidson", "Iron 883", "Harley-Davidson Iron 883", 123456, 778899, 400000, "Motocicleta", 5, 100, 3 }
                });

            migrationBuilder.InsertData(
                table: "Proveedor",
                columns: new[] { "ProveedorId", "Apellido", "Cuit", "Direccion", "Email", "Localidad", "Nombre", "Provincia", "RazonSocial", "Telefono" },
                values: new object[,]
                {
                    { 1, "Perez", "20234567897", "Av. Libertador 1234", "juan@gmail.com", "Capital Federal", "Juan", "Buenos Aires", "Moto Parts Ltd.", 1112345678 },
                    { 2, "Torres", "20234567899", "Calle Falsa 5678", "torres@yahoo,com", "Quilmes", "Gabriel", "Buenos Aires", "Moto Accessories S.A.", 1123456789 },
                    { 3, "Sanchez", "23415689741", "Avenida Rivadavia 4321", "ramon@gmail.com", "Florencio Varela", "Ramon", "Buenos Aires", "Motorcycle World", 114567890 },
                    { 4, "Cuello", "20356457899", "Calle Moreno 8765", "marcos@gmail.com", "Capital Federal", "Marcos", "Buenos Aires", "Bike Gear Co.", 1145678901 },
                    { 5, "Bernis", "23367894567", "Calle Alem 9876", "bernis@hotmail.com", "La Plata", "Jose", "Buenos Aires", "Moto Supplies Inc.", 1156789012 }
                });

            migrationBuilder.InsertData(
                table: "Vendedor",
                columns: new[] { "VendedorId", "VendedorApellido", "VendedorDni", "VendedorDomicilio", "VendedorEmail", "VendedorLocalidad", "VendedorNombre", "VendedorProvincia", "VendedorPuesto", "VendedorTelefono" },
                values: new object[,]
                {
                    { 1, "Gomez", 33456789, "Calle 30 2659", "pedro@gmail.com", "Berazategui", "Pedro", "Buenos Aires", "Vendedor Principal", 1523467895 },
                    { 2, "Rodriguez", 40256897, "Calle 132 4567", "laura@gmail.com", "Berazategui", "Laura", "Buenos Aires", "Vendedora", 1547896321 },
                    { 3, "Gimenez", 38526478, "Calle 145 5047", "andres@gmail.com", "Berazategui", "Andrés", "Buenos Aires", "Vendedor", 1578451236 },
                    { 4, "Saucedo", 23456789, "Calle 38 4568", "sofia@gmail.com", "Berazategui", "Sofía", "Buenos Aires", "Vendedora", 1547526389 },
                    { 5, "Souto", 34568791, "Calle 33 2356", "miguel@gmail.com", "Berazategui", "Miguel", "Buenos Aires", "Vendedor ", 1545678912 }
                });

            migrationBuilder.InsertData(
                table: "ArticulosProveedor",
                columns: new[] { "ArticuloProveedorId", "Marca", "Modelo", "Nombre", "PrecioUnitario", "Producto", "Proveedor" },
                values: new object[,]
                {
                    { 1, "Yamaha", "MT-07", "Yamaha MT-07", 150000, 1, 1 },
                    { 2, "Honda", "CB500F", "Honda CB500F", 180000, 2, 1 },
                    { 3, "Kawasaki", "Ninja 400", "Kawasaki Ninja 400", 200000, 3, 1 },
                    { 4, "Suzuki", "V-Strom 650", "Suzuki V-Strom 650", 160000, 4, 2 },
                    { 5, "BMW", "R 1250 GS", "BMW R 1250 GS", 300000, 5, 2 },
                    { 6, "Ducati", "Monster 821", "Ducati Monster 821", 250000, 6, 3 },
                    { 7, "Harley-Davidson", "Iron 883", "Harley-Davidson Iron 883", 400000, 7, 4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ArticulosProveedor_Producto",
                table: "ArticulosProveedor",
                column: "Producto");

            migrationBuilder.CreateIndex(
                name: "IX_ArticulosProveedor_Proveedor",
                table: "ArticulosProveedor",
                column: "Proveedor");

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
                name: "IX_OrdenDeCompraProducto_ArticuloProveedorId",
                table: "OrdenDeCompraProducto",
                column: "ArticuloProveedorId");

            migrationBuilder.CreateIndex(
                name: "IX_OrdenDeCompraProducto_OrdenDeCompra",
                table: "OrdenDeCompraProducto",
                column: "OrdenDeCompra");

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
                name: "OrdenDeCompraProducto");

            migrationBuilder.DropTable(
                name: "Documento");

            migrationBuilder.DropTable(
                name: "MedioPago");

            migrationBuilder.DropTable(
                name: "Venta");

            migrationBuilder.DropTable(
                name: "ArticulosProveedor");

            migrationBuilder.DropTable(
                name: "OrdenDeCompra");

            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "Vendedor");

            migrationBuilder.DropTable(
                name: "Producto");

            migrationBuilder.DropTable(
                name: "Proveedor");
        }
    }
}
