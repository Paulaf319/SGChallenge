using SGChallengeApplication.Data.Models;
using SGChallengeApplication.Models;
using SGChallengeApplication.Repositories.Interfaces;

namespace SGChallengeApplication.Repositories
{
    public class BancoRepo : IBancoRepo
    {
        private readonly ChallengeSgContext _context;

        public BancoRepo(ChallengeSgContext context)
        {
            _context = context;
        }

        public Banco? TraerBancoPorId(int idBanco)
        {
            var banco = (from b in _context.Bancos

                         where b.Id == idBanco

                         select new Banco
                         {
                             Id = b.Id,
                             Codigo = b.Codigo,
                             Nombre = b.Nombre,
                             Descripcion = b.Descripcion
                         }).FirstOrDefault();

            return banco;
        }

        public IEnumerable<Banco> TraerBancos()
        {
            var bancos = (from b in _context.Bancos

                          select new Banco
                          {
                              Id = b.Id,
                              Codigo = b.Codigo,
                              Nombre = b.Nombre,
                              Descripcion = b.Descripcion
                          }).ToList();

            return bancos;
        }
    }
}
