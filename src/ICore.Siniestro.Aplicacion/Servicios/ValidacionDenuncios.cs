using ICore.Siniestro.Aplicacion.Dtos.Requests.Denuncio;

namespace ICore.Siniestro.Aplicacion.Servicios
{
    /// <summary>
    /// Servicio para validar denuncios utilizando el patron apropiado
    /// </summary>
    public class ValidacionDenuncios:IValidacionDenuncios
    {
        /// <summary>
        /// Valida un denuncio usando su validador especifico
        /// </summary>
        public List<string> Validar(DenuncioSiniestroRequest denuncio)
        {
            var validador = denuncio.ObtenerValidador();
            return validador.Validar(denuncio);
        }
    }
}
