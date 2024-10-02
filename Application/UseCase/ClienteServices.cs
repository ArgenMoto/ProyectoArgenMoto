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
    public class ClienteServices : IClienteService
    {
        private readonly IClienteQuery _clienteQuery;
        private readonly IClienteCommand _clienteCommand;

        public ClienteServices(IClienteQuery clienteQuery, IClienteCommand clienteCommand)
        {
            _clienteQuery = clienteQuery;
            _clienteCommand = clienteCommand;
        }
                
        public Cliente ClientesPorId(int id)
        {
            return _clienteQuery.ClientesPorId(id);
        }

        public void EliminarCliente(int id)
        {
            var cliente = _clienteQuery.ClientesPorId(id);

            _clienteCommand.EliminarCliente(cliente);
        }

        public Task<List<Cliente>> ListaClientes()
        {
            return _clienteQuery.ListaClientes();
        }

        public Cliente RegistrarCliente(ClienteRequest cliente)
        {

            var _cliente= new Cliente {
                
                DNI = cliente.DNI,
                Nombre = cliente.Nombre,
                Apellido = cliente.Apellido, 
                Domicilio=cliente.Domicilio,
                Localidad= cliente.Localidad,
                Provincia= cliente.Provincia,
                Telefono= cliente.Telefono,
                Email= cliente.Email,
            
            };

            _clienteCommand.RegistrarCliente(_cliente);
            return _cliente;
        }

        public ClienteResponse ModificarCliente(int id, ClienteRequest cliente)
        {
            var _cliente=_clienteQuery.ClientesPorId(id);

            if (_cliente == null)

                throw new Exception("Cliente no encontrado");

            _cliente.DNI = cliente.DNI;
            _cliente.Nombre = cliente.Nombre;
            _cliente.Apellido = cliente.Apellido;
            _cliente.Domicilio = cliente.Domicilio;
            _cliente.Localidad = cliente.Localidad;
            _cliente.Provincia= cliente.Provincia;
            _cliente.Telefono = cliente.Telefono;
            _cliente.Email= cliente.Email;

            _clienteCommand.ModificarCliente(_cliente);

            ClienteResponse clienteResponse = new ClienteResponse
            {
                Id = id,
                DNI = cliente.DNI,
                Nombre = cliente.Nombre,
                Apellido= cliente.Apellido,
                Domicilio= cliente.Domicilio,
                Localidad= cliente.Localidad,
                Provincia= cliente.Provincia,
                Telefono= cliente.Telefono,
                Email= cliente.Email,

            };

            return clienteResponse;
        }
    }
}
