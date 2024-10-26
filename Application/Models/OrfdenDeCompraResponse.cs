using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models
{
    public class OrdenDeCompraResponse
    {
        public int NumeroOrdenDeCompra { get; set; }
        public int FacturaCompraId { get; set; }
        public string ProveedorCuit { get; set; }
        public string ProveedorNombre { get; set; }
        public DateTime Fecha { get; set; }
        public List<OrdenDeCompraProductoRequest> Productos { get; set; }
        public decimal Total { get; set; }
    }
}
