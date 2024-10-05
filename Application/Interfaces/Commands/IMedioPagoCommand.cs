using Application.Models;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Commands
{
    public interface IMedioPagoCommand
    {
        void DeleteMedioPago(MedioPago medioPago);
        MedioPago RegistrarMedioPago(MedioPago medioPago);
        void ModificarMedioPago(MedioPago medioPago);
    }
}