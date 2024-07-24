using SGChallengeApplication.Data.Dtos;
using System.Security.Claims;

namespace SGChallengeApplication.Repositories.Interfaces
{
    public interface IUtilidadesRepo
    {
        bool BuscarUsuario(LoginDTO login);

        string EncriptarSHA256(string texto);

        string GenerarJWT(LoginDTO login);

        LoginDTO? Autenticar(ClaimsIdentity claimsIdentity);
    }
}
