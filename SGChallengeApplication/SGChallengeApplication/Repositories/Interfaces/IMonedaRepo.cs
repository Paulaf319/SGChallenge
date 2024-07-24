using SGChallengeApplication.Data.Models;

namespace SGChallengeApplication.Repositories.Interfaces
{
    public interface IMonedaRepo
    {

        Moneda? TraerMonedaPorId(int idMoneda);

        IEnumerable<Moneda> TraerMonedas();

    }
}
