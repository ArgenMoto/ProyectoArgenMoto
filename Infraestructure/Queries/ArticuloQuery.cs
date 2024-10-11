using Application.Interfaces.Queries;
using Domain.Entities;
using Infraestructure.Persistense;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Queries
{
    public class ArticuloQuery : IArticuloQuery
    {
        private readonly ArgenMotoDbContext _context;
        public ArticuloQuery(ArgenMotoDbContext context)
        {
            _context = context;
        }
        public ArticuloProveedor articuloPorId(int id)
        {
            var articulo = _context.ArticuloProveedor.Find(id);

            return articulo;
        }

        public List<ArticuloProveedor> ArticuloPorProveedor(int id)
        {
            var articulos = _context.ArticuloProveedor.Where(x => x.ProveedorId == id).ToList();

            return articulos;
        }
    }
}
