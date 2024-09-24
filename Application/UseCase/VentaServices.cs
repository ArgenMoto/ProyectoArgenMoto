using Application.Interfaces.Commands;
using Application.Interfaces.Queries;
using Application.Interfaces.Services;
using Application.Models;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCase
{
    public class VentaServices:IVentaService
    {
        private readonly IClienteQuery _clienteQuery;
        private readonly IVentaCommand _ventaCommand;
        private readonly IProductoQuery _productoQuery;
        private readonly IItemCommand _itemCommand;
        private readonly IFacturaCommand _facturaCommand;
        private readonly IDocumentoQuery _documentoQuery;
        private readonly IMedioPagoQuery _medioPagoQuery;
        public VentaServices(IClienteQuery clienteQuery, IVentaCommand ventaCommand,
            IProductoQuery productoQuery, IItemCommand itemCommand, IFacturaCommand facturaCommand, 
            IDocumentoQuery documentoQuery, IMedioPagoQuery medioPagoQuery)
        {
            _clienteQuery = clienteQuery;
            _ventaCommand = ventaCommand;
            _productoQuery = productoQuery;
            _itemCommand = itemCommand;
            _facturaCommand = facturaCommand;
            _documentoQuery = documentoQuery;
            _medioPagoQuery = medioPagoQuery;
        }
        public VentaResponse RegistrarVenta(VentaRequest venta)
        {
            var cliente = _clienteQuery.ClientesPorId(venta.ClienteId);

            if (cliente == null)
            {
                throw new Exception("Cliente no encontrado, debe registrarlo");
            }

            var _venta = new Venta
            {
                ClienteId = cliente.ClienteId,
                VendedorId = venta.VendedorId,
                Fecha = DateTime.Now,
                TotalVenta = 0
            };

            _ventaCommand.registrarVenta(_venta);

            int totalVenta = 0;
            var itemsResponse = new List<ItemResponse>();

            foreach (var itemReq in venta.Items)
            {
                var producto = _productoQuery.ProductoPorId(itemReq.ProductoId);
                if (producto == null || itemReq.Cantidad > producto.Stock)
                {
                    throw new Exception("Producto no disponible o stock insuficiente.");
                }

                var precioTotalItem = itemReq.Cantidad * producto.PrecioUnitario;

                var item = new Item
                {
                    VentaId = _venta.VentaId,
                    ProductoId = itemReq.ProductoId,
                    Cantidad = itemReq.Cantidad,
                    PrecioTotalItem = precioTotalItem
                };

                totalVenta += precioTotalItem;
                _itemCommand.AgregarItem(item);
                producto.Stock -= itemReq.Cantidad; // Actualizar stock

                itemsResponse.Add(new ItemResponse
                {
                    ProductoId = itemReq.ProductoId,
                    Cantidad = itemReq.Cantidad,
                    PrecioTotalItem = precioTotalItem
                });

            }
            _venta.TotalVenta = totalVenta;
            _ventaCommand.actualizarVenta(_venta);


            var documento = _documentoQuery.DocumentoPorId(venta.DocumentoId); // Asegúrate de tener este método
            if (documento == null)
            {
                throw new Exception("Documento no encontrado.");
            }

            var medioPago = _medioPagoQuery.MedioPagoPorId(venta.MedioPagoId); // Asegúrate de tener este método
            if (medioPago == null)
            {
                throw new Exception("Medio de pago no encontrado.");
            }

            // Crear la factura automáticamente
            var factura = new Factura
            {
                VentaId = _venta.VentaId,
                Fecha = DateTime.Now,
                Total = totalVenta,
                DocumentoId = documento.DocumentoId,
                MedioPagoId = medioPago.MedioPagoId
            };

            _facturaCommand.registrarFactura(factura);

            VentaResponse ventaResponse = new VentaResponse
            {
                VentaId = _venta.VentaId,
                ClienteId = cliente.ClienteId,
                VendedorId = _venta.VendedorId,
                Fecha = _venta.Fecha,
                TotalVenta = totalVenta,
                Items = itemsResponse
            };

            return ventaResponse;
        }
    }
}
