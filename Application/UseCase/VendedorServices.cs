using Application.Interfaces.Commands;
using Application.Interfaces.Queries;
using Application.Interfaces.Services;
using Application.Models;
using Domain.Entities;

namespace Application.UseCase
{
    public class VendedorServices : IVendedorService
    {
        private readonly IVendedorQuery _vendedorQuery;
        private readonly IVendedorCommand _vendedorCommand;

        public VendedorServices(IVendedorQuery vendedorQuery, IVendedorCommand vendedorCommand)
        {
            _vendedorQuery = vendedorQuery;
            _vendedorCommand = vendedorCommand;
        }

        public Task<List<Vendedor>> ListaVendedores()
        {
            return _vendedorQuery.ListaVendedores();
        }

        public void EliminarVendedor(int id)
        {
            var vendedor = _vendedorQuery.VendedoresPorId(id);

            _vendedorCommand.DeleteVendedor(vendedor);

        }
        public Vendedor VendedoresPorId(int id)
        {
            return _vendedorQuery.VendedoresPorId(id);
        }
        public Vendedor VendedoresPorDNI(int dni)
        {
            return _vendedorQuery.VendedoresPorDNI(dni);
        }

        public Vendedor RegistrarVendedor(VendedorRequest vendedor)
        {

            var _vendedor = new Vendedor
            {
                VendedorNombre = vendedor.VendedorNombre,
                VendedorApellido = vendedor.VendedorApellido,
                VendedorPuesto = vendedor.VendedorPuesto,
                VendedorDni = vendedor.VendedorDni,
                VendedorDomicilio = vendedor.VendedorDomicilio,
                VendedorLocalidad = vendedor.VendedorLocalidad,
                VendedorProvincia = vendedor.VendedorProvincia,
                VendedorTelefono = vendedor.VendedorTelefono,
                VendedorEmail = vendedor.VendedorEmail,
            };
            _vendedorCommand.registrarVendedor(_vendedor);
            return _vendedor;
        }

        public VendedorResponse UpdateVendedor(int id, VendedorRequest vendedor)
        {
            var _vendedor = _vendedorQuery.VendedoresPorId(id);

            if (_vendedor == null)

                throw new Exception("Vendedor no encontrado");

            _vendedor.VendedorNombre = vendedor.VendedorNombre;
            _vendedor.VendedorApellido = vendedor.VendedorApellido;
            _vendedor.VendedorPuesto = vendedor.VendedorPuesto;
            _vendedor.VendedorDni = vendedor.VendedorDni;
            _vendedor.VendedorDomicilio = vendedor.VendedorDomicilio;
            _vendedor.VendedorLocalidad = vendedor.VendedorLocalidad;
            _vendedor.VendedorProvincia = vendedor.VendedorProvincia;
            _vendedor.VendedorTelefono = vendedor.VendedorTelefono;
            _vendedor.VendedorEmail = vendedor.VendedorEmail;

            _vendedorCommand.ModificarVendedor(_vendedor);

            VendedorResponse vendedorResponse = new VendedorResponse
            {
                VendedorId = id,
                VendedorNombre = vendedor.VendedorNombre,
                VendedorApellido = vendedor.VendedorApellido,
                VendedorPuesto = vendedor.VendedorPuesto,
                VendedorDni = vendedor.VendedorDni,
                VendedorDomicilio = vendedor.VendedorDomicilio,
                VendedorLocalidad = vendedor.VendedorLocalidad,
                VendedorProvincia = vendedor.VendedorProvincia,
                VendedorTelefono = vendedor.VendedorTelefono,
                VendedorEmail = vendedor.VendedorEmail
            };

            return vendedorResponse;

        }

    }
}
