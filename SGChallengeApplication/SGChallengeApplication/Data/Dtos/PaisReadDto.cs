﻿namespace SGChallengeApplication.Data.Dtos
{
    public class PaisReadDto
    {
        public int Id { get; set; }

        public string Codigo { get; set; } = null!;

        public string Nombre { get; set; } = null!;

        public string? Descripcion { get; set; }
    }
}
