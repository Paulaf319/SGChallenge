using SGChallengeApplication.Data.Dtos;
using SGChallengeApplication.Data.Models;
using SGChallengeApplication.Repositories.Interfaces;
using SGChallengeApplication.Services.Interfaces;

namespace SGChallengeApplication.Services
{
    public class LoginService : ILoginService
    {
        private readonly IUtilidadesRepo _utilidadesRepo;

        public LoginService(IUtilidadesRepo utilidadesRepo)
        {
            _utilidadesRepo = utilidadesRepo;
        }

        public OperationResult Login(LoginDTO login)
        {
            OperationResult result = new OperationResult();

            if (!_utilidadesRepo.BuscarUsuario(login))
            {
                result.Success = false;
                result.Message = "El usuario no existe.";
            }
            else
            {
                result.Success = true;
                result.Message = _utilidadesRepo.GenerarJWT(login);
            }

            return result;
        }
    }
}
