using Application.Interfaces.Commands;
using Application.Interfaces.Queries;
using Application.Interfaces.Services;
using Application.Models;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCase
{
    public class MedioPagoServices : IMedioPagoService
    {
        private readonly IMedioPagoQuery _medioPagoQuery;
        private readonly IMedioPagoCommand _medioPagoCommand;

        public MedioPagoServices(IMedioPagoQuery medioPagoQuery, IMedioPagoCommand medioPagoCommand)
        {
            _medioPagoQuery = medioPagoQuery;
            _medioPagoCommand = medioPagoCommand;
        }

        public MedioPago MedioPagoPorId(int id)
        {
            return _medioPagoQuery.MedioPagoPorId(id);
        }

        public Task<List<MedioPago>> ListaMedioPago()
        {
            return _medioPagoQuery.ListaMedioPago();
        }
    }
}