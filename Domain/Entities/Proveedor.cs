using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Domain.Entities
{
    public class Proveedor
    {
        public int ProveedorId { get; set; }
        public string Cuit { get; set; }
        public string RazonSocial { get; set; }
        public string Apellido { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Localidad { get; set; }
        public string Provincia { get; set; }
        public int Telefono { get; set; }
        public string Email { get; set; }
        public ICollection<ArticuloProveedor> ArticuloProveedor { get; set; }

    }
}
