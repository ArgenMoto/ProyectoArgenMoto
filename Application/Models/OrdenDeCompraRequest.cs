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

    public class OrdenDeCompraResponse
    {
        public int NumeroOrdenDeCompra { get; set; }
        public string ProveedorCuit { get; set; }
        public string ProveedorNombre { get; set; }
        public DateTime Fecha { get; set; }
        public List<OrdenDeCompraProductoRequest> Productos { get; set; }
        public decimal Total { get; set; }
    }
}
