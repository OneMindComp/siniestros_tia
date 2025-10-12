namespace ICore.Siniestro.Infraestructura.Tia.Dto
{
    public class PolizaDto
    {
        public string NumeroPoliza { get; set; } = default!;
        public int NumeroCertificado { get; set; }
        public string LineaNegocio { get; set; } = default!;
        public DateTime InicioVigencia { get; set; }
        public DateTime TerminoVigencia { get; set; }
        public string Ramo { get; set; } = default!;
        public AseguradoDto Asegurado { get; set; } = default!;
        public CorredorDto Corredor { get; set; } = default!;
    }
}
