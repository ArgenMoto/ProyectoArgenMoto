using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Queries
{
    public interface IProductoQuery
    {
        List<Producto> ListaProductos();
        Producto ProductoPorId(int id);
        Producto ProductoPorNombreMarcaModelo(string nombre, string marca,string modelo);
    }
}
