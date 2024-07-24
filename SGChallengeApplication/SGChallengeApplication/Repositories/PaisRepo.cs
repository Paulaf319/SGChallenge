using SGChallengeApplication.Data.Models;
using SGChallengeApplication.Models;
using SGChallengeApplication.Repositories.Interfaces;

namespace SGChallengeApplication.Repositories
{
    public class PaisRepo : IPaisRepo
    {
        private readonly ChallengeSgContext _context;

        public PaisRepo(ChallengeSgContext context)
        {
            _context = context;
        }

        public Pais? TraerPaisPorId(int idPais)
        {
            var pais = (from ps in _context.Pais

                        where ps.Id == idPais

                        select new Pais
                        {
                            Id = ps.Id,
                            Codigo = ps.Codigo,
                            Nombre = ps.Nombre,
                            Descripcion = ps.Descripcion,

                        }).FirstOrDefault();

            return pais;
        }

        public IEnumerable<Pais> TraerPaises()
        {
            var paises = (from ps in _context.Pais

                          select new Pais
                          {
                              Id = ps.Id,
                              Codigo = ps.Codigo,
                              Nombre = ps.Nombre,
                              Descripcion = ps.Descripcion,

                          }).ToList();

            return paises;
        }
    }
}
