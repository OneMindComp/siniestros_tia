using ICore.Siniestro.Aplicacion.Mapeadores;
using ICore.Siniestro.Dominio.Entidades.Awd;

namespace ICore.Siniestro.Aplicacion.Dtos.Responses.Fields.FraudKeeper
{
    /// <summary>
    /// Campo poliza para Response de obtener siniestro fraudkeeper.
    /// </summary>
    public class ObtenerSiniestroFraudKeeperFieldPolizaResponse : IMapFrom<Poliza>
    {
        /// <summary>
        /// Numero de Poliza.
        /// </summary>
        public string? NumeroPoliza { get; set; }

        /// <summary>
        /// Fecha de Creacion.
        /// </summary>
        public string? FechaCreacion { get; set; }

        /// <summary>
        /// Fecha de Inicio de vigencia.
        /// </summary>
        public string? FechaInicio { get; set; }

        /// <summary>
        /// Fecha de Expiracion de vigencia.
        /// </summary>
        public string? FechaExpiracion { get; set; }

        /// <summary>
        /// Fecha de Cancelacion.
        /// </summary>
        public string? FechaCancelacion { get; set; }

        /// <summary>
        /// Fecha de Rehabilitacion.
        /// </summary>
        public string? FechaRehabilitacion { get; set; }

        /// <summary>
        /// Codigo del Producto.
        /// </summary>
        public string? CodigoProducto { get; set; }

        /// <summary>
        /// Codigo del Productor.
        /// </summary>
        public string? CodigoProductor { get; set; }

        /// <summary>
        /// Texto adicional.
        /// </summary>
        public string? TextoAdicional { get; set; }

        /// <summary>
        /// Metodo de Venta.
        /// </summary>
        public string? MetodoVenta { get; set; }

        /// <summary>
        /// Prima.
        /// </summary>
        public double? Prima { get; set; }

        /// <summary>
        /// Prima mas Impuestos.
        /// </summary>
        public double? PrimaConImpuestos { get; set; }

        //----------------------- AWD --------------------------------//
        /// <summary>
        /// Numero de Certificado.
        /// </summary>
        public int? NumeroCertificado { get; set; }

        /// <summary>
        /// Linea de negocio.
        /// </summary>
        public string? LineaNegocio { get; set; }

        /// <summary>
        /// Codigo de Ramo.
        /// </summary>
        public string? Ramo { get; set; }
    }
}
