using SGChallengeApplication.Data.Models;

namespace SGChallengeApplication.Repositories.Interfaces
{
    public interface ILocalidadRepo
    {

        Localidad? TraerLocalidadPorId(int idLocalidad);

        IEnumerable<Localidad> TraerLocalidades();

    }
}
