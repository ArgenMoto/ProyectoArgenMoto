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
    public class OrdenDeCompraCommand : IOrdenDeCompraCommand
    {
        private readonly ArgenMotoDbContext _context;
        public OrdenDeCompraCommand(ArgenMotoDbContext context)
        {
            _context = context;
        }
        public void IngresarOrdenDeCompra(OrdenDeCompra ordenDeCompra)
        {
            _context.OrdenDeCompra.Add(ordenDeCompra);
            _context.SaveChanges();
        }
    }
}
