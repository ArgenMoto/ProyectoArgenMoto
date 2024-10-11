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
    public class FacturaQuery:IFacturaQuery
    {
        private readonly ArgenMotoDbContext _context;
        public FacturaQuery(ArgenMotoDbContext context)
        {
            _context = context;
        }
        public List<Factura> ListaFacturas()
        {
            var facturas = _context.Factura
            .Include(f => f.Venta)                    // Incluye la Venta relacionada
                .ThenInclude(v => v.Cliente)          // Incluye el Cliente relacionado a la Venta
            .Include(f => f.Venta.Vendedor)           // Incluye el Vendedor relacionado a la Venta
            .Include(f => f.Venta.Items)              // Incluye los Items relacionados a la Venta
                .ThenInclude(i => i.Producto)         // Incluye el Producto relacionado a cada Item
            .Include(f => f.MedioPago)                // Incluye el MedioPago relacionado a la Factura
            .Include(f => f.Documento)                // Incluye el Documento relacionado a la Factura
            .ToList();

            return facturas;
        }
        public Factura FacturaPorId(int id)
        {
            var factura = _context.Factura
            .Include(f => f.Venta)                    
                .ThenInclude(v => v.Cliente)          
            .Include(f => f.Venta.Vendedor)           
            .Include(f => f.Venta.Items)              
                .ThenInclude(i => i.Producto)         
            .Include(f => f.MedioPago)                
            .Include(f => f.Documento)               
            .FirstOrDefault(f => f.FacturaId == id);  

            return factura;
        }
    }
}
