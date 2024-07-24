using SGChallengeApplication.Data.Models;
using SGChallengeApplication.Models;
using SGChallengeApplication.Repositories.Interfaces;

namespace SGChallengeApplication.Repositories
{
    public class LocalidadRepo : ILocalidadRepo
    {
        private readonly ChallengeSgContext _context;

        public LocalidadRepo(ChallengeSgContext context)
        {
            _context = context;
        }

        public Localidad? TraerLocalidadPorId(int idLocalidad)
        {
            var localidad = (from l in _context.Localidads
                             join p in _context.Provincia on l.IdProvincia equals p.Id
                             join ps in _context.Pais on p.IdPais equals ps.Id

                             where l.Id == idLocalidad

                             select new Localidad
                             {
                                 Id = l.Id,
                                 Codigo = l.Codigo,
                                 Nombre = l.Nombre,
                                 Descripcion = l.Descripcion,
                                 IdProvincia = l.IdProvincia

                             }).FirstOrDefault();

            return localidad;
        }

        public IEnumerable<Localidad> TraerLocalidades()
        {
            var localidades = (from l in _context.Localidads
                               join p in _context.Provincia on l.IdProvincia equals p.Id
                               join ps in _context.Pais on p.IdPais equals ps.Id

                               select new Localidad
                               {
                                   Id = l.Id,
                                   Codigo = l.Codigo,
                                   Nombre = l.Nombre,
                                   Descripcion = l.Descripcion,
                                   IdProvincia = l.IdProvincia

                               }).ToList();

            return localidades;
        }

    }
}
