using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models
{
    public class OrdenDeCompraRequest
    {
        public int proveedorId { get; set; }
        public List<OrdenDeCompraProductoRequest> productos { get; set; }
    }

    public class OrdenDeCompraProductoRequest
    {
        public int ProductoId { get; set; }
        public int Cantidad { get; set; }
    }
}
