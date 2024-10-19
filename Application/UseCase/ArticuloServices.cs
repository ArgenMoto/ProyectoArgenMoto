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
    public class ArticuloServices : IArticuloService
    {
        private readonly IArticuloQuery _articuloQuery;
        private readonly IProveedorQuery _proveedorQuery;
        private readonly IArticuloCommand _articuloCommand;
        private readonly IProductoQuery _productoQuery;
        public ArticuloServices(IArticuloQuery articuloQuery, IProveedorQuery proveedorQuery,
            IArticuloCommand articuloCommand, IProductoQuery productoQuery)
        {
            _articuloQuery = articuloQuery;
            _proveedorQuery = proveedorQuery;
            _articuloCommand = articuloCommand;
            _productoQuery = productoQuery;
        }

        public List<ArticuloResponse> ArticuloPorProveedor(int id)
        {
            var proveedor = _proveedorQuery.ProveedoresPorId(id);

            if (proveedor == null)
                throw new Exception("Proveedor no encontrado");

            var articulos = _articuloQuery.ArticuloPorProveedor(id);

            List<ArticuloResponse> articulosResponse = new List<ArticuloResponse>();

            foreach (var producto in articulos)
            {
                ArticuloResponse articuloResponse = new ArticuloResponse
                {
                    ArticuloId=producto.ArticuloProveedorId,
                    Nombre=producto.Nombre, 
                    Marca = producto.Marca,
                    Modelo = producto.Modelo,
                    ProductoId = producto.ProductoId,
                    PrecioUnitario = producto.PrecioUnitario

                    };
                articulosResponse.Add(articuloResponse);
            }
            return articulosResponse;
        }

        public ArticuloResponse RegistrarArticulo(ArticuloRequest articulo)
        {
            var producto= _productoQuery.ProductoPorNombreMarcaModelo(articulo.Nombre, articulo.Marca, articulo.Modelo);
            if (producto == null) 
                throw new Exception("Producto no encontrado para relacionar con articulo");
            
            var proveedor = _proveedorQuery.ProveedoresPorId(articulo.ProveedorId);

            if (proveedor == null)
                throw new Exception("Proveedor no encontrado para relacionar con articulo");

            var _articulo = new ArticuloProveedor
            {
                Nombre=articulo.Nombre,
                Marca=articulo.Marca,
                Modelo=articulo.Modelo,
                ProductoId=producto.ProductoId,
                PrecioUnitario=articulo.PrecioUnitario,
                ProveedorId=proveedor.ProveedorId
            };

            _articuloCommand.RegistrarArticulo(_articulo);

            ArticuloResponse articuloResponse = new ArticuloResponse
            {
                ArticuloId = _articulo.ArticuloProveedorId,
                Nombre = _articulo.Nombre,
                Marca = _articulo.Marca,
                Modelo = _articulo.Modelo,
                ProductoId = _articulo.ProductoId,
                PrecioUnitario = _articulo.PrecioUnitario
            };
            return articuloResponse;
        }
    }
}
