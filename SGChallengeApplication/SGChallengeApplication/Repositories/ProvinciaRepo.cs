using SGChallengeApplication.Data.Models;
using SGChallengeApplication.Models;
using SGChallengeApplication.Repositories.Interfaces;

namespace SGChallengeApplication.Repositories
{
    public class ProvinciaRepo : IProvinciaRepo
    {
        private readonly ChallengeSgContext _context;

        public ProvinciaRepo(ChallengeSgContext context)
        {
            _context = context;
        }

        public Provincia? TraerProvinciaPorId(int idProvincia)
        {
            var provincia = (from p in _context.Provincia
                             join ps in _context.Pais on p.IdPais equals ps.Id

                             where p.Id == idProvincia

                             select new Provincia
                             {
                                 Id = p.Id,
                                 Codigo = p.Codigo,
                                 Nombre = p.Nombre,
                                 Descripcion = p.Descripcion,
                                 IdPais = p.IdPais

                             }).FirstOrDefault();

            return provincia;
        }

        public IEnumerable<Provincia> TraerProvincias()
        {
            var provincias = (from p in _context.Provincia
                              join ps in _context.Pais on p.IdPais equals ps.Id

                              select new Provincia
                              {
                                  Id = p.Id,
                                  Codigo = p.Codigo,
                                  Nombre = p.Nombre,
                                  Descripcion = p.Descripcion,
                                  IdPais = p.IdPais

                              }).ToList();

            return provincias;
        }
    }
}
