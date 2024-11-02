using Application.Interfaces.Services;
using Application.Models;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ArgenMoto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly IProductoService _service;

        public ProductoController(IProductoService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var result = _service.ListaProductos();

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
        public IActionResult GetProductoById(int id)
        {
            try
            {
                var result = _service.ProductoPorId(id);

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

        [HttpGet("numeroMotor/{numeroMotor}")]
        public IActionResult GetProductoByNumeroMotor(int numeroMotor)
        {
            try
            {
                var result = _service.ProductoPorNumeroMotor(numeroMotor);

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
        public IActionResult DeleteProducto(int id)
        {
            try
            {
                _service.EliminarProducto(id);


                return Ok();

            }
            catch (Exception ex)
            {

                return new JsonResult(500, "internal server error");

            }
        }
        [HttpPost]

        public IActionResult RegistrarProducto(ProductoRequest producto)
        {
            try
            {
                var result = _service.RegistrarProducto(producto);

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
        public IActionResult UpdateProducto(int id, ProductoRequest Producto)
        {
            try
            {
                var result = _service.ModificarProducto(id, Producto);

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

