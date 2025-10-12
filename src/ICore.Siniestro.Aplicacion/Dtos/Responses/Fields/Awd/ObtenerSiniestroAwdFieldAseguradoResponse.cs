using ICore.Siniestro.Aplicacion.Mapeadores;
using ICore.Siniestro.Dominio.Entidades.Awd;

namespace ICore.Siniestro.Aplicacion.Dtos.Responses.Fields.Awd
{
    /// <summary>
    /// Campo asegurado para Response de obtener siniestro awd.
    /// </summary>
    public class ObtenerSiniestroAwdFieldAseguradoResponse : IMapFrom<Asegurado>
    {
        /// <summary>
        /// Rut del asegurado
        /// </summary>
        public string Rut { get; set; } = default!;

        /// <summary>
        /// Nombre del asegurado
        /// </summary>
        public string Nombre { get; set; } = default!;
    }
}
