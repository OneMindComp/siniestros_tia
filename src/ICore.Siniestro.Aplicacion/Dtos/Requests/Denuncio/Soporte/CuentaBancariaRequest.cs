namespace ICore.Siniestro.Aplicacion.Dtos.Requests.Denuncio.Soporte
{
    /// <summary>
    /// Informacion de cuenta bancaria para reembolsos
    /// </summary>
    public class CuentaBancariaRequest
    {
        /// <summary>
        /// Nombre del banco
        /// </summary>
        public string Banco { get; set; } = default!;

        /// <summary>
        /// Tipo de cuenta bancaria
        /// </summary>
        public string TipoCuenta { get; set; } = default!;

        /// <summary>
        /// Numero de cuenta bancaria
        /// </summary>
        public string NumeroCuenta { get; set; } = default!;
    }
}
