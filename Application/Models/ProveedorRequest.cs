using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Application.Models
{
    public class ProveedorRequest
    {
        public string Cuit { get; set; }
        public string RazonSocial { get; set; }
        public string Apellido { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Localidad { get; set; }
        public string Provincia { get; set; }
        public int Telefono { get; set; }
        public string Email { get; set; }
    }
}
