using SGChallengeApplication.Data.Models;

namespace SGChallengeApplication.Repositories.Interfaces
{
    public interface ICuentaRepo
    {
        void CrearCuenta(Cuenta cuenta);

        Cuenta? TraerCuentaPorId(int id);

        IEnumerable<Cuenta> TraerCuentas();

        Cuenta? DepositarSaldo(int idCuenta, decimal monto);

        Cuenta? RetirarSaldo(int idCuenta, decimal monto);

    }
}
