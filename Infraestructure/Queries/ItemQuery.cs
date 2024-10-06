using Application.Interfaces.Queries;
using Domain.Entities;
using Infraestructure.Persistense;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Queries
{
    public class ItemQuery:IItemQuery
    {
        private readonly ArgenMotoDbContext _context;
        public ItemQuery(ArgenMotoDbContext context)
        {
            _context = context;
        }
        public List<Item> ItemPorVentaId(Guid id)
        {
            var listaItems = _context.Item
            .Include(i => i.Producto) // Incluye el Producto relacionado
            .Where(x => x.VentaId == id)
            .ToList();
            return listaItems;
        }
    }
}
