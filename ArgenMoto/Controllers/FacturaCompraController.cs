using Application.Interfaces.Services;
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
    }
}
