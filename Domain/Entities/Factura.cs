namespace Domain.Entities
{
    public class Factura
    {
        public int FacturaId { get; set; }
        public Guid VentaId { get; set; }  // Relación con Venta
        public DateTime Fecha { get; set; }
        public int Total { get; set; }
        public int DocumentoId { get; set; }
        public int MedioPagoId { get; set; }

        public Venta Venta { get; set; }  // Relación con Venta
        public Documento Documento { get; set; }
        public MedioPago MedioPago { get; set; }


    }
}
