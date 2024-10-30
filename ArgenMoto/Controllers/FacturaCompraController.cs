using Application.Interfaces.Services;
using Application.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ArgenMoto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacturaCompraController : ControllerBase
    {
        private readonly IFacturaCompraService _service;

        public FacturaCompraController(IFacturaCompraService service)
        {
            _service = service;
        }

        [HttpPut("{id}")]
        public IActionResult PagarFactura(int id, bool cobrado)
        {
            try
            {
                var result = _service.PagarFactura(id, cobrado);

                if (result != null)
                {
                    return new JsonResult(result) { StatusCode = 200 };
                }
                else
                {
                    return new JsonResult(new { message = "Error al modificar la factura." }) { StatusCode = 400 };
                }
            }
            catch (Exception ex)
            {
                return new JsonResult(500, "internal server error");
            }
        }
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(FacturaCompraResponse), StatusCodes.Status200OK)]
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
