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
        private readonly IFacturaCommand _facturaCommand;
        public FacturaServices(IFacturaQuery facturaQuery, IFacturaCommand facturaCommand)
        {
            _facturaQuery = facturaQuery;
            _facturaCommand = facturaCommand;
        }

        public FacturaResponse CobrarFactura(int id, bool cobrado)
        {
            var factura= _facturaQuery.FacturaPorId(id);

            if (factura == null)
            {
                throw new Exception("Factura no encontrada");
            }

            factura.Cobrado = cobrado;

            _facturaCommand.cobrarFactura(factura);

            var tipoFactura = factura.Documento.Descripcion;
            var medioPago = factura.MedioPago.Descripcion;
            var cliente = factura.Venta.Cliente;
            var vendedor = factura.Venta.Vendedor;
            var items = factura.Venta.Items;
            List<ItemResponse> itemResponse = new List<ItemResponse>();

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
                Total = factura.Total,
                Cobrado = factura.Cobrado
            };

            return facturaResponse;
        }

        public FacturaResponse FacturaPorId(int id)
        {
            var factura= _facturaQuery.FacturaPorId(id);

            if (factura == null)
            {
                throw new Exception("Factura no encontrada");
            }
            var tipoFactura = factura.Documento.Descripcion;
            var medioPago = factura.MedioPago.Descripcion;
            var cliente = factura.Venta.Cliente;
            var vendedor = factura.Venta.Vendedor;
            var items = factura.Venta.Items;
            List<ItemResponse> itemResponse = new List<ItemResponse>();

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
                Total = factura.Total,
                Cobrado = factura.Cobrado
            };

            return facturaResponse;

        }

        public List<FacturaResponse> ListaFacturas()
        {
            var listaFacturas= _facturaQuery.ListaFacturas();

            if (listaFacturas.Count == 0)
            {
                throw new Exception("No hay facturas registradas");
            }

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
                    Total = factura.Total,
                    Cobrado = factura.Cobrado
                };
                
                facturaResponses.Add(facturaResponse);
            }
            return facturaResponses;
        }
        public List<FacturaResponse> ListaFacturas(bool cobrado)
        {
            var listaFacturas = _facturaQuery.ListaFacturas(cobrado);

            if (listaFacturas == null || listaFacturas.Count == 0)
            {
                throw new Exception("No hay facturas registradas");
            }

            List<FacturaResponse> facturaResponses = new List<FacturaResponse>();

            foreach (var factura in listaFacturas)
            {
                var tipoFactura = factura.Documento.Descripcion;
                var medioPago = factura.MedioPago.Descripcion;
                var cliente = factura.Venta.Cliente;
                var vendedor = factura.Venta.Vendedor;
                var items = factura.Venta.Items;

                List<ItemResponse> itemResponse = new List<ItemResponse>();

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
                    Total = factura.Total,
                    Cobrado = factura.Cobrado
                };

                facturaResponses.Add(facturaResponse);
            }

            return facturaResponses;
        }
    }
}
