namespace ICore.Siniestro.Aplicacion.Dtos.Requests.Soap
{
    /// <summary>
    /// Request para siniestro soap.
    /// </summary>
    public class SiniestroSoapRequest
    {
        /// <summary>
        /// Numero de poliza.
        /// </summary>
        public string NumeroPoliza { get; set; } = default!;
        /// <summary>
        /// Patente.
        /// </summary>
        public string Patente { get; set; } = default!;
        /// <summary>
        /// Rut contratante.
        /// </summary>
        public string RutContratante { get; set; } = default!;
        /// <summary>
        /// Nombre contratante.
        /// </summary>
        public string NombreContratante { get; set; } = default!;
        /// <summary>
        /// Rut lesionado.
        /// </summary>
        public string RutLesionado { get; set; } = default!;
        /// <summary>
        /// Nombre lesionado.
        /// </summary>
        public string NombreLesionado { get; set; } = default!;
        /// <summary>
        /// Fecha siniestro.
        /// </summary>
        public string Fecha { get; set; } = default!;
        /// <summary>
        /// Numero de parte.
        /// </summary>
        public long NumeroParte { get; set; } = default!;
        /// <summary>
        /// Fecha de parte.
        /// </summary>
        public string FechaParte { get; set; } = default!;
        /// <summary>
        /// Tipo de evento.
        /// </summary>
        public string TipoEvento { get; set; } = default!;
        /// <summary>
        /// Numero interno.
        /// </summary>
        public string? NumeroInterno { get; set; } = default!;
        /// <summary>
        /// Rut institucion de salud.
        /// </summary>
        public string RutInstitucionSalud { get; set; } = default!;
        /// <summary>
        /// Nombre institucion de salud.
        /// </summary>
        public string NombreInstitucionSalud { get; set; } = default!;
        /// <summary>
        /// Monto bruto.
        /// </summary>
        public decimal MontoBruto { get; set; }
        /// <summary>
        /// Iva.
        /// </summary>
        public decimal Iva { get; set; }
        /// <summary>
        /// Monto neto.
        /// </summary>
        public decimal MontoNeto { get; set; }
        /// <summary>
        /// Numero de factura.
        /// </summary>
        public long NumeroFactura { get; set; }
        /// <summary>
        /// Controlador
        /// </summary>
        public string Controlador { get; set; } = default!;
        /// <summary>
        /// Liquidador
        /// </summary>
        public long Liquidador { get; set; } 
    }
}
