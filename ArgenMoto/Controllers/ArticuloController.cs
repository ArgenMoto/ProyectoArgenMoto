using Application.Interfaces.Services;
using Application.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ArgenMoto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticuloController : ControllerBase
    {
        private readonly IArticuloService _service;

        public ArticuloController(IArticuloService service)
        {
            _service = service;
        }

        [HttpGet("proveedor/{id}")]
        public IActionResult ArticuloPorProveedor(int id)
        {
            try
            {
                var result = _service.ArticuloPorProveedor(id);

                if (result.Any())
                {
                    return new JsonResult(result) { StatusCode = 200 };
                }

                return new JsonResult(result) { StatusCode = 200 };

            }
            catch (Exception ex)
            {
                if (ex.Message == "Proveedor no encontrado")
                {
                    return new JsonResult(new ErrorResponse { message = ex.Message }) { StatusCode = 404 };
                }
                return new JsonResult(500, "internal server error");
            }
        }

    }
}
