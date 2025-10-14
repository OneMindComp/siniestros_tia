namespace ICore.Siniestro.Aplicacion.Dtos.Requests.Denuncio.Soporte
{
    /// <summary>
    /// Informacion del vehiculo involucrado en el siniestro
    /// </summary>
    public class VehiculoRequest
    {
        /// <summary>
        /// Patente del vehiculo
        /// </summary>
        public string Patente { get; set; } = default!;

        /// <summary>
        /// Numero de motor del vehiculo
        /// </summary>
        public string NumeroMotor { get; set; } = default!;
    }
}
