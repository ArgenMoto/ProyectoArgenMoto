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
    public class UsuarioServices : IUsuarioService
    {
        private readonly IUsuarioQuery _usuarioQuery;

        public UsuarioServices(IUsuarioQuery usuarioQuery)
        {
            _usuarioQuery = usuarioQuery;
        }
        public UsuarioRequest Login(UsuarioRequest usuario)
        {
            var usuarioEncontrado = _usuarioQuery.usuarioPorNombre(usuario.Nombre);

            if (usuarioEncontrado == null)
            {
                throw new Exception("Usuario no encontrado.");
            }

            if (usuarioEncontrado.Contrasena != usuario.Contrasena)
            {
                throw new Exception("Contraseña incorrecta.");
            }
            
            return usuario;
        }
    }
}
