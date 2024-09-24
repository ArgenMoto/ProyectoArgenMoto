using Domain.Entities;

namespace Application.Interfaces.Queries
{
    public interface IVendedorQuery
    {
        Task<List<Vendedor>> ListaVendedores();
        Vendedor VendedoresPorId(int id);

    }
}
