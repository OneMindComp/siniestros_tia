using ICore.Siniestro.Aplicacion.Dtos.Requests;
using ICore.Siniestro.Dominio.Enumeradores;

namespace ICore.Siniestro.Aplicacion.Interfaces
{
    /// <summary>
    /// Contrato base para todos los denuncios de siniestro
    /// </summary>
    public interface IDenuncioSiniestro
    {
        /// <summary>
        /// Tipo de siniestro
        /// </summary>
        TipoSiniestro TipoSiniestro { get; }

        /// <summary>
        /// Datos del siniestro
        /// </summary>
        Dtos.Requests.Denuncio.Soporte.SiniestroRequest Siniestro { get; set; }
    }
}
