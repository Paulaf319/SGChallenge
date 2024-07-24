using SGChallengeApplication.Data.Models;

namespace SGChallengeApplication.Services
{
    public interface IDepositoService
    {
        OperationResult RealizarDeposito(int idCliente, int idCuenta, decimal monto);
    }
}
