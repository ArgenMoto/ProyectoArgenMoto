using Application.Models;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Services
{
    public interface IFacturaService
    {
        List<FacturaResponse> ListaFacturas();
        List<FacturaResponse> ListaFacturas(bool cobrado);
        FacturaResponse FacturaPorId(int id);
    }
}
