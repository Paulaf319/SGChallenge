namespace SGChallengeApplication.Data.Dtos
{
    public class UsuarioReadDto
    {
        public int Id { get; set; }

        public RolReadDto Rol { get; set; } = null!;

        public string NombreUsuario { get; set; } = null!;

        public string Contrasenia { get; set; } = null!;
    }
}
