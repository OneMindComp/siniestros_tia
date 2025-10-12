namespace ICore.Siniestro.Dominio.Entidades.Falabella
{
    public class Courier
    {
        /// <summary>
        /// Numero de socio.
        /// </summary>
        public string NumeroSocio { get; set; } = default!;

        /// <summary>
        /// Numero certificado u otNumAct.
        /// </summary>
        public string NumeroCertificado { get; set; } = default!;

        /// <summary>
        /// Numero orden de trabajo.
        /// </summary>
        public string NumeroOrdenTrabajo { get; set; } = default!;

        /// <summary>
        /// fechaEvento + horaEvento (ISO-8601 format)
        /// </summary>
        public string FechaEvento { get; set; } = default!;

        /// <summary>
        /// Codigo de transaccion.
        /// </summary>
        public string IdTransaccion { get; set; } = default!;

        /// <summary>
        /// id del mensaje.
        /// </summary>
        public string IdMensaje { get; set; } = default!;

        private Courier() { }

        private Courier(
            string numeroSocio,
            string numeroCertificado,
            string numeroOrdenTrabajo,
            string fechaEvento,
            string idTransaccion,
            string idMensaje
            )
        {
            NumeroSocio = numeroSocio;
            NumeroCertificado = numeroCertificado;
            NumeroOrdenTrabajo = numeroOrdenTrabajo;
            FechaEvento = fechaEvento;
            IdTransaccion = idTransaccion;
            IdMensaje = idMensaje;
        }

        public static Courier Crear(
            string numeroSocio,
            string numeroCertificado,
            string numeroOrdenTrabajo,
            string fechaEvento,
            string idTransaccion,
            string idMensaje)
        {
            return new Courier(
                numeroSocio,
                numeroCertificado,
                numeroOrdenTrabajo,
                fechaEvento,
                idTransaccion,
                idMensaje
            );
        }
    }
}
