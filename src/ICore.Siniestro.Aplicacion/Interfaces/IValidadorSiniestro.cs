using ICore.Siniestro.Aplicacion.Dtos.Requests.Denuncio;

namespace ICore.Siniestro.Aplicacion.Interfaces
{
    /// <summary>
    /// Contrato para validadores de siniestros
    /// </summary>
    public interface IValidadorSiniestro
    {
        /// <summary>
        /// Valida un denuncio de siniestro
        /// </summary>
        /// <param name="denuncio">Denuncio a validar</param>
        /// <returns>Lista de errores de validacion</returns>
        List<string> Validar(DenuncioSiniestroRequest denuncio);
    }
}
