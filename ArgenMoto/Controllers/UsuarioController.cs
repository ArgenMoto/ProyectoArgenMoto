using Application.Interfaces.Services;
using Application.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace ArgenMoto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpPost("login")]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status404NotFound)]
        public IActionResult Login(UsuarioRequest usuario)
        {
            try
            {
                var usuarioLogin = _usuarioService.Login(usuario);
                return Ok(usuario); 
            }
            catch (Exception ex)
            {
                if (ex.Message == "Usuario no encontrado." ||
                    ex.Message == "Contraseña incorrecta.")
                {
                    return new JsonResult(new ErrorResponse { message = ex.Message }) { StatusCode = 404 };
                }

                return new JsonResult(500, "internal server error");

            }
        }

    }
}

