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
    public class ProductoServices : IProductoService
    {
        private readonly IProductoQuery _productoQuery;
        private readonly IProductoCommand _productoCommand;

        public ProductoServices(IProductoQuery productoQuery, IProductoCommand productoCommand)
        {
            _productoQuery = productoQuery;
            _productoCommand = productoCommand;
        }

        public Producto ProductoPorId(int id)
        {
            return _productoQuery.ProductoPorId(id);
        }

        public void EliminarProducto(int id)
        {
            var producto = _productoQuery.ProductoPorId(id);

            _productoCommand.EliminarProducto(producto);
        }

        public List<Producto> ListaProductos()
        {
            return _productoQuery.ListaProductos();
        }

        public Producto RegistrarProducto(ProductoRequest producto)
        {

            var _producto = new Producto
            {

                Nombre = producto.Nombre,
                Descripcion = producto.Descripcion,
                Marca = producto.Marca,
                PrecioUnitario = producto.PrecioUnitario,
                Stock = producto.Stock,
                Imagen = producto.Imagen,
                Rubro = producto.Rubro,
            
            };

            _productoCommand.RegistrarProducto(_producto);
            return _producto;
        }

        public ProductoResponse ModificarProducto(int id, ProductoRequest producto)
        {
            var _producto = _productoQuery.ProductoPorId(id);

            if (_producto == null)

                throw new Exception("Producto no encontrado");

            _producto.Nombre = producto.Nombre;
            _producto.Descripcion = producto.Descripcion;
            _producto.Marca = producto.Marca;
            _producto.PrecioUnitario = producto.PrecioUnitario;
            _producto.Stock = producto.Stock;
            _producto.Imagen = producto.Imagen;
            _producto.Rubro = producto.Rubro;


            _productoCommand.ModificarProducto(_producto);

            ProductoResponse productoResponse = new ProductoResponse
            {
                Id = id,
                Nombre = producto.Nombre,
                Descripcion = producto.Descripcion,
                Marca = producto.Marca,
                PrecioUnitario = producto.PrecioUnitario,
                Stock = producto.Stock,
                Imagen = producto.Imagen,
                Rubro = producto.Rubro,
            };

            return productoResponse;
        }
    }
}
