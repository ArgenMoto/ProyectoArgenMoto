using Application.Interfaces.Commands;
using Application.Interfaces.Queries;
using Application.Interfaces.Services;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCase
{

        public class DocumentoServices : IDocumentoService
        {
            private readonly IDocumentoQuery _documentoQuery;

            public DocumentoServices(IDocumentoQuery documentoQuery)
            {
                _documentoQuery = documentoQuery;
            }

            public Documento DocumentoPorId(int id)
            {
                return _documentoQuery.DocumentoPorId(id);
            }

            public Task<List<Documento>> ListaDocumento()
            {
                return _documentoQuery.ListaDocumento();
            }
        }
    
}
