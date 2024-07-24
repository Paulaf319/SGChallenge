using SGChallengeApplication.Data.Models;

namespace SGChallengeApplication.Repositories.Interfaces
{
    public interface IClienteRepo
    {
        void CrearCliente(Cliente cliente);

        Cliente? TraerClientePorIdUsuario(int idUsuario);

        Cliente? TraerClientePorId(int idCliente);

        IEnumerable<Cliente> TraerClientes();

    }
}
