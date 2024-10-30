using Application.Interfaces.Queries;
using Domain.Entities;
using Infraestructure.Persistense;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Queries
{
    public class FacturaCompraQuery : IFacturaCompraQuery
    {
        private readonly ArgenMotoDbContext _context;
        public FacturaCompraQuery(ArgenMotoDbContext context)
        {
            _context = context;
        }
        public FacturaCompra FacturaCompraPorId(int id)
        {
            var facturaCompra = _context.FacturaCompra
        .Include(fc => fc.OrdenDeCompra)                    
        .Include(fc => fc.OrdenDeCompra.OrdenDeCompraProducto)  
            .ThenInclude(ocp => ocp.ArticuloProveedor)
                .ThenInclude(ap => ap.Proveedor)
        .FirstOrDefault(fc => fc.FacturaCompraId == id);    

            return facturaCompra;
        }

    }
}
