using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class FacturaCompra
    {
        public int FacturaCompraId { get; set; } 
        public int OrdenDeCompraId { get; set; } 
        public DateTime FechaEmision { get; set; } 
        public int PrecioTotal { get; set; } 
        public bool Pagado { get; set; }
        public OrdenDeCompra OrdenDeCompra { get; set; }
    }
}
