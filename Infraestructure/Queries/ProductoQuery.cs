﻿using Application.Interfaces.Queries;
using Domain.Entities;
using Infraestructure.Persistense;
using Microsoft.EntityFrameworkCore;
namespace Infraestructure.Queries
{
    public class ProductoQuery : IProductoQuery
    {
        private readonly ArgenMotoDbContext _context;
        public ProductoQuery(ArgenMotoDbContext context)
        {
            _context = context;
        }
        public List<Producto> ListaProductos()
        {
            List<Producto> result = new List<Producto>();

          var productos = _context.Producto.ToList();
            return productos;
        }
        public Producto ProductoPorId(int id)
        {
            var producto = _context.Producto.Find(id);

            return producto;
        }
    }
}
