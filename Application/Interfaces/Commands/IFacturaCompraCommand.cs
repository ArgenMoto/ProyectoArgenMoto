using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Commands
{
    public interface IFacturaCompraCommand
    {
        void registrarFactura(FacturaCompra facturaCompra);
        void pagarFactura(FacturaCompra facturaCompra);
    }
}
