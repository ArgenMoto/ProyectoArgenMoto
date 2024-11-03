using Application.Models;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Commands
{
    public interface IClienteCommand
    {
        void EliminarCliente(Cliente cliente);
        Cliente RegistrarCliente(Cliente cliente);
        void ModificarCliente(Cliente cliente);
        void EliminarClienteDNI(Cliente cliente);
        void ModificarClienteDNI(Cliente cliente);

    }
}