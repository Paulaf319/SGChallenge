namespace SGChallengeApplication.Data.Models;

public partial class Usuario
{
    public int Id { get; set; }

    public int IdRol { get; set; }

    public string NombreUsuario { get; set; } = null!;

    public string Contrasenia { get; set; } = null!;

    public string? Observacion { get; set; }

    public bool Activo { get; set; }

    public DateTime FechaUltimaModif { get; set; }

    public int UsuarioUltimaModif { get; set; }

    public DateTime FechaCreacion { get; set; }

    public int UsuarioCreacion { get; set; }

    public virtual ICollection<Banco> BancoUsuarioCreacionNavigations { get; set; } = new List<Banco>();

    public virtual ICollection<Banco> BancoUsuarioUltimaModifNavigations { get; set; } = new List<Banco>();

    public virtual ICollection<Cliente> ClienteIdUsuarioNavigations { get; set; } = new List<Cliente>();

    public virtual ICollection<Cliente> ClienteUsuarioCreacionNavigations { get; set; } = new List<Cliente>();

    public virtual ICollection<Cliente> ClienteUsuarioUltimaModifNavigations { get; set; } = new List<Cliente>();

    public virtual ICollection<Cuenta> CuentumUsuarioCreacionNavigations { get; set; } = new List<Cuenta>();

    public virtual ICollection<Cuenta> CuentumUsuarioUltimaModifNavigations { get; set; } = new List<Cuenta>();

    public virtual Rol IdRolNavigation { get; set; } = null!;

    public virtual ICollection<Usuario> InverseUsuarioCreacionNavigation { get; set; } = new List<Usuario>();

    public virtual ICollection<Usuario> InverseUsuarioUltimaModifNavigation { get; set; } = new List<Usuario>();

    public virtual ICollection<Localidad> LocalidadUsuarioCreacionNavigations { get; set; } = new List<Localidad>();

    public virtual ICollection<Localidad> LocalidadUsuarioUltimaModifNavigations { get; set; } = new List<Localidad>();

    public virtual ICollection<MonedaPais> MonedaPaiUsuarioCreacionNavigations { get; set; } = new List<MonedaPais>();

    public virtual ICollection<MonedaPais> MonedaPaiUsuarioUltimaModifNavigations { get; set; } = new List<MonedaPais>();

    public virtual ICollection<Moneda> MonedumUsuarioCreacionNavigations { get; set; } = new List<Moneda>();

    public virtual ICollection<Moneda> MonedumUsuarioUltimaModifNavigations { get; set; } = new List<Moneda>();

    public virtual ICollection<Pais> PaiUsuarioCreacionNavigations { get; set; } = new List<Pais>();

    public virtual ICollection<Pais> PaiUsuarioUltimaModifNavigations { get; set; } = new List<Pais>();

    public virtual ICollection<Provincia> ProvinciumUsuarioCreacionNavigations { get; set; } = new List<Provincia>();

    public virtual ICollection<Provincia> ProvinciumUsuarioUltimaModifNavigations { get; set; } = new List<Provincia>();

    public virtual ICollection<Rol> RolUsuarioCreacionNavigations { get; set; } = new List<Rol>();

    public virtual ICollection<Rol> RolUsuarioUltimaModifNavigations { get; set; } = new List<Rol>();

    public virtual ICollection<Sucursal> SucursalUsuarioCreacionNavigations { get; set; } = new List<Sucursal>();

    public virtual ICollection<Sucursal> SucursalUsuarioUltimaModifNavigations { get; set; } = new List<Sucursal>();

    public virtual ICollection<TipoCuenta> TipoCuentumUsuarioCreacionNavigations { get; set; } = new List<TipoCuenta>();

    public virtual ICollection<TipoCuenta> TipoCuentumUsuarioUltimaModifNavigations { get; set; } = new List<TipoCuenta>();

    public virtual ICollection<TipoDocumento> TipoDocumentoUsuarioCreacionNavigations { get; set; } = new List<TipoDocumento>();

    public virtual ICollection<TipoDocumento> TipoDocumentoUsuarioUltimaModifNavigations { get; set; } = new List<TipoDocumento>();

    public virtual Usuario UsuarioCreacionNavigation { get; set; } = null!;

    public virtual Usuario UsuarioUltimaModifNavigation { get; set; } = null!;
}
