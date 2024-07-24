using SGChallengeApplication.Data.Dtos;
using SGChallengeApplication.Data.Models;
using SGChallengeApplication.Repositories.Interfaces;
using SGChallengeApplication.Services.Interfaces;

namespace SGChallengeApplication.Services
{
    public class CrearUsuarioService : ICrearUsuarioService
    {
        private readonly IUsuarioRepo _usuarioRepo;
        private readonly IUtilidadesRepo _utilidadesRepo;

        public CrearUsuarioService(IUtilidadesRepo utilidadesRepo, IUsuarioRepo usuarioRepo)
        {
            _utilidadesRepo = utilidadesRepo;
            _usuarioRepo = usuarioRepo;
        }

        public OperationResult CrearUsuario(UsuarioCreateDTO usuario)
        {
            OperationResult result = new OperationResult();

            if(_usuarioRepo.TraerUsuarioPorNombreUsuario(usuario.NombreUsuario) != null)
            {
                result.Success = false;
                result.Message = "Ya existe un usuario con ese nombre.";
            }
            else
            {
                _usuarioRepo.CrearUsuario(new Usuario
                {
                    NombreUsuario = usuario.NombreUsuario.ToUpper(),
                    Contrasenia = _utilidadesRepo.EncriptarSHA256(usuario.Contrasenia),
                    IdRol = 2,
                    Observacion = "",
                    Activo = true,
                    FechaCreacion = DateTime.Now,
                    FechaUltimaModif = DateTime.Now,
                    UsuarioCreacion = 1,
                    UsuarioUltimaModif = 1
                });

                result.Message = "Usuario creado exitosamente.";
                result.Success = true;
            }
            return result;
        }
    }
}
