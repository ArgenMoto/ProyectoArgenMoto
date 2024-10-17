using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models
{
    public class FacturaResponse
    {
        public int NumeroFactura { get; set; }
        public string tipoFactura { get; set; }
        public string medioPago { get; set; }
        public Guid VentaId { get; set; }
        public string Fecha { get; set; }
        public bool Cobrado { get; set; }
        public ClienteResponseVenta Cliente { get; set; }
        public VendedorResponseVenta Vendedor { get; set; }
        public List<ItemResponse> Items { get; set; }
        public int Total { get; set; }
  
    }
}
