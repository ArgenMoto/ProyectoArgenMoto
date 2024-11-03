using Application.Models;
using Domain.Entities;

namespace Application.Interfaces.Services
{
    public interface IProveedorService
    {
        Task<List<Proveedor>> ListaProveedores();
        Proveedor ProveedoresPorId(int id);
        Proveedor ProveedoresPorCuit(string cuit);
        void EliminarProveedor(int id);
        void EliminarProveedorCuit(string Cuit);
        Proveedor RegistrarProveedor(ProveedorRequest proveedor);
        ProveedorResponse UpdateProveedor(int id, ProveedorRequest proveedor);
        ProveedorResponse ModificarProveedorCuit(string Cuit, ProveedorRequest proveedor);
        
    }
}
