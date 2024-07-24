using SGChallengeApplication.Data.Dtos;
using SGChallengeApplication.Data.Models;
using SGChallengeApplication.Repositories.Interfaces;
using SGChallengeApplication.Services.Interfaces;
using System.Security.Claims;

namespace SGChallengeApplication.Services
{
    public class AutenticarService : IAutenticarService
    {
        private readonly IUtilidadesRepo _utilidadesRepo;
        private readonly IUsuarioRepo _usuarioRepo;
        private readonly IClienteRepo _clienteRepo;

        public AutenticarService(IUtilidadesRepo utilidadesRepo, IUsuarioRepo usuarioRepo, IClienteRepo clienteRepo)
        {
            _utilidadesRepo = utilidadesRepo;
            _usuarioRepo = usuarioRepo;
            _clienteRepo = clienteRepo;
        }

        public OperationResult Autenticar(ClaimsIdentity claimsIdentity)
        {
            OperationResult result = new OperationResult();
            LoginDTO? loginDto = _utilidadesRepo.Autenticar(claimsIdentity);

            if (loginDto == null)
            {
                result.Success = false;
                result.Message = "Usuario no autorizado.";
            }
            else
            {
                var usuario = _usuarioRepo.TraerUsuarioPorNombreUsuario(loginDto.NombreUsuario);

                if (usuario == null)
                {
                    result.Success = false;
                    result.Message = "Usuario no encontrado.";
                }
                else
                {
                    var cliente = _clienteRepo.TraerClientePorIdUsuario(usuario.Id);

                    if (cliente == null)
                    {
                        result.Success = false;
                        result.Message = "Cliente no encontrado.";
                    }
                    else
                    {
                        if (cliente.Mail == loginDto.Mail &&
                            usuario.NombreUsuario == loginDto.NombreUsuario)
                        {
                            result.Success = true;
                            result.Message = cliente.Id.ToString();
                        }
                        else
                        {
                            result.Success = false;
                            result.Message = "Los datos no pudieron ser autenticado.";
                        }
                    }
                }
            }

            return result;
        }
    }
}
