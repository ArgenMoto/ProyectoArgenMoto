using Application.Interfaces.Commands;
using Application.Models;
using Domain.Entities;
using Infraestructure.Persistense;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Commands
{
    public class ClienteCommand : IClienteCommand
    {
        private readonly ArgenMotoDbContext _context;
        public ClienteCommand(ArgenMotoDbContext context)
        {
            _context = context;
        }

        public void EliminarCliente(Cliente cliente)
        {
            _context.Cliente.Remove(cliente);
            _context.SaveChanges();
        }

        public void ModificarCliente(Cliente cliente)
        {
            _context.Cliente.Update(cliente);
            _context.SaveChanges();
        }

        public Cliente RegistrarCliente(Cliente cliente)
        {
            _context.Cliente.Add(cliente);
            _context.SaveChanges();
            return cliente;
        }
    }
}