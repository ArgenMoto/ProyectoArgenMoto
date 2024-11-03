using Application.Models;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Commands
{
    public interface IProveedorCommand
    {
        void DeleteProveedor(Proveedor proveedor);
        Proveedor registrarProveedor(Proveedor proveedor);
        void ModificarProveedor(Proveedor proveedor);
        void EliminarProveedorCuit(Proveedor proveedor);
        void ModificarProveedorCuit(Proveedor proveedor);

    }
}
