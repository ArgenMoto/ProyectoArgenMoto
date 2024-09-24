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
        public int ClienteId { get; set; }
        public int VendedorId { get; set; }
        public DateTime Fecha { get; set; }
        public int TotalVenta { get; set; }
        public List<ItemResponse> Items { get; set; }
    }
}
