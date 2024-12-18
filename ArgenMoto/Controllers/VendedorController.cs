﻿using Application.Interfaces.Services;
using Application.Models;
using Microsoft.AspNetCore.Mvc;

namespace ArgenMoto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendedorController : ControllerBase
    {
        private readonly IVendedorService _service;

        public VendedorController(IVendedorService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllVendedores()
        {
            try
            {
                var result = await _service.ListaVendedores();

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
        public IActionResult GetVendedorById(int id)
        {
            try
            {
                var result = _service.VendedoresPorId(id);

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
        public IActionResult DeleteVendedor(int id)
        {
            try
            {
                _service.EliminarVendedor(id);


                return Ok();

            }
            catch (Exception ex)
            {

                return new JsonResult(500, "internal server error");

            }
        }
        [HttpPost]

        public IActionResult RegistrarVendedor(VendedorRequest vendedor)
        {
            try
            {
                var result = _service.RegistrarVendedor(vendedor);

                if (result != null)
                {
                    return new JsonResult(result) { StatusCode = 201 };
                }
                else
                {
                    return new JsonResult(new { message = "Error en la creacion del vendedor." }) { StatusCode = 400 };
                }
            }

            catch (Exception ex)
            {

                return new JsonResult(500, "internal server error");

            }
        }
        [HttpPut("{id}")]
        public IActionResult UpdateVendedor(int id, VendedorRequest vendedor)
        {
            try
            {
                var result = _service.UpdateVendedor(id, vendedor);

                if (result != null)
                {
                    return new JsonResult(result) { StatusCode = 200 };
                }
                else
                {
                    return new JsonResult(new { message = "Error al modificar el vendedor." }) { StatusCode = 400 };
                }
            }
            catch (Exception ex)
            {
                return new JsonResult(500, "internal server error");
            }
        }
        [HttpGet("dni/{dni}")]
        public IActionResult GetVendedorByDNI(int dni)
        {
            try
            {
                var result = _service.VendedoresPorDNI(dni);

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
        [HttpPut("dni/{dni}")]
        public IActionResult ModificarVendedorDNI(int dni, VendedorRequest vendedor)
        {
            try
            {
                var result = _service.ModificarVendedorDNI(dni, vendedor);

                if (result != null)
                {
                    return new JsonResult(result) { StatusCode = 200 };
                }
                else
                {
                    return new JsonResult(new { message = "Error al modificar el vendedor." }) { StatusCode = 400 };
                }
            }
            catch (Exception ex)
            {
                return new JsonResult(500, "internal server error");
            }
        }
        [HttpDelete("dni/{dni}")]
        public IActionResult EliminarVendedorDNI(int dni)
        {
            try
            {
                _service.EliminarVendedorDNI(dni);


                return Ok();

            }
            catch (Exception ex)
            {

                return new JsonResult(500, "internal server error");

            }
        }

    }
}
