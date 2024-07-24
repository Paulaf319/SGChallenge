using SGChallengeApplication.Data.Models;

namespace SGChallengeApplication.Services.Interfaces
{
    public interface IRetiroService
    {
        OperationResult RealizarRetiro(int idCliente, int idCuenta, decimal monto);
    }
}
