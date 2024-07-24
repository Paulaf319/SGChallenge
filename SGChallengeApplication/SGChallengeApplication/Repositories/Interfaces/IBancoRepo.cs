using SGChallengeApplication.Data.Models;

namespace SGChallengeApplication.Repositories.Interfaces
{
    public interface IBancoRepo
    {

        Banco? TraerBancoPorId(int idBanco);

        IEnumerable<Banco> TraerBancos();

    }
}
