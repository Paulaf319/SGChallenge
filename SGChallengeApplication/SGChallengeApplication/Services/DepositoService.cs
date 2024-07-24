using SGChallengeApplication.Data.Models;
using SGChallengeApplication.Repositories.Interfaces;

namespace SGChallengeApplication.Services
{
    public class DepositoService : IDepositoService
    {
        private readonly ICuentaRepo _cuentaRepo;

        public DepositoService(ICuentaRepo cuentaRepo)
        {
            _cuentaRepo = cuentaRepo;
        }

        public OperationResult RealizarDeposito(int idCliente, int idCuenta, decimal monto)
        {
            OperationResult result = new OperationResult();

            var cuenta = _cuentaRepo.TraerCuentaPorId(idCuenta);

            if (cuenta == null)
            {
                result.Success = false;
                result.Message = "La cuenta no existe.";
            }
            else
            {
                if (cuenta.IdCliente == idCliente)
                {
                    if (_cuentaRepo.DepositarSaldo(idCuenta, monto) != null)
                    {
                        result.Success = true;
                        result.Message = "Deposito realizado exitosamente.";
                        return result;
                    }
                    else
                    {
                        result.Success = false;
                        result.Message = "El deposito no se pudo procesar.";
                    }
                }
                else
                {
                    result.Success = false;
                    result.Message = "No tiene acceso a esta cuenta.";
                }
            }

            return result;
        }







    }
}
