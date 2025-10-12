namespace ICore.Siniestro.Aplicacion.Dtos.Requests
{
    /// <summary>
    /// Request para el cambio de estado del servicio tecnico desde Tia.
    /// </summary>
    public class EstadoServicioTecnicoRequest
    {
        /// <summary>
        /// Numero de siniestro Tia.
        /// </summary>
        public int ClaimCaseNo { get; set; }
    }
}
