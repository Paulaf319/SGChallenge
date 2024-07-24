using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SGChallengeApplication.Services;
using SGChallengeApplication.Services.Interfaces;
using System.Security.Claims;

namespace SGChallengeApplication.Controllers
{
    [Route("api/[controller]/[action]")]
    [Authorize]
    [ApiController]
    public class DepositoController : Controller
    {
        private readonly IDepositoService _depositoService;
        private readonly IAutenticarService _autenticarService;

        public DepositoController(IDepositoService depositoService, IAutenticarService autenticarService)
        {
            _depositoService = depositoService;
            _autenticarService = autenticarService;
        }

        [HttpPost]
        public ActionResult RealizarDeposito(int idCuenta, decimal monto)
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
                    var saldo = _depositoService.RealizarDeposito(int.Parse(autenticar.Message), idCuenta, monto);

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
