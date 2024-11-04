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

        public Producto ProductoPorNumeroMotor(int nMotor)
        {
            return _productoQuery.ProductoPorNumeroMotor(nMotor);
        }

        public void EliminarProducto(int id)
        {
            var producto = _productoQuery.ProductoPorId(id);

            _productoCommand.EliminarProducto(producto);
        }
        public void EliminarProductoNMotor(int nmotor)
        {
            var producto = _productoQuery.ProductoPorNumeroMotor(nmotor);

            _productoCommand.EliminarProductoNMotor(producto);
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
                Marca = producto.Marca,
                Descripcion = producto.Descripcion,
                Modelo = producto.Modelo,
                NumeroMotor = producto.NumeroMotor,
                NumeroChasis = producto.NumeroChasis,
                Cilindro = producto.Cilindro,
                Fecha = producto.Fecha,
                PrecioUnitario = producto.PrecioUnitario,
                Rubro = producto.Rubro,
                StockMinimo = producto.StockMinimo,
                StockMaximo = producto.StockMaximo,
                StockActual = producto.StockActual,
                Imagen = producto.Imagen

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
            _producto.Marca = producto.Marca;
            _producto.Descripcion = producto.Descripcion;
            _producto.Modelo = producto.Modelo;
            _producto.NumeroMotor = producto.NumeroMotor;
            _producto.NumeroChasis = producto.NumeroChasis;
            _producto.Cilindro = producto.Cilindro;
            _producto.Fecha = producto.Fecha;
            _producto.PrecioUnitario = producto.PrecioUnitario;
            _producto.Rubro = producto.Rubro;
            _producto.StockMinimo = producto.StockMinimo;
            _producto.StockMaximo = producto.StockMaximo;
            _producto.StockActual = producto.StockActual;
            _producto.Imagen = producto.Imagen;


            _productoCommand.ModificarProducto(_producto);

            ProductoResponse productoResponse = new ProductoResponse
            {
                Id = id,
                Nombre = producto.Nombre,
                Marca = producto.Marca,
                Descripcion = producto.Descripcion,
                Modelo = producto.Modelo,
                NumeroMotor = producto.NumeroMotor,
                NumeroChasis = producto.NumeroChasis,
                Cilindro = producto.Cilindro,
                Fecha = producto.Fecha,
                PrecioUnitario = producto.PrecioUnitario,
                Rubro = producto.Rubro,
                StockMinimo = producto.StockMinimo,
                StockMaximo = producto.StockMaximo,
                StockActual = producto.StockActual,
                Imagen = producto.Imagen
            };

            return productoResponse;
        }

        public ProductoResponse ModificarProductoNMotor(int nmotor, ProductoRequest producto)
        {
            var _producto = _productoQuery.ProductoPorNumeroMotor(nmotor);

            if (_producto == null)

                throw new Exception("Producto no encontrado");

            _producto.Nombre = producto.Nombre;
            _producto.Marca = producto.Marca;
            _producto.Descripcion = producto.Descripcion;
            _producto.Modelo = producto.Modelo;
            _producto.NumeroMotor = producto.NumeroMotor;
            _producto.NumeroChasis = producto.NumeroChasis;
            _producto.Cilindro = producto.Cilindro;
            _producto.Fecha = producto.Fecha;
            _producto.PrecioUnitario = producto.PrecioUnitario;
            _producto.Rubro = producto.Rubro;
            _producto.StockMinimo = producto.StockMinimo;
            _producto.StockMaximo = producto.StockMaximo;
            _producto.StockActual = producto.StockActual;
            _producto.Imagen = producto.Imagen;


            _productoCommand.ModificarProductoNMotor(_producto);

            ProductoResponse productoResponse = new ProductoResponse
            {
                Id = _producto.ProductoId,
                Nombre = producto.Nombre,
                Marca = producto.Marca,
                Descripcion = producto.Descripcion,
                Modelo = producto.Modelo,
                NumeroMotor = producto.NumeroMotor,
                NumeroChasis = producto.NumeroChasis,
                Cilindro = producto.Cilindro,
                Fecha = producto.Fecha,
                PrecioUnitario = producto.PrecioUnitario,
                Rubro = producto.Rubro,
                StockMinimo = producto.StockMinimo,
                StockMaximo = producto.StockMaximo,
                StockActual = producto.StockActual,
                Imagen = producto.Imagen
            };

            return productoResponse;
        }
    }
}
