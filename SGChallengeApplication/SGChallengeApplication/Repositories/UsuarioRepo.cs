using SGChallengeApplication.Data.Models;
using SGChallengeApplication.Models;
using SGChallengeApplication.Repositories.Interfaces;

namespace SGChallengeApplication.Repositories
{
    public class UsuarioRepo : IUsuarioRepo
    {
        private readonly ChallengeSgContext _context;

        public UsuarioRepo(ChallengeSgContext context)
        {
            _context = context;
        }

        public Usuario? TraerUsuarioPorNombreUsuario(string nombreUsuario)
        {
            var usuario = (from u in _context.Usuarios

                           where u.NombreUsuario == nombreUsuario.ToUpper()

                           select new Usuario
                           {
                               Id = u.Id,
                               NombreUsuario = u.NombreUsuario,
                               Contrasenia = u.Contrasenia,
                               IdRol = u.IdRol,
                               FechaCreacion = u.FechaCreacion,
                               Activo = u.Activo,
                               FechaUltimaModif = u.FechaUltimaModif,
                               UsuarioCreacion = u.UsuarioCreacion,
                               UsuarioUltimaModif = u.UsuarioUltimaModif

                           }).FirstOrDefault();

            return usuario;
        }

        public Usuario? TraerUsuarioPorId(int idUsuario)
        {
            var usuario = (from u in _context.Usuarios

                           where u.Id == idUsuario

                           select new Usuario
                           {
                               Id = u.Id,
                               NombreUsuario = u.NombreUsuario,
                               Contrasenia = u.Contrasenia,
                               IdRol = u.IdRol,
                               FechaCreacion = u.FechaCreacion,
                               Activo = u.Activo,
                               FechaUltimaModif = u.FechaUltimaModif,
                               UsuarioCreacion = u.UsuarioCreacion,
                               UsuarioUltimaModif = u.UsuarioUltimaModif

                           }).FirstOrDefault();

            return usuario;
        }

        public IEnumerable<Usuario> TraerUsuarios()
        {
            var usuarios = (from u in _context.Usuarios

                           select new Usuario
                           {
                               Id = u.Id,
                               NombreUsuario = u.NombreUsuario,
                               Contrasenia = u.Contrasenia,
                               IdRol = u.IdRol,
                               FechaCreacion = u.FechaCreacion,
                               Activo = u.Activo,
                               FechaUltimaModif = u.FechaUltimaModif,
                               UsuarioCreacion = u.UsuarioCreacion,
                               UsuarioUltimaModif = u.UsuarioUltimaModif

                           }).ToList();

            return usuarios;
        }

        public void CrearUsuario(Usuario usuario)
        {
            if (usuario == null)
            {
                throw new ArgumentNullException(nameof(usuario));
            }
            else
            {
                _context.Usuarios.Add(usuario);
                _context.SaveChanges();
            }
        }
    }
}
