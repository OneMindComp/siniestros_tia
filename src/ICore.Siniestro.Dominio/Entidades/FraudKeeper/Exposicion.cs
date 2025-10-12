namespace ICore.Siniestro.Dominio.Entidades.FraudKeeper
{
    /// <summary>
    /// Exposiciones al riesgo
    /// </summary>
    public class Exposicion : Entidad<long>
    {
        /// <summary>
        /// Descripcion de Cobertura.
        /// </summary>
        public string? DescripcionCobertura { get; private set; }

        /// <summary>
        /// Codigo de Descripcion de Cobertura.
        /// </summary>
        public string? CodigoCobertura { get; private set; }

        /// <summary>
        /// Moneda de Cobertura.
        /// </summary>
        public string? MonedaCobertura { get; private set; }

        /// <summary>
        /// Monto asegurado actual.
        /// </summary>
        public string? MontoAseguradoActual { get; private set; }

        /// <summary>
        /// Monto asegurado original.
        /// </summary>
        public string? MontoAseguradoOriginal { get; private set; }

        /// <summary>
        /// Reserva.
        /// </summary>
        public decimal? Reserva { get; private set; }

        /// <summary>
        /// Pago.
        /// </summary>
        public int? Pago { get; private set; }

        /// <summary>
        /// Reserva en moneda local.
        /// </summary>
        public int? ReservaMonedaLocal { get; private set; }

        /// <summary>
        /// Pago en moneda local.
        /// </summary>
        public int? PagoMonedaLocal { get; private set; }

        /// <summary>
        /// No utilizado.
        /// </summary>
        public bool? FirstParty { get; private set; }

        /// <summary>
        /// Contactos relacionados, no utilizado.
        /// </summary>
        public List<string>? ContactosRelacionados { get; private set; }

        /// <summary>
        /// Modelos, no utilizado
        /// </summary>
        public List<string>? Modelos { get; private set; }

        /// <summary>
        /// Datos adicionales.
        /// </summary>
        public List<string>? DatosAdicionales { get; private set; }

        /// <summary>
        /// Listado de patentes de vehiculos, no utilizado.
        /// </summary>
        public List<string>? Vehiculos { get; private set; }

        /// <summary>
        /// Riesgos.
        /// </summary>
        public List<Riesgo>? Riesgos { get; private set; }

        private Exposicion() { }

        private Exposicion(
            List<string>? modelos,
            List<string>? datosAdicionales,
            List<string>? vehiculos,
            List<Riesgo>? riesgo,
            string? descripcionCobertura,
            string? codigoCobertura,
            string? monedaCobertura,
            string? actualMontoAsegurado,
            string? montoAseguradoOriginal,
            decimal? reservas,
            int? pagos,
            int? reservasMonedaLocal,
            int? pagosMonedaLocal,
            bool? firstParty,
            List<string>? contactosRelacionados
            )
        {
            Modelos = modelos;
            DatosAdicionales = datosAdicionales;
            Vehiculos = vehiculos;
            Riesgos = riesgo;
            DescripcionCobertura = descripcionCobertura;
            CodigoCobertura = codigoCobertura;
            MonedaCobertura = monedaCobertura;
            MontoAseguradoActual = actualMontoAsegurado;
            MontoAseguradoOriginal = montoAseguradoOriginal;
            Reserva = reservas;
            Pago = pagos;
            ReservaMonedaLocal = reservasMonedaLocal;
            PagoMonedaLocal = pagosMonedaLocal;
            FirstParty = firstParty;
            ContactosRelacionados = contactosRelacionados;
        }

        public static Exposicion Crear(
            List<string>? modelos,
            List<string>? datosAdicionales,
            List<string>? vehiculos,
            List<Riesgo>? riesgo,
            string? descripcionCobertura,
            string? codigoCobertura,
            string? monedaCobertura,
            string? actualMontoAsegurado,
            string? montoAseguradoOriginal,
            decimal? reservas,
            int? pagos,
            int? reservasMonedaLocal,
            int? pagosMonedaLocal,
            bool? firstParty,
            List<string>? contactosRelacionados
            )
        {
            return new Exposicion(
                modelos,
                datosAdicionales,
                vehiculos,
                riesgo,
                descripcionCobertura,
                codigoCobertura,
                monedaCobertura,
                actualMontoAsegurado,
                montoAseguradoOriginal,
                reservas,
                pagos,
                reservasMonedaLocal,
                pagosMonedaLocal,
                firstParty,
                contactosRelacionados
                );
        }
    }
}
