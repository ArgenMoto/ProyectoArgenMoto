using Application.Interfaces.Commands;
using Domain.Entities;
using Infraestructure.Persistense;


namespace Infraestructure.Commands
{
    public class OrdenDeCompraProductoCommand:IOrdenDeCompraProductoCommand
    {
        private readonly ArgenMotoDbContext _context;
        public OrdenDeCompraProductoCommand(ArgenMotoDbContext context)
        {
            _context = context;
        }

        public void IngresarOrdenDeCompraProducto(OrdenDeCompraProducto ordenDeCompra)
        {
            _context.OrdenDeCompraProducto.Add(ordenDeCompra);
            _context.SaveChanges();
        }
    }
}
