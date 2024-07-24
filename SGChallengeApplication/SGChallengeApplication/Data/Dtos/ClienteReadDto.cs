namespace SGChallengeApplication.Data.Dtos
{
    public class ClienteReadDto
    {
        public int Id { get; set; }

        public string Nombre { get; set; } = null!;

        public string Apellido { get; set; } = null!;

        public DateTime FechaNacimiento { get; set; }

        public virtual TipoDocumentoReadDto TipoDocumento { get; set; } = null!;

        public string NroDocumento { get; set; } = null!;

        public string? Cuit { get; set; }

        public string? Cuil { get; set; }

        public string? Mail { get; set; }

        public string? Calle { get; set; }

        public int? NroCalle { get; set; }

        public int? Piso { get; set; }

        public int? Departamento { get; set; }

        public virtual LocalidadReadDto Localidad { get; set; } = null!;

    }
}
