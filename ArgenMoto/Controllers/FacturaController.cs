using Application.Interfaces.Services;
using Application.Models;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ArgenMoto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacturaController : ControllerBase
    {
        private readonly IFacturaService _service;

        public FacturaController(IFacturaService service)
        {
            _service = service;
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<FacturaResponse>), StatusCodes.Status200OK)]
        public IActionResult ListadoFacturas()
        {
            try
            {
                var result = _service.ListaFacturas();
                if (result.Count != 0)
                {
                    return new JsonResult(result) { StatusCode = 200 };
                }
                return new JsonResult(new ErrorResponse { message = "No hay facturas registradas" }) { StatusCode = 404 };

            }
            catch (Exception ex)
            {
                if (ex.Message == "No hay facturas registradas")
                {
                    return new JsonResult(new ErrorResponse { message = ex.Message }) { StatusCode = 404 };
                }
                return new JsonResult(500, "internal server error");
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(FacturaResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status404NotFound)]
        public IActionResult FacturaPorId(int id)
        {
            try
            {
                var result = _service.FacturaPorId(id);

                if (result != null)
                {
                    return new JsonResult(result) { StatusCode = 200 };
                }
                else
                {
                    return new JsonResult(new ErrorResponse { message = "Factura no encontrada" }) { StatusCode = 404 };
                }
            }
            catch (Exception ex)
            {
                if (ex.Message == "Factura no encontrada")
                {
                    return new JsonResult(new ErrorResponse { message = ex.Message }) { StatusCode = 404 };
                }
                return new JsonResult(500, "internal server error");
            }
        }
    }
}
