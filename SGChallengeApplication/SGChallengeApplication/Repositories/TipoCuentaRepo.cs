using SGChallengeApplication.Data.Models;
using SGChallengeApplication.Models;
using SGChallengeApplication.Repositories.Interfaces;

namespace SGChallengeApplication.Repositories
{
    public class TipoCuentaRepo : ITipoCuentaRepo
    {
        private readonly ChallengeSgContext _context;

        public TipoCuentaRepo(ChallengeSgContext context)
        {
            _context = context;
        }

        public TipoCuenta? TraerTipoCuentaPorId(int idTipoCuenta)
        {
            var tipoCuenta = (from tc in _context.TipoCuenta

                              where tc.Id == idTipoCuenta

                              select new TipoCuenta
                              {
                                  Id = tc.Id,
                                  Codigo = tc.Codigo,
                                  Nombre = tc.Nombre

                              }).FirstOrDefault();

            return tipoCuenta;
        }

        public IEnumerable<TipoCuenta> TraerTipoCuentas()
        {
            var tipoCuentas = (from tc in _context.TipoCuenta

                               select new TipoCuenta
                               {
                                   Id = tc.Id,
                                   Codigo = tc.Codigo,
                                   Nombre = tc.Nombre

                               }).ToList();

            return tipoCuentas;
        }
    }
}
