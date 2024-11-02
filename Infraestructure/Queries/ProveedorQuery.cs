using Application.Interfaces.Queries;
using Domain.Entities;
using Infraestructure.Persistense;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Queries
{
    public class ProveedorQuery : IProveedorQuery
    {
        private readonly ArgenMotoDbContext _context;
        public ProveedorQuery(ArgenMotoDbContext context)
        {
            _context = context;
        }
        public async Task<List<Proveedor>> ListaProveedores()
        {
            List<Proveedor> result = new List<Proveedor>();

            var proveedores = await _context.Proveedor.ToListAsync();
            return proveedores;
        }

        public Proveedor ProveedoresPorId(int id)
        {
            var proveedor = _context.Proveedor
                           //.Include(p => p.ArticuloProveedor)
                           //.ThenInclude(ap => ap.Producto) // Incluye los detalles del producto
                           .FirstOrDefault(p => p.ProveedorId == id);

            return proveedor;
        }

        public Proveedor ProveedoresPorCuit(string cuit) { 
             var proveedor = _context.Proveedor.FirstOrDefault(p => p.Cuit == cuit);
            return proveedor;
        }
    }
}
