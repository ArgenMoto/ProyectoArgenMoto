using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models
{
    public class VentaRequest
    {
        public int ClienteId { get; set; }
        public int VendedorId { get; set; }
        public List<ItemRequest> Items { get; set; }
        public int DocumentoId { get; set; }
        public int MedioPagoId { get; set; }
    }
}
