using System.ComponentModel.DataAnnotations;

namespace SGChallengeApplication.Data.Dtos
{
    public class LoginDTO
    {
        [Required]
        public string NombreUsuario { get; set; } = null!;
        [Required]
        public string Contrasenia { get; set; } = null!;
        [Required]
        public string Mail { get; set; } = null!;
    }
}
