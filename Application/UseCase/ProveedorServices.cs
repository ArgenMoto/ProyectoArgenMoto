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
                Cuit=proveedor.Cuit,
                RazonSocial=proveedor.RazonSocial,
                Apellido=proveedor.Apellido,
                Nombre = proveedor.Nombre,
                Direccion = proveedor.Direccion,
                Localidad=proveedor.Localidad,
                Provincia=proveedor.Provincia,
                Telefono = proveedor.Telefono,
                Email=proveedor.Email,
            };
            _proveedorCommand.registrarProveedor(_proveedor);
            return _proveedor;


        }

        public ProveedorResponse UpdateProveedor(int id, ProveedorRequest proveedor)
        {
            var _proveedor = _proveedorQuery.ProveedoresPorId(id);

            if (_proveedor == null)

                throw new Exception("Proveedor no encontrado");

            _proveedor.Cuit = proveedor.Cuit;
            _proveedor.RazonSocial = proveedor.RazonSocial;
            _proveedor.Apellido = proveedor.Apellido;
            _proveedor.Nombre = proveedor.Nombre;
            _proveedor.Direccion = proveedor.Direccion;
            _proveedor.Localidad = proveedor.Localidad;
            _proveedor.Provincia = proveedor.Provincia;
            _proveedor.Telefono = proveedor.Telefono;
            _proveedor.Email = proveedor.Email;

            _proveedorCommand.ModificarProveedor(_proveedor);

            ProveedorResponse proveedorResponse = new ProveedorResponse
            {
                Id = id,
                Cuit = proveedor.Cuit,
                RazonSocial = proveedor.RazonSocial,
                Apellido = proveedor.Apellido,
                Nombre = proveedor.Nombre,
                Direccion = proveedor.Direccion,
                Localidad = proveedor.Localidad,
                Provincia = proveedor.Provincia,
                Telefono = proveedor.Telefono,
                Email = proveedor.Email,
            };

            return proveedorResponse;

        }
    }
}
