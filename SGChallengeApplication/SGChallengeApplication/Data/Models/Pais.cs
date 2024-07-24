namespace SGChallengeApplication.Data.Models;

public partial class Pais
{
    public int Id { get; set; }

    public string Codigo { get; set; } = null!;

    public string Nombre { get; set; } = null!;

    public string? Descripcion { get; set; }

    public string? Observacion { get; set; }

    public bool Activo { get; set; }

    public DateTime FechaUltimaModif { get; set; }

    public int UsuarioUltimaModif { get; set; }

    public DateTime FechaCreacion { get; set; }

    public int UsuarioCreacion { get; set; }

    public virtual ICollection<MonedaPais> MonedaPais { get; set; } = new List<MonedaPais>();

    public virtual ICollection<Provincia> Provincia { get; set; } = new List<Provincia>();

    public virtual Usuario UsuarioCreacionNavigation { get; set; } = null!;

    public virtual Usuario UsuarioUltimaModifNavigation { get; set; } = null!;
}
