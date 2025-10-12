using Microsoft.AspNetCore.Http;

namespace ICore.Siniestro.Aplicacion.Dtos.Requests
{
    /// <summary>
    /// Request para guardar achivo de subsiniestro en el core.
    /// </summary>
    public class GuardarArchivoSubsiniestroRequest
    {
        /// <summary>
        /// Archivo a guardar.
        /// </summary>
        public IFormFile Data { get; set; } = default!;

        /// <summary>
        /// Numero de subsiniestro con guion y certificado.
        /// </summary>
        public string NumeroSubsiniestro { get; set; } = default!;
    }
}
