using ICore.Siniestro.Aplicacion.Dtos.Responses.Fields.Awd;
using ICore.Siniestro.Aplicacion.Mapeadores;

namespace ICore.Siniestro.Aplicacion.Dtos.Responses
{
    /// <summary>
    /// Response del siniestro Awd.
    /// </summary>
    public class ObtenerSiniestroAwdResponse : IMapFrom<Dominio.Entidades.Siniestro>
    {
        /// <summary>
        /// Numero de siniestro.
        /// </summary>
        public int NumeroSiniestro { get; set; } = default!;
        /// <summary>
        /// Estado de siniestro.
        /// </summary>
        public string EstadoSiniestro { get; set; } = default!;
        /// <summary>
        /// Codigo de estado.
        /// </summary>
        public string CodigoEstado { get; set; } = default!;
        /// <summary>
        /// Nombre ajustador.
        /// </summary>
        public string Ajustador { get; set; } = default!;
        /// <summary>
        /// Fecha de perdida.
        /// </summary>
        public DateTime FechaPerdida { get; set; }
        /// <summary>
        /// Lugar de perdida.
        /// </summary>
        public string LugarPerdida { get; set; } = default!;
        /// <summary>
        /// descripcion de la perdida.
        /// </summary>
        public string DescripcionPerdida { get; set; } = default!;
        /// <summary>
        /// Codigo de catastrofe.
        /// </summary>
        public string CodigoCatastrofe { get; set; } = default!;
        /// <summary>
        /// Fecha reporte de siniestr´.
        /// </summary>
        public DateTime FechaReporteSiniestro { get; set; }
        /// <summary>
        /// Fecha creacion.
        /// </summary>
        public DateTime FechaCreacion { get; set; }
        /// <summary>
        /// Tipo moneda.
        /// </summary>
        public string Moneda { get; set; } = default!;
        /// <summary>
        /// Reserva de indemnizacion.
        /// </summary>
        public int ReservaIndemnizacion { get; set; }
        /// <summary>
        /// Reserva de honorarios.
        /// </summary>
        public int ReservaHonorarios { get; set; }
        /// <summary>
        /// Porcentaje seguidor.
        /// </summary>
        public int PorcentajeSeguidor { get; set; }
        /// <summary>
        /// Afectado.
        /// </summary>
        public ObtenerSiniestroAwdAfectadoFieldResponse Afectado { get; set; } = default!;
        /// <summary>
        /// Liquidador.
        /// </summary>
        public ObtenerSiniestroAwdLiquidadorFieldResponse Liquidador { get; set; } = default!;
        /// <summary>
        /// Poliza.
        /// </summary>
        public ObtenerSiniestroAwdFieldPolizaResponse Poliza { get; set; } = default!;
    }
}
