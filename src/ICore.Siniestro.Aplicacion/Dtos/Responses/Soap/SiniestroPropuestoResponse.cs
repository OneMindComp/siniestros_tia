using ICore.Siniestro.Aplicacion.Mapeadores;
using ICore.Siniestro.Dominio.Entidades.Soap;

namespace ICore.Siniestro.Aplicacion.Dtos.Responses.Soap
{
    /// <summary>
    /// Response para el siniestro propuesto.
    /// </summary>
    public class SiniestroPropuestoResponse : IMapFrom<SiniestroPropuesto>
    {
        /// <summary>
        /// Respuesta.
        /// </summary>
        public long NumeroSiniestro { get; set; } = default!;
    }
}
