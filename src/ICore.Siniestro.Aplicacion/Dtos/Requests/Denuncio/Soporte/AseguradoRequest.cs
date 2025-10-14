namespace ICore.Siniestro.Aplicacion.Dtos.Requests.Denuncio.Soporte
{
    /// <summary>
    /// Informacion del asegurado
    /// </summary>
    public class AseguradoRequest
    {
        /// <summary>
        /// Nombre completo del asegurado
        /// </summary>
        public string NombreCompleto { get; set; } = default!;

        /// <summary>
        /// RUT del asegurado
        /// </summary>
        public string Rut { get; set; } = default!;

        /// <summary>
        /// Telefono de contacto del asegurado
        /// </summary>
        public string Telefono { get; set; } = default!;

        /// <summary>
        /// Correo electronico del asegurado
        /// </summary>
        public string Correo { get; set; } = default!;
    }
}
