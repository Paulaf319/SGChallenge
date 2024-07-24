using SGChallengeApplication.Data.Models;
using SGChallengeApplication.Models;
using SGChallengeApplication.Repositories.Interfaces;

namespace SGChallengeApplication.Repositories
{
    public class SucursalRepo : ISucursalRepo
    {
        private readonly ChallengeSgContext _context;

        public SucursalRepo(ChallengeSgContext context)
        {
            _context = context;
        }

        public Sucursal? TraerSucursalPorId(int idSucursal)
        {
            var sucursal = (from s in _context.Sucursals
                            join b in _context.Bancos on s.IdBanco equals b.Id
                            join l in _context.Localidads on s.IdLocalidad equals l.Id
                            join p in _context.Provincia on l.IdProvincia equals p.Id
                            join ps in _context.Pais on p.IdPais equals ps.Id

                            where s.Id == idSucursal

                            select new Sucursal
                            {
                                Id = s.Id,
                                Codigo = s.Codigo,
                                Descripcion = s.Descripcion,
                                IdBanco = s.IdBanco,
                                IdLocalidad = s.IdLocalidad,
                                Calle = s.Calle,
                                NroCalle = s.NroCalle

                            }).FirstOrDefault();

            return sucursal;
        }

        public IEnumerable<Sucursal> TraerSucursales()
        {
            var sucursales = (from s in _context.Sucursals
                              join b in _context.Bancos on s.IdBanco equals b.Id
                              join l in _context.Localidads on s.IdLocalidad equals l.Id
                              join p in _context.Provincia on l.IdProvincia equals p.Id
                              join ps in _context.Pais on p.IdPais equals ps.Id

                              select new Sucursal
                              {
                                  Id = s.Id,
                                  Codigo = s.Codigo,
                                  Descripcion = s.Descripcion,
                                  IdBanco = s.IdBanco,
                                  IdLocalidad = s.IdLocalidad,
                                  Calle = s.Calle,
                                  NroCalle = s.NroCalle

                              }).ToList();

            return sucursales;
        }

    }
}
