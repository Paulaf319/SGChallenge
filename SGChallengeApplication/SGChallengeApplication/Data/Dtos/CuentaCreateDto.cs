using System.ComponentModel.DataAnnotations;

namespace SGChallengeApplication.Data.Dtos
{
    public class CuentaCreateDTO
    {
        public int NroCuenta { get; set; }

        public string Cbu { get; set; } = null!;

        public string? Alias { get; set; }

        public decimal Saldo { get; set; }

        public string? Observacion { get; set; }
        [Required]
        public int IdCliente { get; set; }
        [Required]
        public int IdSucursal { get; set; }
        [Required]
        public int IdTipoCuenta { get; set; }
        [Required]
        public int IdMoneda { get; set; }
    }
}
