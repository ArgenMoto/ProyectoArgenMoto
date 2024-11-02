using Application.Models;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Services
{
    public interface IClienteService
    {
        Task<List<Cliente>> ListaClientes();
        Cliente ClientesPorId(int id);
        Cliente ClientesPorDNI(int dni);
        void EliminarCliente(int id);
        Cliente RegistrarCliente(ClienteRequest cliente);
        ClienteResponse ModificarCliente(int id, ClienteRequest cliente);
    }
}