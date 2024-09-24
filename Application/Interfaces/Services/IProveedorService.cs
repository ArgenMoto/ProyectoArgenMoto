using Application.Models;
using Domain.Entities;

namespace Application.Interfaces.Services
{
    public interface IProveedorService
    {
        Task<List<Proveedor>> ListaProveedores();
        Proveedor ProveedoresPorId(int id);
        void EliminarProveedor(int id);
        Proveedor RegistrarProveedor(ProveedorRequest proveedor);
        ProveedorResponse UpdateProveedor(int id, ProveedorRequest proveedor);
    }
}
