using SGChallengeApplication.Data.Models;

namespace SGChallengeApplication.Repositories.Interfaces
{
    public interface IUsuarioRepo
    {
        void CrearUsuario(Usuario usuario);

        Usuario? TraerUsuarioPorNombreUsuario(string nombreUsuario);

        Usuario? TraerUsuarioPorId(int idUsuario);

        IEnumerable<Usuario> TraerUsuarios();
    }
}
