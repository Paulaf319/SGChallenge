using SGChallengeApplication.Data.Dtos;
using SGChallengeApplication.Data.Models;

namespace SGChallengeApplication.Services.Interfaces
{
    public interface ICrearCuentaService
    {
        OperationResult CrearCuenta(string idCliente, CuentaCreateDTO cuenta);
    }
}
