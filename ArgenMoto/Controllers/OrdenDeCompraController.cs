﻿using Application.Interfaces.Services;
using Application.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ArgenMoto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdenDeCompraController : ControllerBase
    {
        private readonly IOrdenDeCompraService _service;

        public OrdenDeCompraController(IOrdenDeCompraService service)
        {
            _service = service;
        }
        [HttpPost]
        public IActionResult Post([FromBody] OrdenDeCompraRequest ordenDeCompra)
        {
            try
            {
                var result = _service.IngresarOrdenDeCompra(ordenDeCompra);

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
