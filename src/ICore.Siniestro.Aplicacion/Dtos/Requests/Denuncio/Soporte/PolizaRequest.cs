namespace ICore.Siniestro.Aplicacion.Dtos.Requests.Denuncio.Soporte
{
    /// <summary>
    /// Informacion de la poliza de seguro
    /// </summary>
    public class PolizaRequest
    {
        /// <summary>
        /// Numero de poliza del asegurado
        /// </summary>
        public string NumeroPoliza { get; set; } = default!;
    }
}
