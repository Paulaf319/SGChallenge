using SGChallengeApplication.Data.Dtos;
using SGChallengeApplication.Data.Models;
using SGChallengeApplication.Repositories.Interfaces;
using SGChallengeApplication.Services.Interfaces;

namespace SGChallengeApplication.Services
{
    public class CrearCuentaService : ICrearCuentaService
    {
        private readonly ICuentaRepo _cuentaRepo;
        private readonly IClienteRepo _clienteRepo;
        private readonly ISucursalRepo _sucursalRepo;
        private readonly ITipoCuentaRepo _tipoCuentaRepo;
        private readonly IMonedaRepo _monedaRepo;

        public CrearCuentaService(ICuentaRepo cuentaRepo, IClienteRepo clienteRepo, ISucursalRepo sucursalRepo, ITipoCuentaRepo tipoCuentaRepo, IMonedaRepo monedaRepo)
        {
            _cuentaRepo = cuentaRepo;
            _clienteRepo = clienteRepo;
            _sucursalRepo = sucursalRepo;
            _tipoCuentaRepo = tipoCuentaRepo;
            _monedaRepo = monedaRepo;
        }

        public OperationResult CrearCuenta(string idCliente, CuentaCreateDTO cuenta)
        {
            OperationResult result = new OperationResult();

            if (cuenta.IdCliente.ToString() != idCliente)
            {
                result.Success = false;
                result.Message = "No tiene acceso a esta cuenta.";
            }
            else
            {
                if (_clienteRepo.TraerClientePorId(cuenta.IdCliente) != null)
                {
                    if (_sucursalRepo.TraerSucursalPorId(cuenta.IdSucursal) != null)
                    {
                        if (_tipoCuentaRepo.TraerTipoCuentaPorId(cuenta.IdTipoCuenta) != null)
                        {
                            if (_monedaRepo.TraerMonedaPorId(cuenta.IdMoneda) != null)
                            {
                                _cuentaRepo.CrearCuenta(new Cuenta
                                {
                                    IdCliente = cuenta.IdCliente,
                                    IdSucursal = cuenta.IdSucursal,
                                    IdTipoCuenta = cuenta.IdTipoCuenta,
                                    IdMoneda = cuenta.IdMoneda,
                                    NroCuenta = cuenta.NroCuenta,
                                    Cbu = cuenta.Cbu,
                                    Alias = cuenta.Alias,
                                    Saldo = cuenta.Saldo,
                                    Observacion = "",
                                    Activo = true,
                                    FechaUltimaModif = DateTime.Now,
                                    UsuarioUltimaModif = 1,
                                    FechaCreacion = DateTime.Now,
                                    UsuarioCreacion = 1

                                });
                                result.Message = "Cuenta creada exitosamente.";
                                result.Success = true;

                                return result;
                            }
                            result.Message = "La moneda no es correcta";
                            result.Success = false;

                            return result;
                        }
                        result.Message = "Tipo de cuenta no es correcto";
                        result.Success = false;

                        return result;
                    }
                    result.Message = "La sucursal no existe";
                    result.Success = false;

                    return result;
                }
                result.Message = "El cliente no existe";
                result.Success = false;
            }

            return result;
        }

        


    }
}
