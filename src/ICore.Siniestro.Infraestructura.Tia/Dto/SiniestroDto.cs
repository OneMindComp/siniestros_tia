namespace ICore.Siniestro.Infraestructura.Tia.Dto
{
    public class SiniestroDto
    {
        public int NumeroSiniestro { get; set; } = default!;
        public string EstadoSiniestro { get; set; } = default!;
        public string CodigoEstado { get; set; } = default!;
        public string Ajustador { get; set; } = default!;
        public DateTime FechaPerdida { get; set; }
        public string LugarPerdida { get; set; } = default!;
        public string DescripcionPerdida { get; set; } = default!;
        public string CodigoCatastrofe { get; set; } = default!;
        public DateTime FechaReporteSiniestro { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string Moneda { get; set; } = default!;
        public int ReservaIndemnizacion { get; set; }
        public int ReservaHonorarios { get; set; }
        public int PorcentajeSeguidor { get; set; }
        public AfectadoDto Afectado { get; set; } = default!;
        public LiquidadorDto Liquidador { get; set; } = default!;
        public PolizaDto Poliza { get; set; } = default!;
    }
}
