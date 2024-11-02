using Application.Interfaces.Queries;
using Domain.Entities;
using Infraestructure.Persistense;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Queries
{
    public class ClienteQuery : IClienteQuery
    {
        private readonly ArgenMotoDbContext _context;
        public ClienteQuery(ArgenMotoDbContext context)
        {
            _context = context;
        }
        public async Task<List<Cliente>> ListaClientes()
        {
            List<Cliente> result = new List<Cliente>();

            var cliente = await _context.Cliente.ToListAsync();
            return cliente;
        }

        public Cliente ClientesPorId(int id)
        {
            var cliente = _context.Cliente.Find(id);

            return cliente;
        }

        public Cliente ClientesPorDNI(int dni)
        {
            var cliente = _context.Cliente.FirstOrDefault(c => c.DNI == dni);
            return cliente;
        }
    }
}