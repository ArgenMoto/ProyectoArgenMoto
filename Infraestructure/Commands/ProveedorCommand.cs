using Application.Interfaces.Commands;
using Domain.Entities;
using Infraestructure.Persistense;

namespace Infraestructure.Commands
{
    public class ProveedorCommand : IProveedorCommand
    {
        private readonly ArgenMotoDbContext _context;
        public ProveedorCommand(ArgenMotoDbContext context)
        {
            _context = context;
        }

        public void DeleteProveedor(Proveedor proveedor)
        {
            _context.Proveedor.Remove(proveedor);
            _context.SaveChanges();
        }

        public void ModificarProveedor(Proveedor proveedor)
        {
            _context.Proveedor.Update(proveedor);
            _context.SaveChanges();

        }

        public void EliminarProveedorCuit(Proveedor proveedor)
        {
            _context.Proveedor.Remove(proveedor);
            _context.SaveChanges();
        }

        public void ModificarProveedorCuit(Proveedor proveedor)
        {
            _context.Proveedor.Update(proveedor);
            _context.SaveChanges();

        }

        public Proveedor registrarProveedor(Proveedor proveedor)
        {
            _context.Proveedor.Add(proveedor);
            _context.SaveChanges();
            return proveedor;
        }
    }
}
