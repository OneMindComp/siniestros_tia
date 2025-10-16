using ICore.Siniestro.Aplicacion.Dtos.Requests;
using ICore.Siniestro.Dominio.Enumeradores;

namespace ICore.Siniestro.Aplicacion.Dtos.Requests.Denuncio
{
    /// <summary>
    /// Contrato base para todos los denuncios de siniestro
    /// </summary>
    public interface IDenuncioSiniestroRequest
    {
        /// <summary>
        /// Tipo de siniestro
        /// </summary>
        TipoSiniestro TipoSiniestro { get; }

        /// <summary>
        /// Datos del siniestro
        /// </summary>
        Soporte.SiniestroRequest Siniestro { get; set; }
    }
}
