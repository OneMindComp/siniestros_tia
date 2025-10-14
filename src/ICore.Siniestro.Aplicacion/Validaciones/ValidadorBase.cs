using ICore.Siniestro.Aplicacion.Dtos.Requests.Denuncio;
using ICore.Siniestro.Aplicacion.Interfaces;

namespace ICore.Siniestro.Aplicacion.Validaciones
{
    /// <summary>
    /// Validador base con logica comun
    /// </summary>
    public abstract class ValidadorBase : IValidadorSiniestro
    {
        /// <summary>
        /// validador comun a todos los tipos de denuncio
        /// </summary>
        /// <param name="denuncio"></param>
        /// <returns></returns>
        public List<string> Validar(DenuncioSiniestroRequest denuncio)
        {
            var errores = new List<string>();

            if (string.IsNullOrEmpty(denuncio.Siniestro?.Relato))
                errores.Add("Relato del siniestro es requerido");

            ValidarEspecifico(denuncio, errores);

            return errores;
        }

        /// <summary>
        /// Validacion especifica por tipo de denuncio
        /// </summary>
        protected abstract void ValidarEspecifico(DenuncioSiniestroRequest denuncio, List<string> errores);
    }
}
