namespace SGChallengeApplication.Data.Models;

public partial class Cuenta
{
    public int Id { get; set; }

    public int IdCliente { get; set; }

    public int IdSucursal { get; set; }

    public int IdTipoCuenta { get; set; }

    public int IdMoneda { get; set; }

    public int NroCuenta { get; set; }

    public string Cbu { get; set; } = null!;

    public string? Alias { get; set; }

    public decimal Saldo { get; set; }

    public string? Observacion { get; set; }

    public bool Activo { get; set; }

    public DateTime FechaUltimaModif { get; set; }

    public int UsuarioUltimaModif { get; set; }

    public DateTime FechaCreacion { get; set; }

    public int UsuarioCreacion { get; set; }

    public virtual Cliente IdClienteNavigation { get; set; } = null!;

    public virtual Moneda IdMonedaNavigation { get; set; } = null!;

    public virtual Sucursal IdSucursalNavigation { get; set; } = null!;

    public virtual TipoCuenta IdTipoCuentaNavigation { get; set; } = null!;

    public virtual Usuario UsuarioCreacionNavigation { get; set; } = null!;

    public virtual Usuario UsuarioUltimaModifNavigation { get; set; } = null!;
}
