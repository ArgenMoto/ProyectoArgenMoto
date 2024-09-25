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
        public DateTime Fecha { get; set; }
        public int ClienteId { get; set; }
        public string ClienteNombre { get; set; }// es mejor devolver un clienteResponse? con su id y nombre?                                             
        public int VendedorId { get; set; }
        public string VendedorNombre { get; set; }// es mejor devolver un vendedorResponse? con su id y nombre?                                                   
        public List<ItemResponse> Items { get; set; }
        public int TotalVenta { get; set; }
    }
}
