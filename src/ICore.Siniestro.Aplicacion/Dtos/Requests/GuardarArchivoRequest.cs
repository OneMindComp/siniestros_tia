using Microsoft.AspNetCore.Http;

namespace ICore.Siniestro.Aplicacion.Dtos.Requests
{
    /// <summary>
    /// Request para guardar achivo en el core.
    /// </summary>
    public class GuardarArchivoRequest
    {
        /// <summary>
        /// Archivo a guardar.
        /// </summary>
        public IFormFile Data { get; set; } = default!;

        /// <summary>
        /// Numero de siniestro sin guion ni certificado.
        /// </summary>
        public long NumeroSiniestro { get; set; }
    }
}
