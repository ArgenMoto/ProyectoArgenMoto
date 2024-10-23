using Application.Interfaces.Commands;
using Domain.Entities;
using Infraestructure.Persistense;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Commands
{
    public class FacturaCompraCommand : IFacturaCompraCommand
    {
        private readonly ArgenMotoDbContext _context;
        public FacturaCompraCommand(ArgenMotoDbContext context)
        {
            _context = context;
        }
        public void pagarFactura(FacturaCompra facturaCompra)
        {
            _context.FacturaCompra.Update(facturaCompra);
            _context.SaveChanges();
        }

        public void registrarFactura(FacturaCompra facturaCompra)
        {
            _context.FacturaCompra.Add(facturaCompra);
            _context.SaveChanges();
        }
    }
}
