namespace ICore.Siniestro.Aplicacion.Dtos.Responses
{
    /// <summary>
    /// Response de guardar archivo en el core.
    /// </summary>
    public class GuardarArchivoResponse
    {
        /// <summary>
        /// Numero de siniestro.
        /// </summary>
        public string NumeroSiniestro { get; set; } = default!;

        /// <summary>
        /// Identificador del caso de un siniestro.
        /// </summary>
        public string IdCaso { get; set; } = default!;

        /// <summary>
        /// Estado de guardado true si satisfactorio o false si error.
        /// </summary>
        public bool ArchivoGuardado { get; set; }

        /// <summary>
        /// Mensaje de exito u error, segun sea el estado.
        /// </summary>
        public string Mensaje { get; set; } = default!;
    }
}
