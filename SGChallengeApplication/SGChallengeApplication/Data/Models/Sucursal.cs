namespace SGChallengeApplication.Data.Models;

public partial class Sucursal
{
    public int Id { get; set; }

    public string Codigo { get; set; } = null!;

    public int IdBanco { get; set; }

    public int IdLocalidad { get; set; }

    public string? Calle { get; set; }

    public int? NroCalle { get; set; }

    public string? Descripcion { get; set; }

    public string? Observacion { get; set; }

    public bool Activo { get; set; }

    public DateTime FechaUltimaModif { get; set; }

    public int UsuarioUltimaModif { get; set; }

    public DateTime FechaCreacion { get; set; }

    public int UsuarioCreacion { get; set; }

    public virtual ICollection<Cuenta> Cuenta { get; set; } = new List<Cuenta>();

    public virtual Banco IdBancoNavigation { get; set; } = null!;

    public virtual Localidad IdLocalidadNavigation { get; set; } = null!;

    public virtual Usuario UsuarioCreacionNavigation { get; set; } = null!;

    public virtual Usuario UsuarioUltimaModifNavigation { get; set; } = null!;
}
