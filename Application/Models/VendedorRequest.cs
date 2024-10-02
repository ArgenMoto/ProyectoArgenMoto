using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models
{
    public class VendedorRequest
    {
        public string VendedorNombre { get; set; }
        public string VendedorApellido { get; set; }
        public string VendedorPuesto { get; set; }
        public int VendedorDni { get; set; }
        public string VendedorDomicilio { get; set; }
        public string VendedorLocalidad { get; set; }
        public string VendedorProvincia { get; set; }
        public int VendedorTelefono { get; set; }
        public string VendedorEmail { get; set; }
    }
}
