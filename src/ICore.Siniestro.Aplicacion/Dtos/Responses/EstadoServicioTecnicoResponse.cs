namespace ICore.Siniestro.Aplicacion.Dtos.Responses
{
    /// <summary>
    /// Respuesta para el estado de servicio tecnico desde Tia.
    /// </summary>
    public class EstadoServicioTecnicoResponse
    {
        /// <summary>
        /// Número del Servicio Técnico.
        /// </summary>
        public string? NumeroServicioTecnico { get; set; }

        /// <summary>
        /// Número de Guia Socio - F11.
        /// </summary>
        public string? NumeroF11 { get; set; }

        /// <summary>
        /// Código Servicio Técnico (Rut ST)-F11.
        /// </summary>
        public string? CodigoServicioTecnico { get; set; }

        /// <summary>
        /// Nombre Servicio Técnico-F11.
        /// </summary>
        public string? NombreServicioTecnico { get; set; }

        /// <summary>
        /// Telefono Servicio Técnico-F11.
        /// </summary>
        public string? TelefonoServicioTecnico { get; set; }

        /// <summary>
        /// Sucursal Servicio Técnico-F11.
        /// </summary>
        public string? SucursalServicioTecnico { get; set; }

        /// <summary>
        /// Estado OT/F11 Sistema Externo.
        /// </summary>
        public string? EstadoOrdenTrabajo { get; set; }

        /// <summary>
        /// Fecha Modificación Estado.
        /// </summary>
        public string? FechaModificacionEstado { get; set; }

        /// <summary>
        /// Fecha Recepción Producto.
        /// </summary>
        public string? FechaRecepcionProducto { get; set; }

        /// <summary>
        /// Número Guia Recepción Producto.
        /// </summary>
        public string? NumeroGuiaRecepcion { get; set; }

        /// <summary>
        /// Fecha Entrega Producto.
        /// </summary>
        public string? FechaEntregaProducto { get; set; }

        /// <summary>
        /// Número Guía Despacho Producto.
        /// </summary>
        public string? NumeroGuiaDespacho { get; set; }

        /// <summary>
        /// Descripción y/o Motivo de Rechazo o Reparación.
        /// </summary>
        public string? DescripcionRechazoOReparacion { get; set; }

        /// <summary>
        /// SKU Producto cambio.
        /// </summary>
        public string? SkuProducto { get; set; }

        /// <summary>
        /// Precio Producto cambio.
        /// </summary>
        public string? PrecioProducto { get; set; }

        /// <summary>
        /// Fecha de Creación de OT Sistema Externo (SBINS).
        /// </summary>
        public string? FechaCreacionOT { get; set; }

        /// <summary>
        /// Numero OT Servicio Externo (SBINS).
        /// </summary>
        public string? NumeroOTServicioTecnico { get; set; }
    }
}
