using Application.Interfaces.Commands;
using Domain.Entities;
using Infraestructure.Persistense;

namespace Infraestructure.Commands
{
    public class VendedorCommand : IVendedorCommand
    {
        private readonly ArgenMotoDbContext _context;
        public VendedorCommand(ArgenMotoDbContext context)
        {
            _context = context;
        }

        public void DeleteVendedor(Vendedor vendedor)
        {
            _context.Vendedor.Remove(vendedor);
            _context.SaveChanges();
        }

        public void ModificarVendedor(Vendedor vendedor)
        {
            _context.Vendedor.Update(vendedor);
            _context.SaveChanges();

        }
        public void EliminarVendedorDNI(Vendedor vendedor)
        {
            _context.Vendedor.Remove(vendedor);
            _context.SaveChanges();
        }

        public void ModificarVendedorDNI(Vendedor vendedor)
        {
            _context.Vendedor.Update(vendedor);
            _context.SaveChanges();

        }

        public Vendedor registrarVendedor(Vendedor vendedor)
        {
            _context.Vendedor.Add(vendedor);
            _context.SaveChanges();
            return vendedor;
        }
    }
}
