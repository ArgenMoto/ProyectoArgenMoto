using Application.Models;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Services
{
    public interface IProductoService
    {
        List<Producto> ListaProductos();
        Producto ProductoPorId(int id);
        void EliminarProducto(int id);
        Producto RegistrarProducto(ProductoRequest Producto);
        ProductoResponse ModificarProducto(int id, ProductoRequest Producto);
    }
}
