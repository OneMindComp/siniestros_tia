using ICore.Siniestro.Aplicacion.Dtos.Requests.Denuncio.Soporte;
using ICore.Siniestro.Aplicacion.Interfaces;
using ICore.Siniestro.Aplicacion.Validaciones;
using ICore.Siniestro.Dominio.Enumeradores;

namespace ICore.Siniestro.Aplicacion.Dtos.Requests.Denuncio
{
    /// <summary>
    /// Denuncio de siniestro SOAP (vehiculos)
    /// </summary>
    public class DenuncioSoapRequest : DenuncioSiniestroRequest
    {
        /// <summary>
        /// tipo de siniestro
        /// </summary>
        public override TipoSiniestro TipoSiniestro => TipoSiniestro.SOAP;

        /// <summary>
        /// Informacion de la poliza
        /// </summary>
        public PolizaRequest Poliza { get; set; } = new();

        /// <summary>
        /// Informacion del denunciante
        /// </summary>
        public DenuncianteRequest Denunciante { get; set; } = new();

        /// <summary>
        /// Informacion del vehiculo
        /// </summary>
        public VehiculoRequest Vehiculo { get; set; } = new();

        /// <summary>
        /// Informacion del conductor
        /// </summary>
        public ConductorRequest Conductor { get; set; } = new();

        /// <summary>
        /// Informacion del lesionado si aplica
        /// </summary>
        public LesionadoRequest? Lesionado { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override IValidadorSiniestro ObtenerValidador() => new ValidadorSOAP();
    }
}
