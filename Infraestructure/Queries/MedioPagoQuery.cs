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
    public class MedioPagoQuery : IMedioPagoQuery
    {
        private readonly ArgenMotoDbContext _context;
        public MedioPagoQuery(ArgenMotoDbContext context)
        {
            _context = context;
        }

        public async Task<List<MedioPago>> ListaMedioPago()
        {
            List<MedioPago> result = new List<MedioPago>();

            var medioPago = await _context.MedioPago.ToListAsync();
            return medioPago;
        }

        public MedioPago MedioPagoPorId(int id)
        {
            var medioPago = _context.MedioPago.Find(id);

            return medioPago;
        }
    }
}
