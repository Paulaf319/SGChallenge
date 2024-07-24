using SGChallengeApplication.Data.Models;

namespace SGChallengeApplication.Repositories.Interfaces
{
    public interface IPaisRepo
    {

        Pais? TraerPaisPorId(int idPais);

        IEnumerable<Pais> TraerPaises();

    }
}
