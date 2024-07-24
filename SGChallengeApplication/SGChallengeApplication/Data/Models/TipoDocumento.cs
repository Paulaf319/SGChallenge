namespace SGChallengeApplication.Data.Models;

public partial class TipoDocumento
{
    public int Id { get; set; }

    public string TipoDocumento1 { get; set; } = null!;

    public string? Descripcion { get; set; }

    public string? Observacion { get; set; }

    public bool Activo { get; set; }

    public DateTime FechaUltimaModif { get; set; }

    public int UsuarioUltimaModif { get; set; }

    public DateTime FechaCreacion { get; set; }

    public int UsuarioCreacion { get; set; }

    public virtual ICollection<Cliente> Clientes { get; set; } = new List<Cliente>();

    public virtual Usuario UsuarioCreacionNavigation { get; set; } = null!;

    public virtual Usuario UsuarioUltimaModifNavigation { get; set; } = null!;
}
