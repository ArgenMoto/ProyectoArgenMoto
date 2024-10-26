namespace Domain.Entities
{
    public class OrdenDeCompra
    {
        public int OrdenDeCompraId { get; set; }      
        public DateTime Fecha { get; set; } 
        public int PrecioTotal { get; set; }
        public ICollection<OrdenDeCompraProducto> OrdenDeCompraProducto { get; set; }
    }
}
 