namespace SGChallengeApplication.Data.Dtos
{
    public class TipoDocumentoReadDto
    {
        public int Id { get; set; }

        public string TipoDoc { get; set; } = null!;

        public string? Descripcion { get; set; }

    }
}
