using ICore.Siniestro.Dominio.Enumeradores;
using System.Text.Json.Serialization;

namespace ICore.Siniestro.Aplicacion.Dtos.Requests.Denuncio
{
    /// <summary>
    /// Clase base abstracta para todos los denuncios de siniestro
    /// </summary>
    [JsonPolymorphic(TypeDiscriminatorPropertyName = "tipoSiniestro")]
    [JsonDerivedType(typeof(DenuncioSiniestroSoapRequest), typeDiscriminator: "SOAP")]
    // Agrega aquí otras clases derivadas si las hay en el futuro
    public abstract class DenuncioSiniestroRequest : IDenuncioSiniestroRequest
    {
        /// <summary>
        /// Tipo de siniestro
        /// </summary>
        [JsonIgnore]
        public abstract TipoSiniestro TipoSiniestro { get; }

        /// <summary>
        /// Datos del siniestro
        /// </summary>
        public Soporte.SiniestroRequest Siniestro { get; set; } = new();

    }
}
