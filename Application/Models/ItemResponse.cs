using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models
{
    public class ItemResponse
    {
        public int ProductoId { get; set; }
        public string ProductoNombre { get; set; }
        public int PrecioUnitario { get; set; }
        public int Cantidad { get; set; }
        public int PrecioTotalItem { get; set; }
    }
}
