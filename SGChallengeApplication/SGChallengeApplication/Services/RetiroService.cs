using SGChallengeApplication.Data.Models;
using SGChallengeApplication.Repositories.Interfaces;
using SGChallengeApplication.Services.Interfaces;

namespace SGChallengeApplication.Services
{
    public class RetiroService : IRetiroService
    {
        private readonly ICuentaRepo _cuentaRepo;

        public RetiroService(ICuentaRepo cuentaRepo)
        {
            _cuentaRepo = cuentaRepo;
        }

        public OperationResult RealizarRetiro(int idCliente, int idCuenta, decimal monto)
        {
            OperationResult result = new OperationResult();

            var cuenta = _cuentaRepo.TraerCuentaPorId(idCuenta);

            if (cuenta == null)
            {
                result.Success = false;
                result.Message = "La cuenta no existe";
            }
            else
            {
                if (cuenta.IdCliente == idCliente)
                {
                    if (_cuentaRepo.RetirarSaldo(idCuenta, monto) != null)
                    {
                        result.Success = true;
                        result.Message = "Retiro realizado exitosamente.";
                        return result;
                    }
                    else
                    {
                        result.Success = false;
                        result.Message = "No se pudo realizar el retiro.";
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
