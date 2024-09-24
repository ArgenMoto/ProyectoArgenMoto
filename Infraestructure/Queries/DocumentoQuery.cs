using Application.Interfaces.Queries;
using Domain.Entities;
using Infraestructure.Persistense;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Queries
{
    public class DocumentoQuery : IDocumentoQuery
    {
        private readonly ArgenMotoDbContext _context;
        public DocumentoQuery(ArgenMotoDbContext context)
        {
            _context = context;
        }
        public Documento DocumentoPorId(int id)
        {
            var documento = _context.Documento.Find(id);

            return documento;
        }
    }
}
