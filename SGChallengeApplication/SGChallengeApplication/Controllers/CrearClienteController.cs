using Microsoft.AspNetCore.Mvc;
using SGChallengeApplication.Data.Dtos;
using SGChallengeApplication.Services.Interfaces;

namespace SGChallengeApplication.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CrearClienteController : Controller
    {
        private readonly ICrearClienteService _crearClienteService;

        public CrearClienteController(ICrearClienteService crearClienteService)
        {
            _crearClienteService = crearClienteService;
        }

        [HttpPost]
        public ActionResult Crear(ClienteCreateDTO cliente)
        {
            var result = _crearClienteService.CrearCliente(cliente);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }
            else
            {
                return Ok(result.Message);
            }
        }
    }
}
