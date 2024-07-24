using System.ComponentModel.DataAnnotations;

namespace SGChallengeApplication.Data.Dtos
{
    public class UsuarioCreateDTO
    {
        [Required]
        public string NombreUsuario { get; set; } = null!;
        [Required]
        public string Contrasenia { get; set; } = null!;

    }
}
