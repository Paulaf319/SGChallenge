using SGChallengeApplication.Data.Dtos;
using SGChallengeApplication.Data.Models;

namespace SGChallengeApplication.Services.Interfaces
{
    public interface ICrearClienteService
    {

        OperationResult CrearCliente(ClienteCreateDTO cliente);
    }
}
