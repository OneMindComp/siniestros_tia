namespace ICore.Siniestro.Aplicacion.Dtos.Requests.Denuncio.Soporte
{
    /// <summary>
    /// Informacion de persona lesionada en el siniestro
    /// </summary>
    public class LesionadoRequest
    {
        /// <summary>
        /// Nombre completo del lesionado
        /// </summary>
        public string NombreCompleto { get; set; } = default!;

        /// <summary>
        /// RUT del lesionado
        /// </summary>
        public string Rut { get; set; } = default!;

        /// <summary>
        /// Telefono de contacto del lesionado
        /// </summary>
        public string Telefono { get; set; } = default!;

        /// <summary>
        /// Correo electronico del lesionado
        /// </summary>
        public string Correo { get; set; } = default!;
    }
}
