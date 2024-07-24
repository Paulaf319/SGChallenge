namespace SGChallengeApplication.Data.Dtos
{
    public class SucursalReadDto
    {
        public int Id { get; set; }

        public string Codigo { get; set; } = null!;

        public virtual BancoReadDto Banco { get; set; } = null!;

        public virtual LocalidadReadDto Localidad { get; set; } = null!;

        public string? Calle { get; set; }

        public int? NroCalle { get; set; }

        public string? Descripcion { get; set; }

        public virtual ICollection<CuentaReadDto> Cuenta { get; set; } = new List<CuentaReadDto>();

    }
}
