using SGChallengeApplication.Data.Models;
using SGChallengeApplication.Models;
using SGChallengeApplication.Repositories.Interfaces;

namespace SGChallengeApplication.Repositories
{
    public class TipoDocumentoRepo : ITipoDocumentoRepo
    {
        private readonly ChallengeSgContext _context;

        public TipoDocumentoRepo(ChallengeSgContext context)
        {
            _context = context;
        }

        public TipoDocumento? TraerTipoDocumentoPorId(int idTipoDoc)
        {
            var tipoDocumento = (from td in _context.TipoDocumentos

                                 where td.Id == idTipoDoc

                                 select new TipoDocumento
                                 {
                                     Id = td.Id,
                                     TipoDocumento1 = td.TipoDocumento1,
                                     Descripcion = td.Descripcion

                                 }).FirstOrDefault();

            return tipoDocumento;
        }

        public IEnumerable<TipoDocumento> TraerTipoDocumentos()
        {
            var tipoDocumentos = (from td in _context.TipoDocumentos

                                  select new TipoDocumento
                                  {
                                      Id = td.Id,
                                      TipoDocumento1 = td.TipoDocumento1,
                                      Descripcion = td.Descripcion

                                  }).ToList();

            return tipoDocumentos;
        }
    }
}
