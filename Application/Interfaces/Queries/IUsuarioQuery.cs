using Application.Models;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Queries
{
    public interface IUsuarioQuery
    {
        Usuario usuarioPorNombre(string nombre);
        Usuario usuarioPorNombreyContraseña(UsuarioRequest usuario);
    }
}
