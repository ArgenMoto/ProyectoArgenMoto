namespace Domain.Entities
{
    public class Producto
    {
        public int ProductoId { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Marca { get; set; }
        public int PrecioUnitario { get; set; }
        public int Stock { get; set; }
        public string Imagen { get; set; }
        public string Rubro { get; set; }
        public ICollection<Item> Items { get; set; }
        public ICollection<OrdenDeCompra> OrdenesDeCompra { get; set; }
    }
}
