namespace ICore.Siniestro.Aplicacion.Dtos.Requests.Denuncio.Soporte
{
    /// <summary>
    /// Informacion del conductor del vehiculo
    /// </summary>
    public class ConductorRequest
    {
        /// <summary>
        /// Nombre completo del conductor
        /// </summary>
        public string NombreCompleto { get; set; } = default!;

        /// <summary>
        /// RUT del conductor
        /// </summary>
        public string Rut { get; set; } = default!;
    }
}
