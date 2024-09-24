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
    public class FacturaCommand :IFacturaCommand
    {
        private readonly ArgenMotoDbContext _context;
        public FacturaCommand(ArgenMotoDbContext context)
        {
            _context = context;
        }
        public void registrarFactura(Factura factura)
        {
            _context.Factura.Add(factura);
            _context.SaveChanges();
        }
    }
}
