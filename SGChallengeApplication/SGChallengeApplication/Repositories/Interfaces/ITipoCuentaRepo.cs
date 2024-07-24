using SGChallengeApplication.Data.Models;

namespace SGChallengeApplication.Repositories.Interfaces
{
    public interface ITipoCuentaRepo
    {

        TipoCuenta? TraerTipoCuentaPorId(int idTipoCuenta);

        IEnumerable<TipoCuenta> TraerTipoCuentas();

    }
}
