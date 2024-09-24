using Application.Models;
using Domain.Entities;

namespace Application.Interfaces.Services
{
    public interface IVendedorService
    {
        Task<List<Vendedor>> ListaVendedores();
        Vendedor VendedoresPorId(int id);
        void EliminarVendedor(int id);
        Vendedor RegistrarVendedor(VendedorRequest vendedor);
        VendedorResponse UpdateVendedor(int id, VendedorRequest vendedor);
    }
}
