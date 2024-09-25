using Application.Interfaces.Services;
using Application.Models;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ArgenMoto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentaController : ControllerBase
    {
        private readonly IVentaService _service;

        public VentaController(IVentaService service)
        {
            _service = service;
        }

        [HttpPost("registro")]
        [ProducesResponseType(typeof(VentaResponse), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        public IActionResult RegistrarVenta(VentaRequest venta)
        {
            try
            {
                var result = _service.RegistrarVenta(venta);

                if (result != null)
                {
                    return new JsonResult(result) { StatusCode = 201 };
                }
                else
                {
                    return new JsonResult(new { message = "Error en la creacion de la venta." }) { StatusCode = 400 };
                }
            }
            catch (ProductoNoDisponibleException ex)
            {
                return new JsonResult(new ErrorResponse { message = ex.Message }) { StatusCode = 404 };
            }
            catch (StockInsuficienteException ex)
            {
                return new JsonResult(new ErrorResponse { message = ex.Message }) { StatusCode = 400 };
            }
            catch (Exception ex)
            {
                if (ex.Message == "Cliente no encontrado, debe registrarlo"||
                    ex.Message == "Vendedor no encontrado, debe registrarlo"||
                    ex.Message == "Documento no encontrado."||
                    ex.Message == "Medio de pago no encontrado.")
                {
                    return new JsonResult(new ErrorResponse { message = ex.Message }) { StatusCode = 404 };
                }

                return new JsonResult(500, "internal server error");

            }
        }
    }
}
