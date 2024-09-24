namespace Domain.Entities
{
    public class OrdenDeCompra
    {
        public Guid OrdenId { get; set; }
        public int Precio { get; set; }
        public int Cantidad { get; set; }    // Cantidad del producto comprado
        public int Total { get; set; }       // Total entre la cantidad de productos y su precio de compra
        public int ProductoId { get; set; }  // Relación con Producto
        public int ProveedorId { get; set; } // Relación con Proveedor

        public Producto Producto { get; set; }// Relación con Producto
        public Proveedor Proveedor { get; set; }// Relación con Proveedor
    }
}
