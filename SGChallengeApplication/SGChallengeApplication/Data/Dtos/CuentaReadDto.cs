namespace SGChallengeApplication.Data.Dtos
{
    public class CuentaReadDto
    {
        public int Id { get; set; }

        public int NroCuenta { get; set; }

        public string Cbu { get; set; } = null!;

        public string? Alias { get; set; }

        public decimal Saldo { get; set; }

        public bool Activo { get; set; }

        public virtual ClienteReadDto Cliente { get; set; } = null!;

        public virtual MonedaReadDto Moneda { get; set; } = null!;

        public virtual SucursalReadDto Sucursal { get; set; } = null!;

        public virtual TipoCuentaReadDto TipoCuenta { get; set; } = null!;
    }
}
