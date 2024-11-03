using Application.Models;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Commands
{
    public interface IProductoCommand
    {
        void EliminarProducto(Producto producto);
        Producto RegistrarProducto(Producto producto);
        void ModificarProducto(Producto producto);

        void EliminarProductoNMotor(Producto producto);
        void ModificarProductoNMotor(Producto producto);
    }
}
