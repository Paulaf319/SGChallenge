using Microsoft.AspNetCore.Mvc;
using SGChallengeApplication.Data.Dtos;
using SGChallengeApplication.Services.Interfaces;

namespace SGChallengeApplication.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CrearUsuarioController : Controller
    {
        private readonly ICrearUsuarioService _crearUsuarioService;

        public CrearUsuarioController(ICrearUsuarioService crearUsuarioService)
        {
            _crearUsuarioService = crearUsuarioService;
        }

        [HttpPost]
        public ActionResult Crear(UsuarioCreateDTO usuario)
        {
            var respuest = _crearUsuarioService.CrearUsuario(usuario);

            if (!respuest.Success)
            {
                return BadRequest(respuest.Message);
            }
            else
            {
                return Ok(respuest.Message);
            }
        }
    }
}
