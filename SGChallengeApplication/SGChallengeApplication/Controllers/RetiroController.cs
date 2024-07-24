using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SGChallengeApplication.Services.Interfaces;
using System.Security.Claims;

namespace SGChallengeApplication.Controllers
{
    [Route("api/[controller]/[action]")]
    [Authorize]
    [ApiController]
    public class RetiroController : Controller
    {
        private readonly IRetiroService _retiroService;
        private readonly IAutenticarService _autenticarService;

        public RetiroController(IRetiroService retiroService, IAutenticarService autenticarService)
        {
            _retiroService = retiroService;
            _autenticarService = autenticarService;
        }

        [HttpPost]
        public ActionResult RealizarRetiro(int idCuenta, decimal monto)
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
                    var saldo = _retiroService.RealizarRetiro(int.Parse(autenticar.Message), idCuenta, monto);

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
