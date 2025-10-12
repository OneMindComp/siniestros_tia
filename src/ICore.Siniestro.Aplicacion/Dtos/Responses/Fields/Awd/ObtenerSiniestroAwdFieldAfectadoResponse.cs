using ICore.Siniestro.Aplicacion.Mapeadores;
using ICore.Siniestro.Dominio.Entidades.Awd;

namespace ICore.Siniestro.Aplicacion.Dtos.Responses.Fields.Awd
{
    /// <summary>
    /// Campo afectado para Response de obtener siniestro awd.
    /// </summary>
    public class ObtenerSiniestroAwdAfectadoFieldResponse : IMapFrom<Afectado>
    {
        /// <summary>
        /// Rut del afectado
        /// </summary>
        public string Rut { get; set; } = default!;

        /// <summary>
        /// Nombre del afectado
        /// </summary>
        public string Nombre { get; set; } = default!;
    }
}
