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
    public class ArticuloCommand : IArticuloCommand
    {
        private readonly ArgenMotoDbContext _context;
        public ArticuloCommand(ArgenMotoDbContext context)
        {
            _context = context;
        }
        public void RegistrarArticulo(ArticuloProveedor articulo)
        {
            _context.ArticuloProveedor.Add(articulo);
            _context.SaveChanges();
        }
    }
}
