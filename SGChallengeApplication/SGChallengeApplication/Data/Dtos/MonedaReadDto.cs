namespace SGChallengeApplication.Data.Dtos
{
    public class MonedaReadDto
    {

        public int Id { get; set; }

        public string Codigo { get; set; } = null!;

        public string Nombre { get; set; } = null!;

        public string? Descripcion { get; set; }

        public string? Observacion { get; set; }

        public bool Activo { get; set; }

    }
}
