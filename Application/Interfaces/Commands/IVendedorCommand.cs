﻿using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Commands
{
    public interface IVendedorCommand
    {
        void DeleteVendedor(Vendedor vendedor);
        Vendedor registrarVendedor(Vendedor vendedor);
        void ModificarVendedor(Vendedor vendedor);
    }
}
