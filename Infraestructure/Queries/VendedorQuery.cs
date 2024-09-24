using Application.Interfaces.Queries;
using Domain.Entities;
using Infraestructure.Persistense;
using Microsoft.EntityFrameworkCore;


namespace Infraestructure.Queries
{
    public class VendedorQuery : IVendedorQuery
    {
        private readonly ArgenMotoDbContext _context;
        public VendedorQuery(ArgenMotoDbContext context)
        {
            _context = context;
        }
        public async Task<List<Vendedor>> ListaVendedores()
        {
            List<Vendedor> result = new List<Vendedor>();

            var vendedores = await _context.Vendedor.ToListAsync();
            return vendedores;
        }
        public Vendedor VendedoresPorId(int id)
        {
            var vendedor = _context.Vendedor.Find(id);

            return vendedor;
        }
    }
}
