using SGChallengeApplication.Data.Models;

namespace SGChallengeApplication.Repositories.Interfaces
{
    public interface ITipoDocumentoRepo
    {

        TipoDocumento? TraerTipoDocumentoPorId(int idTipoDoc);

        IEnumerable<TipoDocumento> TraerTipoDocumentos();

    }
}
