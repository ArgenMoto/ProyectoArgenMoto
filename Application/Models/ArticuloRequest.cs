using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models
{
    public class ArticuloRequest
    {
        public string Nombre { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public int PrecioUnitario { get; set; }
        public int ProveedorId { get; set; }
    }
}
