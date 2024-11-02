using Application.Interfaces.Services;
using Application.Models;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

namespace ArgenMoto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteService _service;

        public ClienteController(IClienteService service)
        {
            _service = service;
        }
                 
        [HttpPost]

        public IActionResult RegistrarCliente(ClienteRequest cliente)
        {
            try
            {
                var result = _service.RegistrarCliente(cliente);

                if (result != null)
                {
                    return new JsonResult(result) { StatusCode = 201 };
                }
                else
                {
                    return new JsonResult(new { message = "Error en la creacion del Cliente." }) { StatusCode = 400 };
                }
            }

            catch (Exception ex)
            {

                return new JsonResult(500, "internal server error");

            }
        }

        [HttpPut("{id}")]
        public IActionResult ModificarCliente(int id, ClienteRequest cliente)
        {
            try
            {
                var result = _service.ModificarCliente(id, cliente);

                if (result != null)
                {
                    return new JsonResult(result) { StatusCode = 200 };
                }
                else
                {
                    return new JsonResult(new { message = "Error al modificar el Cliente." }) { StatusCode = 400 };
                }
            }
            catch (Exception ex)
            {
                return new JsonResult(500, "internal server error");
            }
        }
        [HttpDelete("{id}")]
        public IActionResult EliminarCliente(int id)
        {
            try
            {
                _service.EliminarCliente(id);


                return Ok();

            }
            catch (Exception ex)
            {

                return new JsonResult(500, "internal server error");

            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var result = await _service.ListaClientes();

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
        public IActionResult GetClientesById(int id)
        {
            try
            {
                var result = _service.ClientesPorId(id);

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
        [HttpGet("dni/{dni}")]
        public IActionResult GetClientesByDNI(int dni)
        {
            try
            {
                var result = _service.ClientesPorDNI(dni);

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

    }

}