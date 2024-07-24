namespace SGChallengeApplication.Data.Dtos
{
    public class TipoCuentaReadDto
    {
        public int Id { get; set; }

        public string Codigo { get; set; } = null!;

        public string Nombre { get; set; } = null!;

        public string? Descripcion { get; set; }
    }
}
