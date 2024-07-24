namespace SGChallengeApplication.Data.Models;

public partial class MonedaPais
{
    public int Id { get; set; }

    public int IdMoneda { get; set; }

    public int IdPais { get; set; }

    public string? Descripcion { get; set; }

    public string? Observacion { get; set; }

    public bool Activo { get; set; }

    public DateTime FechaUltimaModif { get; set; }

    public int UsuarioUltimaModif { get; set; }

    public DateTime FechaCreacion { get; set; }

    public int UsuarioCreacion { get; set; }

    public virtual Moneda IdMonedaNavigation { get; set; } = null!;

    public virtual Pais IdPaisNavigation { get; set; } = null!;

    public virtual Usuario UsuarioCreacionNavigation { get; set; } = null!;

    public virtual Usuario UsuarioUltimaModifNavigation { get; set; } = null!;
}
