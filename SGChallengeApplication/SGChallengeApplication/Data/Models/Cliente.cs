namespace SGChallengeApplication.Data.Models;

public partial class Cliente
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Apellido { get; set; } = null!;

    public DateTime FechaNacimiento { get; set; }

    public int IdUsuario { get; set; }

    public int IdTipoDocumento { get; set; }

    public string NroDocumento { get; set; } = null!;

    public string? Cuit { get; set; }

    public string? Cuil { get; set; }

    public string? Mail { get; set; }

    public string? Calle { get; set; }

    public int? NroCalle { get; set; }

    public int? Piso { get; set; }

    public int? Departamento { get; set; }

    public int IdLocalidad { get; set; }

    public string? Observacion { get; set; }

    public bool Activo { get; set; }

    public DateTime FechaUltimaModif { get; set; }

    public int UsuarioUltimaModif { get; set; }

    public DateTime FechaCreacion { get; set; }

    public int UsuarioCreacion { get; set; }

    public virtual ICollection<Cuenta> Cuenta { get; set; } = new List<Cuenta>();

    public virtual Localidad IdLocalidadNavigation { get; set; } = null!;

    public virtual TipoDocumento IdTipoDocumentoNavigation { get; set; } = null!;

    public virtual Usuario IdUsuarioNavigation { get; set; } = null!;

    public virtual Usuario UsuarioCreacionNavigation { get; set; } = null!;

    public virtual Usuario UsuarioUltimaModifNavigation { get; set; } = null!;
}
