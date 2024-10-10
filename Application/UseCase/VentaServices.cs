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
        private readonly IVendedorQuery _vendedorQuery;
        public VentaServices(IClienteQuery clienteQuery, IVentaCommand ventaCommand,
            IProductoQuery productoQuery, IItemCommand itemCommand, IFacturaCommand facturaCommand, 
            IDocumentoQuery documentoQuery, IMedioPagoQuery medioPagoQuery, IVendedorQuery vendedorQuery)
        {
            _clienteQuery = clienteQuery;
            _ventaCommand = ventaCommand;
            _productoQuery = productoQuery;
            _itemCommand = itemCommand;
            _facturaCommand = facturaCommand;
            _documentoQuery = documentoQuery;
            _medioPagoQuery = medioPagoQuery;
            _vendedorQuery = vendedorQuery;
        }
        public VentaResponse RegistrarVenta(VentaRequest venta)
        {
            var cliente = _clienteQuery.ClientesPorId(venta.ClienteId);
            
            //validamos si el cliente existe
            if (cliente == null)
            {
                throw new Exception("Cliente no encontrado, debe registrarlo");
            }
            //validamos el vendedor
            var vendedor = _vendedorQuery.VendedoresPorId(venta.VendedorId);
            if (vendedor == null)
            {
                throw new Exception("Vendedor no encontrado, debe registrarlo");
            }
            //validamos el documento
            var documento = _documentoQuery.DocumentoPorId(venta.DocumentoId);
            if (documento == null)
            {
                throw new Exception("Documento no encontrado.");
            }
            //validamos el medio de pago
            var medioPago = _medioPagoQuery.MedioPagoPorId(venta.MedioPagoId);
            if (medioPago == null)
            {
                throw new Exception("Medio de pago no encontrado.");
            }

            int totalVenta = 0;
            var itemsResponse = new List<ItemResponse>();

            // Validamos todos los productos y el stock antes de registrar en base de datos
            foreach (var itemReq in venta.Items)
            {
                var producto = _productoQuery.ProductoPorId(itemReq.ProductoId);
                if (producto == null)
                {
                    throw new ProductoNoDisponibleException($"Producto con ID {itemReq.ProductoId} no disponible.");
                }
                if (itemReq.Cantidad > producto.StockActual)
                {
                    throw new StockInsuficienteException($"Stock insuficiente para el producto {producto.Nombre}.");
                }

                var precioTotalItem = itemReq.Cantidad * producto.PrecioUnitario;
                totalVenta += precioTotalItem;                
            }
            
            var _venta = new Venta
            {
                ClienteId = cliente.ClienteId,
                VendedorId = venta.VendedorId,
                Fecha = DateTime.Now,
                TotalVenta = totalVenta
            };

            _ventaCommand.registrarVenta(_venta);

            foreach (var itemReq in venta.Items)
            {
                var producto = _productoQuery.ProductoPorId(itemReq.ProductoId);
                var precioTotalItem = itemReq.Cantidad * producto.PrecioUnitario;

                var item = new Item
                {
                    VentaId = _venta.VentaId,
                    ProductoId = itemReq.ProductoId,
                    Cantidad = itemReq.Cantidad,
                    PrecioTotalItem = precioTotalItem
                };
    
                _itemCommand.AgregarItem(item);
                producto.StockActual -= itemReq.Cantidad;

                itemsResponse.Add(new ItemResponse
                {
                    Id= item.ItemId,
                    ProductoId = itemReq.ProductoId,
                    ProductoNombre = producto.Nombre,
                    PrecioUnitario = producto.PrecioUnitario,
                    Cantidad = itemReq.Cantidad,
                    PrecioTotalItem = precioTotalItem
                });
            }

            var factura = new Factura
            {
                VentaId = _venta.VentaId,
                Fecha = DateTime.Today,
                Total = totalVenta,
                DocumentoId = documento.DocumentoId,
                MedioPagoId = medioPago.MedioPagoId
            };

            _facturaCommand.registrarFactura(factura);

            ClienteResponseVenta clienteResponse = new ClienteResponseVenta
            {
                DNI = cliente.DNI,
                Nombre = cliente.Nombre,
                Apellido = cliente.Apellido,
                Domicilio = cliente.Domicilio
            };

            VendedorResponseVenta vendedorResponse = new VendedorResponseVenta
            {
                VendedorNombre = vendedor.VendedorNombre,
                VendedorPuesto = vendedor.VendedorPuesto
            };

            // Creaamos y devolvemos la venta
            VentaResponse ventaResponse = new VentaResponse
            {
                VentaId = _venta.VentaId,
                FacturaId= factura.FacturaId,
                Fecha = _venta.Fecha,
                Cliente = clienteResponse,
                Vendedor = vendedorResponse,
                Items = itemsResponse,
                TotalVenta = totalVenta
            };

            return ventaResponse;
        }
    }
}
