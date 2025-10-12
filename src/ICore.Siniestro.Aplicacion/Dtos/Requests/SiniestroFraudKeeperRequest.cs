namespace ICore.Siniestro.Aplicacion.Dtos.Requests
{
    /// <summary>
    /// Request para el siniestro de fraudkeeper.
    /// </summary>
    public class SiniestroFraudKeeperRequest
    {
        /// <summary>
        /// Numero de siniestro.
        /// </summary>
        public string? NumeroSiniestro { get; set; }

        /// <summary>
        /// Numero de caso.
        /// </summary>
        public string? NumeroCaso { get; set; }
    }
}
