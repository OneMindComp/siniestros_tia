using ICore.Siniestro.Aplicacion.Mapeadores;
using ICore.Siniestro.Dominio.Entidades.FraudKeeper;

namespace ICore.Siniestro.Aplicacion.Dtos.Responses.Fields.FraudKeeper
{
    /// <summary>
    /// Campo riesgo para Response de obtener siniestro fraudkeeper.
    /// </summary>
    public class ObtenerSiniestroFraudKeeperFieldRiesgoResponse : IMapFrom<Riesgo>
    {
        /// <summary>
        /// Numero de riesgo.
        /// </summary>
        public int? Numero { get; set; }

        /// <summary>
        /// Codigo de riesgo.
        /// </summary>
        public string? Codigo { get; set; }

        /// <summary>
        /// Descripcion del riesgo.
        /// </summary>
        public string? Descripcion { get; set; }

        /// <summary>
        /// Especificaciones del riesgo.
        /// </summary>
        public List<string>? Especificaciones { get; set; }
    }
}
