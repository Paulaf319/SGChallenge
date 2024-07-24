using SGChallengeApplication.Data.Models;
using SGChallengeApplication.Models;
using SGChallengeApplication.Repositories.Interfaces;

namespace SGChallengeApplication.Repositories
{
    public class ClienteRepo : IClienteRepo
    {
        private readonly ChallengeSgContext _context;

        public ClienteRepo(ChallengeSgContext context)
        {
            _context = context;
        }

        public void CrearCliente(Cliente cliente)
        {
            if (cliente == null)
            {
                throw new ArgumentNullException(nameof(cliente));
            }
            else
            {
                _context.Clientes.Add(cliente);
                _context.SaveChanges();
            }
        }

        public Cliente? TraerClientePorIdUsuario(int idUsuario)
        {
            var cliente = (from cli in _context.Clientes
                           join td in _context.TipoDocumentos on cli.IdTipoDocumento equals td.Id
                           join l in _context.Localidads on cli.IdLocalidad equals l.Id
                           join p in _context.Provincia on l.IdProvincia equals p.Id
                           join ps in _context.Pais on p.IdPais equals ps.Id
                           join u in _context.Usuarios on cli.IdUsuario equals u.Id

                           where u.Id == idUsuario

                           select new Cliente
                           {
                               Id = cli.Id,
                               Nombre = cli.Nombre,
                               Apellido = cli.Apellido,
                               FechaNacimiento = cli.FechaNacimiento,
                               IdUsuario = cli.IdUsuario,
                               Mail = cli.Mail,
                               Cuit = cli.Cuit,
                               Cuil = cli.Cuil,
                               IdTipoDocumento = cli.IdTipoDocumento,
                               NroDocumento = cli.NroDocumento,
                               IdLocalidad = cli.IdLocalidad,
                               Calle = cli.Calle,
                               NroCalle = cli.NroCalle,
                               Departamento = cli.Departamento,
                               Piso = cli.Piso

                           }).FirstOrDefault();

            return cliente;
        }

        public Cliente? TraerClientePorId(int idCliente)
        {
            var cliente = (from cli in _context.Clientes
                           join td in _context.TipoDocumentos on cli.IdTipoDocumento equals td.Id
                           join l in _context.Localidads on cli.IdLocalidad equals l.Id
                           join p in _context.Provincia on l.IdProvincia equals p.Id
                           join ps in _context.Pais on p.IdPais equals ps.Id
                           join u in _context.Usuarios on cli.IdUsuario equals u.Id

                           where cli.Id == idCliente

                           select new Cliente
                           {
                               Id = cli.Id,
                               Nombre = cli.Nombre,
                               Apellido = cli.Apellido,
                               IdUsuario = cli.IdUsuario,
                               FechaNacimiento = cli.FechaNacimiento,
                               Mail = cli.Mail,
                               Cuit = cli.Cuit,
                               Cuil = cli.Cuil,
                               IdTipoDocumento = cli.IdTipoDocumento,
                               NroDocumento = cli.NroDocumento,
                               IdLocalidad = cli.IdLocalidad,
                               Calle = cli.Calle,
                               NroCalle = cli.NroCalle,
                               Departamento = cli.Departamento,
                               Piso = cli.Piso

                           }).FirstOrDefault();

            return cliente;
        }

        public IEnumerable<Cliente> TraerClientes()
        {
            var clientes = (from cli in _context.Clientes
                            join td in _context.TipoDocumentos on cli.IdTipoDocumento equals td.Id
                            join l in _context.Localidads on cli.IdLocalidad equals l.Id
                            join p in _context.Provincia on l.IdProvincia equals p.Id
                            join ps in _context.Pais on p.IdPais equals ps.Id

                            select new Cliente
                            {
                                Id = cli.Id,
                                Nombre = cli.Nombre,
                                Apellido = cli.Apellido,
                                FechaNacimiento = cli.FechaNacimiento,
                                Mail = cli.Mail,
                                Cuit = cli.Cuit,
                                Cuil = cli.Cuil,
                                IdTipoDocumento = cli.IdLocalidad,
                                NroDocumento = cli.NroDocumento,
                                IdLocalidad = cli.IdLocalidad,
                                Calle = cli.Calle,
                                NroCalle = cli.NroCalle,
                                Departamento = cli.Departamento,
                                Piso = cli.Piso

                            }).ToList();

            return clientes;
        }
    }
}
