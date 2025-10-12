using ICore.Siniestro.Aplicacion.Mapeadores;
using ICore.Siniestro.Dominio.Entidades.Awd;

namespace ICore.Siniestro.Aplicacion.Dtos.Responses.Fields.Awd
{
    /// <summary>
    /// Campo liquidador para Response de obtener siniestro awd.
    /// </summary>
    public class ObtenerSiniestroAwdLiquidadorFieldResponse : IMapFrom<Liquidador>
    {
        /// <summary>
        /// Id del liquidador
        /// </summary>
        public string Id { get; set; } = default!;

        /// <summary>
        /// Nombre del liquidador
        /// </summary>
        public string Nombre { get; set; } = default!;
    }
}
