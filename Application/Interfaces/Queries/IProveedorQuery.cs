using Domain.Entities;

namespace Application.Interfaces.Queries
{
    public interface IProveedorQuery
    {
        Task<List<Proveedor>> ListaProveedores();
        Proveedor ProveedoresPorId(int id);
        Proveedor ProveedoresPorCuit(string cuit);
    }
}
