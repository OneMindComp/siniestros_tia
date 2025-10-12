using ICore.Siniestro.Aplicacion.Mapeadores;
using ICore.Siniestro.Dominio.Entidades.FraudKeeper;

namespace ICore.Siniestro.Aplicacion.Dtos.Responses.Fields.FraudKeeper
{
    /// <summary>
    /// Campo exposicion para Response de obtener siniestro fraudkeeper.
    /// </summary>
    public class ObtenerSiniestroFraudKeeperFieldExposicionResponse : IMapFrom<Exposicion>
    {
        /// <summary>
        /// Descripcion de Cobertura.
        /// </summary>
        public string? DescripcionCobertura { get; set; }

        /// <summary>
        /// Codigo de Descripcion de Cobertura.
        /// </summary>
        public string? CodigoCobertura { get; set; }

        /// <summary>
        /// Moneda de Cobertura.
        /// </summary>
        public string? MonedaCobertura { get; set; }

        /// <summary>
        /// Monto asegurado actual.
        /// </summary>
        public string? MontoAseguradoActual { get; set; }

        /// <summary>
        /// Monto asegurado original.
        /// </summary>
        public string? MontoAseguradoOriginal { get; set; }

        /// <summary>
        /// Reserva.
        /// </summary>
        public int? Reserva { get; set; }

        /// <summary>
        /// Pago.
        /// </summary>
        public int? Pago { get; set; }

        /// <summary>
        /// Reserva en moneda local.
        /// </summary>
        public int? ReservaMonedaLocal { get; set; }

        /// <summary>
        /// Pago en moneda local.
        /// </summary>
        public int? PagoMonedaLocal { get; set; }

        /// <summary>
        /// No utilizado.
        /// </summary>
        public bool? FirstParty { get; set; }

        /// <summary>
        /// Contactos relacionados, no utilizado.
        /// </summary>
        public List<string>? ContactosRelacionados { get; set; }

        /// <summary>
        /// Modelos, no utilizado
        /// </summary>
        public List<string>? Modelos { get; set; }

        /// <summary>
        /// Datos adicionales.
        /// </summary>
        public List<string>? DatosAdicionales { get; set; }

        /// <summary>
        /// Listado de patentes de vehiculos, no utilizado.
        /// </summary>
        public List<string>? Vehiculos { get; set; }
        /// <summary>
        /// Listado de riesgos.
        /// </summary>
        public List<ObtenerSiniestroFraudKeeperFieldRiesgoResponse>? Riesgos { get; set; }
    }
}
