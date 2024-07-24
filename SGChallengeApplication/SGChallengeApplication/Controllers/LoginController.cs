using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SGChallengeApplication.Data.Dtos;
using SGChallengeApplication.Services.Interfaces;

namespace SGChallengeApplication.Controllers
{
    [Route("api/[controller]/[action]")]
    [AllowAnonymous]
    [ApiController]
    public class LoginController : Controller
    {
        private readonly ILoginService _loginService;

        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpPost]
        public ActionResult Login(LoginDTO login)
        {
            var respuest = _loginService.Login(login);

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
