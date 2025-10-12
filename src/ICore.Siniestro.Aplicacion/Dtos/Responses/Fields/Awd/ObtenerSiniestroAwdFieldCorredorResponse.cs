using ICore.Siniestro.Aplicacion.Mapeadores;
using ICore.Siniestro.Dominio.Entidades.Awd;

namespace ICore.Siniestro.Aplicacion.Dtos.Responses.Fields.Awd
{
    /// <summary>
    /// Campo corredor para Response de obtener siniestro awd.
    /// </summary>
    public class ObtenerSiniestroAwdFieldCorredorResponse : IMapFrom<Corredor>
    {
        /// <summary>
        /// Id del corredor
        /// </summary>
        public string Id { get; set; } = default!;

        /// <summary>
        /// Nombre del corredor
        /// </summary>
        public string Nombre { get; set; } = default!;
    }
}
