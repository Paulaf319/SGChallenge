using SGChallengeApplication.Data.Dtos;
using SGChallengeApplication.Data.Models;
using SGChallengeApplication.Repositories.Interfaces;
using SGChallengeApplication.Services.Interfaces;

namespace SGChallengeApplication.Services
{
    public class CrearClienteService : ICrearClienteService
    {
        private readonly IClienteRepo _clienteRepo;
        private readonly IUsuarioRepo _usuarioRepo;

        public CrearClienteService(IClienteRepo clienteRepo, IUsuarioRepo usuarioRepo)
        {
            _clienteRepo = clienteRepo;
            _usuarioRepo = usuarioRepo;
        }

        public OperationResult CrearCliente(ClienteCreateDTO cliente)
        {
            OperationResult result = new OperationResult();

            var usuario = _usuarioRepo.TraerUsuarioPorId(cliente.IdUsuario);

            if (usuario == null)
            {
                result.Success = false;
                result.Message = "El usuario no existe.";
            }
            else
            {
                _clienteRepo.CrearCliente(new Cliente
                {
                    Nombre = cliente.Nombre,
                    Apellido = cliente.Apellido,
                    FechaNacimiento = cliente.FechaNacimiento,
                    IdUsuario = cliente.IdUsuario,
                    IdTipoDocumento = cliente.IdTipoDocumento,
                    NroDocumento = cliente.NroDocumento,
                    Cuit = cliente.Cuit,
                    Cuil = cliente.Cuil,
                    Mail = cliente.Mail,
                    Calle = cliente.Calle,
                    NroCalle = cliente.NroCalle,
                    Piso = cliente.Piso,
                    Departamento = cliente.Departamento,
                    IdLocalidad = cliente.IdLocalidad,
                    Observacion = "",
                    Activo = true,
                    FechaUltimaModif = DateTime.Now,
                    UsuarioUltimaModif = 1,
                    FechaCreacion = DateTime.Now,
                    UsuarioCreacion = 1
                });

                result.Message = "Cliente creado exitosamente.";
                result.Success = true;
            }

            return result;
        }
    }
}
