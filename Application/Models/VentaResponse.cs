using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models
{
    public class VentaResponse
    {
        public Guid VentaId { get; set; }
        public int FacturaId { get; set; }
        public DateTime Fecha { get; set; }
        public ClienteResponseVenta Cliente { get; set; }
        public VendedorResponseVenta Vendedor { get; set; }
        public List<ItemResponse> Items { get; set; }
        public int TotalVenta { get; set; }
    }
}
