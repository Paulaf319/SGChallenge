using SGChallengeApplication.Data.Models;
using SGChallengeApplication.Models;
using SGChallengeApplication.Repositories.Interfaces;

namespace SGChallengeApplication.Repositories
{
    public class MonedaRepo : IMonedaRepo
    {
        private readonly ChallengeSgContext _context;

        public MonedaRepo(ChallengeSgContext context)
        {
            _context = context;
        }

        public Moneda? TraerMonedaPorId(int idMoneda)
        {
            var moneda = (from m in _context.Moneda

                          where m.Id == idMoneda

                          select new Moneda
                          {
                              Id = m.Id,
                              Codigo = m.Codigo,
                              Nombre = m.Nombre

                          }).FirstOrDefault();

            return moneda;
        }

        public IEnumerable<Moneda> TraerMonedas()
        {
            var monedas = (from m in _context.Moneda

                           select new Moneda
                           {
                               Id = m.Id,
                               Codigo = m.Codigo,
                               Nombre = m.Nombre

                           }).ToList();

            return monedas;
        }
    }
}
