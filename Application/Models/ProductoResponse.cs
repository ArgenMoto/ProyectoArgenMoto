using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models
{
    public class ProductoResponse
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Marca { get; set; }
        public int PrecioUnitario { get; set; }
        public int Stock { get; set; }
        public string Imagen { get; set; }
        public string Rubro { get; set; }
    }
}
