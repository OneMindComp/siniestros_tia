using ICore.Siniestro.Aplicacion.Dtos.Responses.Fields.FraudKeeper;

namespace ICore.Siniestro.Aplicacion.Dtos.Responses
{
    /// <summary>
    /// Response del siniestro fraudkeeper
    /// </summary>
    public class ObtenerSiniestroFraudKeeperResponse
    {
        /// <summary>
        /// Fecha de creacion del siniestro
        /// </summary>
        public DateTime? FechaCreacion { get; set; }
        /// <summary>
        /// Identificador siniestro + subsiniestro
        /// </summary>
        public string? IdPublico { get; set; }
        /// <summary>
        /// Numero del siniestro
        /// </summary>
        public string? NumeroSiniestro { get; set; }
        /// <summary>
        /// Fecha que ocurrio el siniestro
        /// </summary>
        public DateTime? FechaAcontecimiento { get; set; }
        /// <summary>
        /// Fecha de apertura del siniestro
        /// </summary>
        public DateTime? FechaApertura { get; set; }
        /// <summary>
        /// Fecha de notificacion del siniestro
        /// </summary>
        public DateTime? FechaNotificacion { get; set; }
        /// <summary>
        /// Descripcion del siniestro
        /// </summary>
        public string? Descripcion { get; set; }
        /// <summary>
        /// Causa primaria del siniestro
        /// </summary>
        public string? CausaPrimaria { get; set; }
        /// <summary>
        /// Direccion que ocurrio el siniestro
        /// </summary>
        public string? Direccion { get; set; }
        /// <summary>
        /// Pais que ocurrio del siniestro
        /// </summary>
        public string? Pais { get; set; }
        /// <summary>
        /// Indicador de importancia del siniestro
        /// </summary>
        public bool? HasMatters { get; set; }
        /// <summary>
        /// Cobertura en cuestion
        /// </summary>
        public bool? CoberturaEnCuestion { get; set; }
        /// <summary>
        /// Notas adicionales
        /// </summary>
        public string? NotasAdicionales { get; set; }
        /// <summary>
        /// Administrador del reclamos
        /// </summary>
        public string? AdministradorReclamos { get; set; }
        /// <summary>
        /// Numero de Vehiculos
        /// </summary>
        public int? NumeroDeVehiculos { get; set; }
        /// <summary>
        /// Numero de Testigos
        /// </summary>
        public int? NumeroDeTestigos { get; set; }
        /// <summary>
        /// Total monto reclamado
        /// </summary>
        public decimal? MontoTotalReclamo { get; set; }
        /// <summary>
        /// Major line
        /// </summary>
        public string? BranchGroupCode { get; set; }
        /// <summary>
        /// Major line cd + Minor line + Class profile cd
        /// </summary>
        public string? BranchGroupDescription { get; set; }
        /// <summary>
        /// Lenguaje
        /// </summary>
        public List<string>? Lenguaje { get; set; }
        /// <summary>
        /// Informacion Externa
        /// </summary>
        public List<string>? InformacionExterna { get; set; }
        /// <summary>
        /// Archivos
        /// </summary>
        public List<string>? Archivos { get; set; }
        /// <summary>
        /// Poliza
        /// </summary>
        public ObtenerSiniestroFraudKeeperFieldPolizaResponse? Poliza { set; get; }
        /// <summary>
        /// Exposiciones
        /// </summary>
        public List<ObtenerSiniestroFraudKeeperFieldExposicionResponse>? Exposiciones { get; set; }
        /// <summary>
        /// Datos adicional
        /// </summary>
        public List<ObtenerSiniestroFraudKeeperFieldDatosAdicionalesResponse>? DatosAdicionales { get; set; }
        /// <summary>
        /// Entidad particpante del siniestro (demandante, Afectado, Liquidador, etc)
        /// </summary>
        public List<ObtenerSiniestroFraudKeeperFieldParticipanteResponse>? Participantes { get; set; }

    }
}
