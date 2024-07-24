using SGChallengeApplication.Data.Models;

namespace SGChallengeApplication.Repositories.Interfaces
{
    public interface IProvinciaRepo
    {

        Provincia? TraerProvinciaPorId(int idProvincia);

        IEnumerable<Provincia> TraerProvincias();

    }
}
