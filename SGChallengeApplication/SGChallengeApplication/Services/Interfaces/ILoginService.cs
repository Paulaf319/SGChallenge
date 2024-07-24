using SGChallengeApplication.Data.Dtos;
using SGChallengeApplication.Data.Models;

namespace SGChallengeApplication.Services.Interfaces
{
    public interface ILoginService
    {
        OperationResult Login(LoginDTO login);
    }
}
