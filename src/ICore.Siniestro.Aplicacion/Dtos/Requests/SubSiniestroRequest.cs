namespace ICore.Siniestro.Aplicacion.Dtos.Requests
{
    /// <summary>
    /// Request para obtener un subsiniestro por numero.
    /// </summary>
    public class SubSiniestroRequest
    {
        /// <summary>
        /// Numero de subsiniestro.
        /// </summary>
        public string NumeroSubSiniestro { get; set; } = default!;
    }
}
