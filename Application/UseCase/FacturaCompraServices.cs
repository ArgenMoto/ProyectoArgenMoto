using Application.Interfaces.Commands;
using Application.Interfaces.Queries;
using Application.Interfaces.Services;
using Application.Models;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCase
{
    public class FacturaCompraServices : IFacturaCompraService
    {
        private readonly IFacturaCompraQuery _facturaCompraQuery;
        private readonly IFacturaCompraCommand _facturaCompraCommand;
        public FacturaCompraServices(IFacturaCompraQuery facturaCompraQuery,
            IFacturaCompraCommand facturaCompraCommand)
        {
            _facturaCompraQuery = facturaCompraQuery;
            _facturaCompraCommand = facturaCompraCommand;

        }
        public FacturaCompraResponse PagarFactura(int id, bool cobrado)
        {
            var facturaCompra = _facturaCompraQuery.FacturaCompraPorId(id);

            if (facturaCompra == null)
            {
                throw new Exception("Factura no encontrada");
            }

            facturaCompra.Pagado = cobrado;

            _facturaCompraCommand.pagarFactura(facturaCompra);

            var OrdenDeCompra = facturaCompra.OrdenDeCompraId;
            var precio = facturaCompra.PrecioTotal;
            var articulos = facturaCompra.OrdenDeCompra.OrdenDeCompraProducto;
            List<ArticuloResponse> articuloResponse = new List<ArticuloResponse>();
            foreach (var articulo in articulos)
            {
                articuloResponse.Add(new ArticuloResponse
                {
                    ArticuloId = articulo.ArticuloProveedor.ArticuloProveedorId,
                    Nombre = articulo.ArticuloProveedor.Nombre,
                    Marca = articulo.ArticuloProveedor.Marca,
                    Modelo = articulo.ArticuloProveedor.Modelo,
                    ProductoId = articulo.ArticuloProveedor.ProductoId,
                    PrecioUnitario = articulo.ArticuloProveedor.PrecioUnitario
                });
            }


            FacturaCompraResponse facturaResponse = new FacturaCompraResponse
            {
                FacturaCompraId = facturaCompra.FacturaCompraId,
                OrdenDeCompraId = OrdenDeCompra,
                FechaEmision = facturaCompra.FechaEmision,
                Articulos = articuloResponse,
                PrecioTotal = precio,
                Pagado = cobrado

            };
            return facturaResponse;
        }
    }
}

