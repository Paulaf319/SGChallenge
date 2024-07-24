using SGChallengeApplication.Data.Models;

namespace SGChallengeApplication.Services.Interfaces
{
    public interface ISaldoService
    {
        OperationResult Consultar(int idCliente, int idCuenta);
    }
}
