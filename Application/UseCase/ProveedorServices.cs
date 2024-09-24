using Application.Interfaces.Commands;
using Application.Interfaces.Queries;
using Application.Interfaces.Services;
using Application.Models;
using Domain.Entities;

namespace Application.UseCase
{
    public class ProveedorServices : IProveedorService
    {
        private readonly IProveedorQuery _proveedorQuery;
        private readonly IProveedorCommand _proveedorCommand;

        public ProveedorServices(IProveedorQuery proveedorQuery, IProveedorCommand proveedorCommand)
        {
            _proveedorQuery = proveedorQuery;
            _proveedorCommand = proveedorCommand;
        }

        public void EliminarProveedor(int id)
        {
            var proveedor = _proveedorQuery.ProveedoresPorId(id);

            _proveedorCommand.DeleteProveedor(proveedor);

        }

        public Task<List<Proveedor>> ListaProveedores()
        {
            return _proveedorQuery.ListaProveedores();
        }

        public Proveedor ProveedoresPorId(int id)
        {
            return _proveedorQuery.ProveedoresPorId(id);
        }

        public Proveedor RegistrarProveedor(ProveedorRequest proveedor)
        {

            var _proveedor = new Proveedor
            {
                Nombre = proveedor.Nombre,
                Direccion = proveedor.Direccion,
                Telefono = proveedor.Telefono,
            };
            _proveedorCommand.registrarProveedor(_proveedor);
            return _proveedor;


        }

        public ProveedorResponse UpdateProveedor(int id, ProveedorRequest proveedor)
        {
            var _proveedor = _proveedorQuery.ProveedoresPorId(id);

            if (_proveedor == null)

                throw new Exception("Proveedor no encontrado");

            _proveedor.Nombre = proveedor.Nombre;
            _proveedor.Direccion = proveedor.Direccion;
            _proveedor.Telefono = proveedor.Telefono;

            _proveedorCommand.ModificarProveedor(_proveedor);

            ProveedorResponse proveedorResponse = new ProveedorResponse
            {
                Id = id,
                Nombre = proveedor.Nombre,
                Direccion = proveedor.Direccion,
                Telefono = proveedor.Telefono,
            };

            return proveedorResponse;

        }
    }
}
