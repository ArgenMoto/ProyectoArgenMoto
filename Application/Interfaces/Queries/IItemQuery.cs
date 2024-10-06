using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Queries
{
    public interface IItemQuery
    {
        List<Item> ItemPorVentaId(Guid id);
    }
}
