using Application.Interfaces.Commands;
using Application.Interfaces.Queries;
using Application.Interfaces.Services;
using Application.Models;
using Domain.Entities;

namespace Application.UseCase
{
    public class FacturaServices : IFacturaService
    {
        private readonly IFacturaQuery _facturaQuery;
        public FacturaServices(IFacturaQuery facturaQuery, IItemQuery itemQuery)
        {
            _facturaQuery = facturaQuery;
        }
        public Factura FacturaPorId(int id)
        {
            return _facturaQuery.FacturaPorId(id);
        }

        public List<FacturaResponse> ListaFacturas()
        {
            var listaFacturas= _facturaQuery.ListaFacturas();

            List<FacturaResponse> facturaResponses = new List<FacturaResponse>();

            foreach (var factura in listaFacturas)
            {
                var tipoFactura = factura.Documento.Descripcion;
                var medioPago = factura.MedioPago.Descripcion;
                var cliente = factura.Venta.Cliente;
                var vendedor = factura.Venta.Vendedor;
                //var items = _ItemQuery.ItemPorVentaId(factura.VentaId);
                var items = factura.Venta.Items;
                List<ItemResponse> itemResponse= new List<ItemResponse>();

                foreach (var item in items)
                {
                    itemResponse.Add(new ItemResponse
                    {
                        Id = item.ItemId,
                        ProductoId = item.ProductoId,
                        ProductoNombre = item.Producto.Nombre,
                        PrecioUnitario = item.Producto.PrecioUnitario,
                        Cantidad = item.Cantidad,
                        PrecioTotalItem = item.PrecioTotalItem 
                    });
                }
                ClienteResponseVenta clienteResponse = new ClienteResponseVenta
                {
                    DNI= cliente.DNI,
                    Nombre = cliente.Nombre,
                    Apellido = cliente.Apellido,
                    Domicilio = cliente.Domicilio
                };
                VendedorResponseVenta vendedorResponse = new VendedorResponseVenta
                {
                    VendedorNombre = vendedor.VendedorNombre,
                    VendedorPuesto = vendedor.VendedorPuesto
                };
                FacturaResponse facturaResponse = new FacturaResponse
                {
                    NumeroFactura = factura.FacturaId,
                    tipoFactura = tipoFactura,
                    medioPago = medioPago,
                    VentaId = factura.VentaId,
                    Fecha = factura.Fecha.ToString("dd/MM/yyyy"),
                    Cliente = clienteResponse,
                    Vendedor = vendedorResponse,
                    Items = itemResponse,
                    Total = factura.Total
                };
                
                facturaResponses.Add(facturaResponse);
            }
            return facturaResponses;
        }
    }
}
