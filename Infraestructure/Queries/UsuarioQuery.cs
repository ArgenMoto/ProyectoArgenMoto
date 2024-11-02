using Application.Interfaces.Queries;
using Application.Models;
using Domain.Entities;
using Infraestructure.Persistense;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Queries
{
    public class UsuarioQuery : IUsuarioQuery
    {
        private readonly ArgenMotoDbContext _context;
        public UsuarioQuery(ArgenMotoDbContext context)
        {
            _context = context;
        }
        public Usuario usuarioPorNombre(string nombre)
        {
            return _context.Usuario.FirstOrDefault(u => u.Nombre == nombre);
        }

        public Usuario usuarioPorNombreyContraseña(UsuarioRequest usuarioRequest)
        {
           
            return _context.Usuario.FirstOrDefault(u => u.Nombre == usuarioRequest.Nombre
                                          && u.Contrasena == usuarioRequest.Contrasena);
        }
    }
}
