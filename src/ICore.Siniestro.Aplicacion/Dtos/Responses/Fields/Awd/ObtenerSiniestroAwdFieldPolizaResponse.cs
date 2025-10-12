using ICore.Siniestro.Aplicacion.Mapeadores;
using ICore.Siniestro.Dominio.Entidades.Awd;

namespace ICore.Siniestro.Aplicacion.Dtos.Responses.Fields.Awd
{
    /// <summary>
    /// Response para los datos adicionales que se envian a Awd.
    /// </summary>
    public class ObtenerSiniestroAwdFieldPolizaResponse : IMapFrom<Poliza>
    {
        /// <summary>
        /// Numero de poliza
        /// </summary>
        public string NumeroPoliza { get; set; } = default!;
        /// <summary>
        /// Numero de certificado
        /// </summary>
        public int NumeroCertificado { get; set; }
        /// <summary>
        /// Linea de negocio
        /// </summary>
        public string LineaNegocio { get; set; } = default!;
        /// <summary>
        /// Inicio de vigencia
        /// </summary>
        public DateTime InicioVigencia { get; set; }
        /// <summary>
        /// Termino de vigencia
        /// </summary>
        public DateTime TerminoVigencia { get; set; }
        /// <summary>
        /// Ramo
        /// </summary>
        public string Ramo { get; set; } = default!;
        /// <summary>
        /// Asegurado
        /// </summary>
        public ObtenerSiniestroAwdFieldAseguradoResponse Asegurado { get; set; } = default!;
        /// <summary>
        /// Corredor
        /// </summary>
        public ObtenerSiniestroAwdFieldCorredorResponse Corredor { get; set; } = default!;
    }
}