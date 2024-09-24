namespace Domain.Entities
{
    public class Vendedor
    {
        public int VendedorId { get; set; }
        public string Nombre { get; set; }
        public string Puesto { get; set; }
        public ICollection<Venta> Ventas { get; set; }  // Relación con Venta
    }
}
