namespace ICore.Siniestro.Aplicacion.Dtos.Requests
{
    /// <summary>
    /// Courier
    /// </summary>
    public class EnviarCourierRequest
    {
        /// <summary>
        /// Numero de socio.
        /// </summary>
        public string MemberNo { get; set; } = default!;

        /// <summary>
        /// Numero certificado u otNumAct.
        /// </summary>
        public string CertificateNo { get; set; } = default!;

        /// <summary>
        /// Numero orden de trabajo.
        /// </summary>
        public string ExtWoNo { get; set; } = default!;

        /// <summary>
        /// fechaEvento + horaEvento (ISO-8601 format)
        /// </summary>
        public string EventDate { get; set; } = default!;

        /// <summary>
        /// Codigo de transaccion.
        /// </summary>
        public string TransactionId { get; set; } = default!;

        /// <summary>
        /// id del mensaje.
        /// </summary>
        public string MessageId { get; set; } = default!;
    }
}
