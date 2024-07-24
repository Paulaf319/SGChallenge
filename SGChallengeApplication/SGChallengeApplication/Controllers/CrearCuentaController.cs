using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SGChallengeApplication.Data.Dtos;
using SGChallengeApplication.Services.Interfaces;
using System.Security.Claims;

namespace SGChallengeApplication.Controllers
{
    [Route("api/[controller]/[action]")]
    [Authorize]
    [ApiController]
    public class CrearCuentaController : Controller
    {
        private readonly ICrearCuentaService _crearCuentaService;
        private readonly IAutenticarService _autenticarService;

        public CrearCuentaController(ICrearCuentaService crearCuentaService, IAutenticarService autenticarService)
        {
            _crearCuentaService = crearCuentaService;
            _autenticarService = autenticarService;
        }

        [HttpPost]
        public ActionResult Crear(CuentaCreateDTO cuenta)
        {
            var claimsIdentity = User.Identity as ClaimsIdentity;

            if (claimsIdentity == null)
            {
                return Unauthorized();
            }
            else
            {
                var autenticar = _autenticarService.Autenticar(claimsIdentity);

                if (!autenticar.Success)
                {
                    return BadRequest(autenticar.Message);
                }
                else
                {
                    var result = _crearCuentaService.CrearCuenta(autenticar.Message, cuenta);

                    if (!result.Success)
                    {
                        return Unauthorized(result.Message);
                    }
                    else
                    {
                        return Ok(result.Message);
                    }
                }
            }
        }
    }
}
