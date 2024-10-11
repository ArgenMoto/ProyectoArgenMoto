﻿using Application.Interfaces.Commands;
using Application.Interfaces.Queries;
using Application.Interfaces.Services;
using Application.Models;
using Domain.Entities;

namespace Application.UseCase
{
    public class OrdenDeCompraServices : IOrdenDeCompraService
    {
        private readonly IOrdenDeCompraCommand _ordenDeCompraCommand;
        private readonly IProveedorService _proveedorService;
        private readonly IArticuloQuery _articuloQuery;
        private readonly IOrdenDeCompraProductoCommand _ordenDeCompraProductoCommand;
        private readonly IProductoQuery _productoQuery;
        private readonly IProductoCommand _productoCommand;
        public OrdenDeCompraServices(IOrdenDeCompraCommand ordenDeCompraCommand, 
            IProveedorService proveedorService, IArticuloQuery articuloQuery, 
            IOrdenDeCompraProductoCommand ordenDeCompraProductoCommand, IProductoQuery productoQuery, 
            IProductoCommand productoCommand)
        {
            _ordenDeCompraCommand = ordenDeCompraCommand;
            _proveedorService = proveedorService;
            _articuloQuery = articuloQuery;
            _ordenDeCompraProductoCommand = ordenDeCompraProductoCommand;
            _productoQuery = productoQuery;
            _productoCommand = productoCommand;
        }
        public OrdenDeCompraResponse IngresarOrdenDeCompra(OrdenDeCompraRequest ordenDeCompra)
        {
            var proveedor = _proveedorService.ProveedoresPorId(ordenDeCompra.proveedorId);

            List<OrdenDeCompraProductoRequest> ordenDeCompraProductoRequest = new List<OrdenDeCompraProductoRequest>();

            var precioTotal = 0;

            foreach (var item in ordenDeCompra.productos)
            {
                var articulo = _articuloQuery.articuloPorId(item.ProductoId);

                if (articulo == null)
                {
                    throw new Exception("El articulo no existe");
                }

                var precioTotalLinea= item.Cantidad * articulo.PrecioUnitario;
                precioTotal += precioTotalLinea;

                var producto = _productoQuery.ProductoPorId(item.ProductoId);

                if (producto == null)
                {
                    throw new Exception("El producto no existe");
                }

                producto.StockActual += item.Cantidad; 

                _productoCommand.ModificarProducto(producto); 
            }

        
            OrdenDeCompra _ordenDeCompra = new OrdenDeCompra
            {
                Fecha = DateTime.Now,
                PrecioTotal =  precioTotal
            };

            _ordenDeCompraCommand.IngresarOrdenDeCompra(_ordenDeCompra);


            foreach (var item in ordenDeCompra.productos)
            {
                var articulo = _articuloQuery.articuloPorId(item.ProductoId);

                if (articulo == null)
                {
                    throw new Exception("El articulo no existe");
                }

                OrdenDeCompraProducto ordenDeCompraProducto = new OrdenDeCompraProducto
                {
                    OrdenDeCompraId = _ordenDeCompra.OrdenDeCompraId,
                    ArticuloProveedorId = item.ProductoId,
                    Cantidad = item.Cantidad,
                    TotalLinea = item.Cantidad * articulo.PrecioUnitario
                };

                _ordenDeCompraProductoCommand.IngresarOrdenDeCompraProducto(ordenDeCompraProducto);


                OrdenDeCompraProductoRequest _ordenDeCompraProducto = new OrdenDeCompraProductoRequest
                {
                    ProductoId = item.ProductoId,
                    Cantidad = item.Cantidad
                };
                ordenDeCompraProductoRequest.Add(_ordenDeCompraProducto);
            }

            return new OrdenDeCompraResponse
            {
                NumeroOrdenDeCompra = _ordenDeCompra.OrdenDeCompraId,
                ProveedorCuit = proveedor.Cuit,
                ProveedorNombre = proveedor.RazonSocial,
                Fecha = DateTime.Now,
                Productos = ordenDeCompraProductoRequest,
                Total = _ordenDeCompra.PrecioTotal
            };
        }
    }
}