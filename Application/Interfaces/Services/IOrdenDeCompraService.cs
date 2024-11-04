using Application.Models;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Services
{
    public interface IOrdenDeCompraService
    {
        OrdenDeCompraResponse IngresarOrdenDeCompra(OrdenDeCompraRequest ordenDeCompra);
        OrdenDeCompraResponse OrdenDeCompraPorId(int id);
    }
}
