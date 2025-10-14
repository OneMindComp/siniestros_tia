namespace ICore.Siniestro.Aplicacion.Dtos.Requests.Denuncio.Soporte
{
    /// <summary>
    /// Informacion detallada del siniestro
    /// </summary>
    public class SiniestroRequest
    {
        /// <summary>
        /// Fecha y hora del siniestro
        /// </summary>
        public DateTime Fecha { get; set; }

        /// <summary>
        /// Relato detallado de como ocurrio el siniestro
        /// </summary>
        public string Relato { get; set; } = default!;

        /// <summary>
        /// Aceptacion de terminos y condiciones
        /// </summary>
        public bool? TerminosYCondiciones { get; set; }

        /// <summary>
        /// Region donde ocurrio el siniestro
        /// </summary>
        public string? Region { get; set; }

        /// <summary>
        /// Comuna donde ocurrio el siniestro
        /// </summary>
        public string? Comuna { get; set; }

        /// <summary>
        /// Direccion donde ocurrio el siniestro
        /// </summary>
        public string? Direccion { get; set; }

        /// <summary>
        /// Ubicacion del accidente para siniestros SOAP
        /// </summary>
        public string? Ubicacion { get; set; }

        /// <summary>
        /// Numero de parte policial
        /// </summary>
        public string? NumeroPartePolicial { get; set; }

        /// <summary>
        /// Centro veterinario donde se atendio la mascota
        /// </summary>
        public string? CentroVeterinario { get; set; }

        /// <summary>
        /// Lista de archivos adjuntos relacionados al siniestro
        /// </summary>
        public List<string>? Archivos { get; set; }

        /// <summary>
        /// Lugar donde ocurrio el siniestro de viaje
        /// </summary>
        public string? LugarSiniestro { get; set; }
    }
}
