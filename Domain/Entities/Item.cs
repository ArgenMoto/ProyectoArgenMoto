namespace Domain.Entities
{
    public class Item
    {
        public int ItemId { get; set; }
        public Guid VentaId { get; set; }
        public int ProductoId { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioTotalItem { get; set; }

        public Venta Venta { get; set; }
        public Producto Producto { get; set; }
    }
}
