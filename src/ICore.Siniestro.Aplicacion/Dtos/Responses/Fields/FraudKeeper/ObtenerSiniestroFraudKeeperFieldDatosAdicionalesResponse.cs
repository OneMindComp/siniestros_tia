using ICore.Siniestro.Aplicacion.Mapeadores;
using ICore.Siniestro.Dominio.Entidades.FraudKeeper;

namespace ICore.Siniestro.Aplicacion.Dtos.Responses.Fields.FraudKeeper
{
    /// <summary>
    /// Campo datos adicionales para Response de obtener siniestro fraudkeeper.
    /// </summary>
    public class ObtenerSiniestroFraudKeeperFieldDatosAdicionalesResponse : IMapFrom<DatosAdicionales>
    {
        /// <summary>
        /// Codigo del dato adicional.
        /// </summary>
        public string? Codigo { get; set; }

        /// <summary>
        /// Nombre del dato adicional.
        /// </summary>
        public string? Nombre { get; set; }

        /// <summary>
        /// Plugin utilizado.
        /// </summary>
        public string? Plugin { get; set; }

        /// <summary>
        /// Valor del dato adicional.
        /// </summary>
        public string? Valor { get; set; }

        /// <summary>
        /// Version del dato adicional.
        /// </summary>
        public int? Version { get; set; }

    }
}