using Application.Interfaces.Commands;
using Domain.Entities;
using Infraestructure.Persistense;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Commands
{
    public class ArticuloProveedorCommand : IArticuloProveedorCommand
    {
        private readonly ArgenMotoDbContext _context;
        public ArticuloProveedorCommand(ArgenMotoDbContext context)
        {
            _context = context;
        }
        public ArticuloProveedor RegistrarArticuloProveedor(ArticuloProveedor articuloProveedor)
        {
            _context.ArticuloProveedor.Add(articuloProveedor);
            _context.SaveChanges();
            return articuloProveedor;

        }
    }
}
