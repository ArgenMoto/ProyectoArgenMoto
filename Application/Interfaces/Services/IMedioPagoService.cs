using Application.Models;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Services
{
    public interface IMedioPagoService
    {
        Task<List<MedioPago>> ListaMedioPago();
        MedioPago MedioPagoPorId(int id);
       
    }
}