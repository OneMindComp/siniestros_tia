using ICore.Siniestro.Aplicacion.Dtos.Requests.Denuncio;

namespace ICore.Siniestro.Aplicacion.Servicios
{
    /// <summary>
    /// Contrato para el servicio de validacion de denuncios
    /// </summary>
    public interface IValidacionDenuncios
    {
        /// <summary>
        /// Valida un denuncio usando su validador especifico
        /// </summary>
        /// <param name="denuncio"></param>
        /// <returns></returns>
        public List<string> Validar(DenuncioSiniestroRequest denuncio);
    }
}
