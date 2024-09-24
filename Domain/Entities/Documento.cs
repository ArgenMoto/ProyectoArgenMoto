namespace Domain.Entities
{
    public class Documento
    {
        public int DocumentoId { get; set; }
        public string Descripcion { get; set; }

        public ICollection<Factura> Facturas { get; set; }
    }
}
