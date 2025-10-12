namespace ICore.Siniestro.Aplicacion.Dtos.Requests
{
    /// <summary>
    /// Request para el siniestro de falabella
    /// </summary>
    public class OrdenTrabajoRequest
    {
        /// <summary>
        /// Numero de certificado.
        /// </summary>
        public string? CertificateNo { get; set; }

        /// <summary>
        /// Numero de registro de compañia.
        /// </summary>
        public string? CompanyRegistrationNo { get; set; }

        /// <summary>
        /// Tipo de evento.
        /// </summary>
        public string? EventType { get; set; }
        /// <summary>
        /// Tipo Causa.
        /// </summary>
        public string? CauseType { get; set; }

        /// <summary>
        /// Sub Tipo Causa.
        /// </summary>
        public string? SubcauseType { get; set; }

        /// <summary>
        /// Fecha incidente.
        /// </summary>
        public string? IncidentDate { get; set; }

        /// <summary>
        /// Es fecha de incidente exacta.
        /// </summary>
        public string? IsExactIncidentDate { get; set; }

        /// <summary>
        /// Tipo de lugar.
        /// </summary>
        public string? PlaceType { get; set; }

        /// <summary>
        /// Direccion del siniestro.
        /// </summary>
        public string? Address { get; set; }

        /// <summary>
        /// Gestor.
        /// </summary>
        public string? Handler { get; set; }

        /// <summary>
        /// Tipo de informante.
        /// </summary>
        public string? InformerType { get; set; }
        /// <summary>
        /// Nombre Informante.
        /// </summary>
        public string? InformerName { get; set; }

        /// <summary>
        /// Fecha de notificacion.
        /// </summary>
        public string? NotificationDate { get; set; }

        /// <summary>
        /// Estado siniestro.
        /// </summary>
        public string? Status { get; set; }

        /// <summary>
        /// Perdida de bono.
        /// </summary>
        public string? LossOfBonus { get; set; }

        /// <summary>
        /// Descripcion del siniestro.
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// Numero de riesgo.
        /// </summary>
        public string? RiskNo { get; set; }

        /// <summary>
        /// Numero de subriesgo
        /// </summary>
        public string? SubriskNo { get; set; }

        /// <summary>
        /// Archivado por.
        /// </summary>
        public string? FiledBy { get; set; }

        /// <summary>
        /// Rut del contacto
        /// </summary>
        public string? C24 { get; set; }

        /// <summary>
        /// Fono IVR.
        /// </summary>
        public string? C26 { get; set; }

        /// <summary>
        /// Fono del contacto.
        /// </summary>
        public string? C28 { get; set; }

        /// <summary>
        /// Direccion comercial del cliente.
        /// </summary>
        public string? C29 { get; set; }

        /// <summary>
        /// OT_NUM_ST + OT_COD_SUC_INGRESO + OT_NUM_GUIA_SOCIO + COD_SINIESTRO + COD_TIP_AT_SINIESTRO + COD_TRANSACCION + ID_MENSAJE
        /// </summary>
        public string? C903 { get; set; }
    }
}
