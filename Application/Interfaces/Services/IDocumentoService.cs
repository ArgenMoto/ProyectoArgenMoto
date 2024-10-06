using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Services
{
    public interface IDocumentoService
    {
        Task<List<Documento>> ListaDocumento();
        Documento DocumentoPorId(int id);

    }
}
