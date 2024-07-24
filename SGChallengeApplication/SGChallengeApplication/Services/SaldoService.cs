using Microsoft.AspNetCore.Mvc;
using SGChallengeApplication.Data.Models;
using SGChallengeApplication.Repositories.Interfaces;
using SGChallengeApplication.Services.Interfaces;

namespace SGChallengeApplication.Services
{
    public class SaldoService : ISaldoService
    {
        private readonly ICuentaRepo _cuentaRepo;

        public SaldoService(ICuentaRepo cuentaRepo)
        {
            _cuentaRepo = cuentaRepo;
        }

        [HttpGet]
        public OperationResult Consultar(int idCliente,int idCuenta)
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
                    result.Success = true;
                    result.Message = cuenta.Saldo.ToString();
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
