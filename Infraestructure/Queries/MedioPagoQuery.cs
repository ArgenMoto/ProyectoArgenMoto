using Application.Interfaces.Queries;
using Domain.Entities;
using Infraestructure.Persistense;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Queries
{
    public class MedioPagoQuery : IMedioPagoQuery
    {
        private readonly ArgenMotoDbContext _context;
        public MedioPagoQuery(ArgenMotoDbContext context)
        {
            _context = context;
        }
        public MedioPago MedioPagoPorId(int id)
        {
            var medioPago = _context.MedioPago.Find(id);

            return medioPago;
        }
    }
}
