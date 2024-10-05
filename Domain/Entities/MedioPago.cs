namespace Domain.Entities
{
    public class MedioPago
    {
        public int MedioPagoId { get; set; }
        public string Descripcion { get; set; }
        public ICollection<Factura> Facturas { get; set; }
    }
}
