namespace SGChallengeApplication.Data.Dtos
{
    public class MonedaPaisReadDto
    {
        public int Id { get; set; }

        public MonedaReadDto Moneda { get; set; } = null!;

        public PaisReadDto Pais { get; set; } = null!;

        public string? Descripcion { get; set; }
    }
}
