using SGChallengeApplication.Data.Dtos;
using SGChallengeApplication.Data.Models;

namespace SGChallengeApplication.Services.Interfaces
{
    public interface ICrearUsuarioService
    {
        OperationResult CrearUsuario(UsuarioCreateDTO usuario);
    }
}
