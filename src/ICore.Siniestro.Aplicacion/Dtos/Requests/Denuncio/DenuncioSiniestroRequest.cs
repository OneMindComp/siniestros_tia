using ICore.Siniestro.Aplicacion.Interfaces;
using ICore.Siniestro.Dominio.Enumeradores;

namespace ICore.Siniestro.Aplicacion.Dtos.Requests.Denuncio
{
    /// <summary>
    /// Clase base abstracta para todos los denuncios de siniestro
    /// </summary>
    public abstract class DenuncioSiniestroRequest : IDenuncioSiniestro
    {
        /// <summary>
        /// Tipo de siniestro
        /// </summary>
        public abstract TipoSiniestro TipoSiniestro { get; }

        /// <summary>
        /// Datos del siniestro
        /// </summary>
        public Soporte.SiniestroRequest Siniestro { get; set; } = new();

        /// <summary>
        /// Obtiene el validador apropiado para este tipo de denuncio
        /// </summary>
        public abstract IValidadorSiniestro ObtenerValidador();
    }
}
