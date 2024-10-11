using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ArticuloProveedor
    {
        public int ArticuloProveedorId { get; set; }
        public string Nombre { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public int ProductoId { get; set; }
        public int PrecioUnitario { get; set; }
        public int ProveedorId { get; set; }
        public Proveedor Proveedor { get; set; }
        public Producto Producto { get; set; }

        public ICollection<OrdenDeCompraProducto> OrdenDeCompraProducto { get; set; }
    }
}
