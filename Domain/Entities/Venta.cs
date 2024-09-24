namespace Domain.Entities
{
    public class Venta
    {
        public Guid VentaId { get; set; }  // Identificador de la venta 
        public DateTime Fecha { get; set; }
        public int Cantidad { get; set; }    // Cantidad del producto vendido
        public int Total { get; set; }       // Total entre la cantidad de productos y su precio de venta
        public int ClienteId { get; set; }
        public int VendedorId { get; set; }
        public Factura factura { get; set; }
        public Cliente Cliente { get; set; }
        public Vendedor Vendedor { get; set; }
        public ICollection<Item> Items { get; set; }
    }
}
