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
        Producto ProductoPorNumeroMotor(int nMotor);
        void EliminarProducto(int id);
        void EliminarProductoNMotor(int nmotor);
        Producto RegistrarProducto(ProductoRequest Producto);
        ProductoResponse ModificarProducto(int id, ProductoRequest Producto);
        ProductoResponse ModificarProductoNMotor(int nmotor, ProductoRequest Producto);
    }
}
