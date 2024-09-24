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
    public class VentaCommand:IVentaCommand
    {
        private readonly ArgenMotoDbContext _context;
        public VentaCommand(ArgenMotoDbContext context)
        {
            _context = context;
        }

        public void actualizarVenta(Venta venta)
        {
            _context.Venta.Update(venta);
            _context.SaveChanges();
        }

        public void registrarVenta(Venta venta)
        {
            _context.Venta.Add(venta);
            _context.SaveChanges();
        }
    }
}