using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SGChallengeApplication.Services.Interfaces;
using System.Security.Claims;

namespace SGChallengeApplication.Controllers
{
    [Route("api/[controller]/[action]")]
    [Authorize]
    [ApiController]
    public class SaldoController : Controller
    {
        private readonly ISaldoService _saldoService;
        private readonly IAutenticarService _autenticarService;

        public SaldoController(ISaldoService saldoService, IAutenticarService autenticarService)
        {
            _saldoService = saldoService;
            _autenticarService = autenticarService;
        }

        [HttpGet]
        public ActionResult Consultar(int idCuenta)
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
                    var saldo = _saldoService.Consultar(int.Parse(autenticar.Message), idCuenta);

                    if (!saldo.Success)
                    {
                        return Unauthorized(saldo.Message);
                    }
                    else
                    {
                        return Ok(saldo.Message);
                    }
                }
            }
        }
    }
}
