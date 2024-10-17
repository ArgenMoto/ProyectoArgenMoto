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
    public class OrdenDeCompraQuery : IOrdenDeCompraQuery
    {
        private readonly ArgenMotoDbContext _context;
        public OrdenDeCompraQuery(ArgenMotoDbContext context)
        {
            _context = context;
        }
        public OrdenDeCompra OrdenDeCompraPorId(int id)
        {
            var ordenDeCompra = _context.OrdenDeCompra.Find(id);

            return ordenDeCompra;
        }
    }
}
