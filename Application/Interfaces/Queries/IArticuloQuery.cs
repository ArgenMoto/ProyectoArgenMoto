using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Queries
{
    public interface IArticuloQuery
    {
        ArticuloProveedor articuloPorId(int id);
        List<ArticuloProveedor> ArticuloPorProveedor(int id);
    }
}
