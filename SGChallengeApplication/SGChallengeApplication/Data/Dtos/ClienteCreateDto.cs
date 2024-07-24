using System.ComponentModel.DataAnnotations;

namespace SGChallengeApplication.Data.Dtos
{
    public class ClienteCreateDTO
    {
        [Required]
        public string Nombre { get; set; } = null!;
        [Required]
        public string Apellido { get; set; } = null!;
        [Required]
        public DateTime FechaNacimiento { get; set; }
        [Required]
        public int IdUsuario { get; set; }
        [Required]
        public int IdTipoDocumento { get; set; }
        [Required]
        public string NroDocumento { get; set; } = null!;

        public string? Cuit { get; set; }

        public string? Cuil { get; set; }

        public string? Mail { get; set; }

        public string? Calle { get; set; }

        public int? NroCalle { get; set; }

        public int? Piso { get; set; }

        public int? Departamento { get; set; }
        [Required]
        public int IdLocalidad { get; set; }


    }
}
