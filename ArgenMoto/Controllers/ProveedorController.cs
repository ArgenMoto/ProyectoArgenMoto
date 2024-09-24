using Application.Interfaces.Services;
using Application.Models;
using Microsoft.AspNetCore.Mvc;

namespace ArgenMoto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProveedorController : ControllerBase
    {
        private readonly IProveedorService _service;

        public ProveedorController(IProveedorService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var result = await _service.ListaProveedores();

                if (result.Any())
                {
                    return new JsonResult(result) { StatusCode = 200 };
                }

                return new JsonResult(result) { StatusCode = 200 };

            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetProveedorById(int id)
        {
            try
            {
                var result = _service.ProveedoresPorId(id);

                if (result != null)
                {
                    return new JsonResult(result) { StatusCode = 200 };
                }

                return new JsonResult(result) { StatusCode = 200 };

            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProveedor(int id)
        {
            try
            {
                _service.EliminarProveedor(id);


                return Ok();

            }
            catch (Exception ex)
            {

                return new JsonResult(500, "internal server error");

            }
        }
        [HttpPost]

        public IActionResult RegistrarProveedor(ProveedorRequest proveedor)
        {
            try
            {
                var result = _service.RegistrarProveedor(proveedor);

                if (result != null)
                {
                    return new JsonResult(result) { StatusCode = 201 };
                }
                else
                {
                    return new JsonResult(new { message = "Error en la creacion del proveedor." }) { StatusCode = 400 };
                }
            }

            catch (Exception ex)
            {

                return new JsonResult(500, "internal server error");

            }
        }
        [HttpPut("{id}")]
        public IActionResult UpdateProveedor(int id, ProveedorRequest mercaderia)
        {
            try
            {
                var result = _service.UpdateProveedor(id, mercaderia);

                if (result != null)
                {
                    return new JsonResult(result) { StatusCode = 200 };
                }
                else
                {
                    return new JsonResult(new { message = "Error al modificar el proveedor." }) { StatusCode = 400 };
                }
            }
            catch (Exception ex)
            {
                return new JsonResult(500, "internal server error");
            }
        }
    }
}
