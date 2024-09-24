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
    public class ItemCommand:IItemCommand
    {
        private readonly ArgenMotoDbContext _context;
        public ItemCommand(ArgenMotoDbContext context)
        {
            _context = context;
        }
        public void AgregarItem(Item item)
        {
            _context.Item.Add(item);
            _context.SaveChanges();
        }
    }
}
