using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models
{
    public class ProductoResponse
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Marca { get; set; }
        public string Descripcion { get; set; }
        public string Modelo{ get; set; }
        public int NumeroMotor { get; set; }
        public int NumeroChasis { get; set; }
        public int Cilindro { get; set; }
        public int Fecha { get; set; }
        public string Rubro { get; set; }
        public int PrecioUnitario { get; set; }
        public int StockMinimo { get; set; }
        public int StockMaximo { get; set; }
        public int StockActual { get; set; }
        public string Imagen { get; set; }

    }
}
