using Application.Interfaces.Commands;
using Application.Models;
using Domain.Entities;
using Infraestructure.Persistense;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Commands
{
    public class MedioPagoCommand : IMedioPagoCommand
    {
        private readonly ArgenMotoDbContext _context;
        public MedioPagoCommand(ArgenMotoDbContext context)
        {
            _context = context;
        }

        public void DeleteMedioPago(MedioPago medioPago)
        {
            _context.MedioPago.Remove(medioPago);
            _context.SaveChanges();
        }

        public void ModificarMedioPago(MedioPago medioPago)
        {
            _context.MedioPago.Update(medioPago);
            _context.SaveChanges();

        }

        public MedioPago RegistrarMedioPago(MedioPago medioPago)
        {
            _context.MedioPago.Add(medioPago);
            _context.SaveChanges();
            return medioPago;
        }

        
    }
   
}