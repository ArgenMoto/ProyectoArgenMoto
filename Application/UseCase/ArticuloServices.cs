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
        private readonly IArticuloProveedorCommand _articuloProveedorCommand;
        public ArticuloServices(IArticuloQuery articuloQuery, IProveedorQuery proveedorQuery)
        {
            _articuloQuery = articuloQuery;
            _proveedorQuery = proveedorQuery;
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
       

    }
}
