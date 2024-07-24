using SGChallengeApplication.Data.Models;
using System.Security.Claims;

namespace SGChallengeApplication.Services.Interfaces
{
    public interface IAutenticarService
    {
        OperationResult Autenticar(ClaimsIdentity claimsIdentity);
    }
}
