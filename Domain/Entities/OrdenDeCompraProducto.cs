using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class OrdenDeCompraProducto
    {
        public int OrdenDeCompraProductoId { get; set; }
        public int OrdenDeCompraId { get; set; }
        public int ArticuloProveedorId { get; set; }
        public int Cantidad { get; set; }
        public int TotalLinea { get; set; }
        public ArticuloProveedor ArticuloProveedor { get; set; }
        public OrdenDeCompra OrdenDeCompra { get; set; }
    }
}
