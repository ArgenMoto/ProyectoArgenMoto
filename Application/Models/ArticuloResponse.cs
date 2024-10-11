using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models
{
    public class ArticuloResponse
    {
        public int ArticuloId { get; set; }
        public string Nombre { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public int ProductoId { get; set; }
        public int PrecioUnitario { get; set; }
    }
}
