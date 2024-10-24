﻿using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Commands
{
    public interface IFacturaCommand
    {
        void registrarFactura(Factura factura);
        void cobrarFactura(Factura factura);
    }
}
