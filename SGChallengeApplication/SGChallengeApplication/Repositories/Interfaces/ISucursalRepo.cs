using SGChallengeApplication.Data.Models;

namespace SGChallengeApplication.Repositories.Interfaces
{
    public interface ISucursalRepo
    {

        Sucursal? TraerSucursalPorId(int idSucursal);

        IEnumerable<Sucursal> TraerSucursales();

    }
}
