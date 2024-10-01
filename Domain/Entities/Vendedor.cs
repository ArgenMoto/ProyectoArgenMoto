namespace Domain.Entities
{
    public class Vendedor
    {
        public int VendedorId { get; set; }
        public string VendedorNombre { get; set; }
        public string VendedorApellido { get; set; }
        public string VendedorPuesto { get; set; }
        public int VendedorDni { get; set; }
        public string VendedorDomicilio { get; set; }
        public string VendedorLocalidad { get; set; }
        public string VendedorProvincia { get; set; }
        public int VendedorTelefono { get; set; }
        public string VendedorEmail { get; set; }
        public ICollection<Venta> Ventas { get; set; }  // Relación con Venta
        }
    }
