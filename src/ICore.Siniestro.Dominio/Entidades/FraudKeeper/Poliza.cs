namespace ICore.Siniestro.Dominio.Entidades.FraudKeeper
{
    /// <summary>
    /// Poliza.
    /// </summary>
    public class Poliza : Entidad<long>
    {
        /// <summary>
        /// Numero de Poliza.
        /// </summary>
        public string? NumeroPoliza { get; private set; }

        /// <summary>
        /// Fecha de Creacion.
        /// </summary>
        public string? FechaCreacion { get; private set; }

        /// <summary>
        /// Fecha de Inicio de vigencia.
        /// </summary>
        public string? FechaInicio { get; private set; }

        /// <summary>
        /// Fecha de Expiracion de vigencia.
        /// </summary>
        public string? FechaExpiracion { get; private set; }

        /// <summary>
        /// Fecha de Cancelacion.
        /// </summary>
        public string? FechaCancelacion { get; private set; }

        /// <summary>
        /// Fecha de Rehabilitacion.
        /// </summary>
        public string? FechaRehabilitacion { get; private set; }

        /// <summary>
        /// Codigo del Producto.
        /// </summary>
        public string? CodigoProducto { get; private set; }

        /// <summary>
        /// Codigo del Productor.
        /// </summary>
        public string? CodigoProductor { get; private set; }

        /// <summary>
        /// Texto adicional.
        /// </summary>
        public string? TextoAdicional { get; private set; }

        /// <summary>
        /// Metodo de Venta.
        /// </summary>
        public string? MetodoVenta { get; private set; }

        /// <summary>
        /// Prima.
        /// </summary>
        public double? Prima { get; private set; }

        /// <summary>
        /// Prima mas Impuestos.
        /// </summary>
        public double? PrimaConImpuestos { get; private set; }

        //----------------------- AWD --------------------------------//
        /// <summary>
        /// Numero de Certificado.
        /// </summary>
        public int? NumeroCertificado { get; private set; }

        /// <summary>
        /// Linea de negocio.
        /// </summary>
        public string? LineaNegocio { get; private set; }

        /// <summary>
        /// Codigo de Ramo.
        /// </summary>
        public string? Ramo { get; private set; }

        private Poliza() { }

        private Poliza(
            string? numeroPoliza,
            string? fechaCreacion,
            string? fechaInicio,
            string? fechaExpiracion,
            string? fechaCancelacion,
            string? fechaRehabilitacion,
            string? codigoProducto,
            string? codigoProductor,
            string? textoAdicional,
            string? metodoVenta,
            double? prima,
            double? primaConImpuestos,
            //AWD
            int? numeroCertificado,
            string? lineaNegocio,
            string? ramo
            )
        {
            NumeroPoliza = numeroPoliza;
            FechaCreacion = fechaCreacion;
            FechaInicio = fechaInicio;
            FechaExpiracion = fechaExpiracion;
            FechaCancelacion = fechaCancelacion;
            FechaRehabilitacion = fechaRehabilitacion;
            CodigoProducto = codigoProducto;
            CodigoProductor = codigoProductor;
            TextoAdicional = textoAdicional;
            MetodoVenta = metodoVenta;
            Prima = prima;
            PrimaConImpuestos = primaConImpuestos;
            //AWD
            NumeroCertificado = numeroCertificado;
            LineaNegocio = lineaNegocio;
            Ramo = ramo;
        }

        public static Poliza Crear(
            string? numeroPoliza,
            string? fechaCreacion,
            string? fechaInicio,
            string? fechaExpiracion,
            string? fechaCancelacion,
            string? fechaRehabilitacion,
            string? codigoProducto,
            string? codigoProductor,
            string? textoAdicional,
            string? metodoVenta,
            double? prima,
            double? primaConImpuestos,
            //AWD
            int? numeroCertificado,
            string? lineaNegocio,
            string? ramo
            )
        {
            return new Poliza(
                numeroPoliza,
                fechaCreacion,
                fechaInicio,
                fechaExpiracion,
                fechaCancelacion,
                fechaRehabilitacion,
                codigoProducto,
                codigoProductor,
                textoAdicional,
                metodoVenta,
                prima,
                primaConImpuestos,
                //AWD
                numeroCertificado,
                lineaNegocio,
                ramo
                );
        }
    }
}
