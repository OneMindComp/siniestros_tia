namespace ICore.Siniestro.Aplicacion.Dtos.Requests.Denuncio.Soporte
{
    /// <summary>
    /// Informacion del denunciante del siniestro
    /// </summary>
    public class DenuncianteRequest
    {
        /// <summary>
        /// Nombre completo del denunciante
        /// </summary>
        public string? NombreCompleto { get; set; }

        /// <summary>
        /// Nombre del denunciante
        /// </summary>
        public string? Nombre { get; set; }

        /// <summary>
        /// Apellidos del denunciante
        /// </summary>
        public string? Apellidos { get; set; }

        /// <summary>
        /// RUT del denunciante
        /// </summary>
        public string? Rut { get; set; }

        /// <summary>
        /// Telefono de contacto del denunciante
        /// </summary>
        public string Telefono { get; set; } = default!;

        /// <summary>
        /// Correo electronico del denunciante
        /// </summary>
        public string? Correo { get; set; }
    }
}
