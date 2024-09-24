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
   public class ProductoCommand: IProductoCommand
    {
        private readonly ArgenMotoDbContext _context;
        public ProductoCommand(ArgenMotoDbContext context)
        {
            _context = context;
        }

        public void EliminarProducto(Producto producto)
        {
            _context.Producto.Remove(producto);
            _context.SaveChanges();
        }

        public void ModificarProducto(Producto producto)
        {
            _context.Producto.Update(producto);
            _context.SaveChanges();

        }

        public Producto RegistrarProducto(Producto producto)
        {
            _context.Producto.Add(producto);
            _context.SaveChanges();
            return producto;
        }
    }
}
