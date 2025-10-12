namespace ICore.Siniestro.Dominio.Entidades.Falabella
{
    public class EstadoOrdenTrabajo
    {
        public string? NumeroServicioTecnico { get; private set; } = default!;
        public string? NumeroF11 { get; private set; } = default!;
        public string? CodigoServicioTecnico { get; private set; } = default!;
        public string? NombreServicioTecnico { get; private set; } = default!;
        public string? TelefonoServicioTecnico { get; private set; } = default!;
        public string? SucursalServicioTecnico { get; private set; } = default!;
        public string? EstadoOrden { get; private set; } = default!;
        public string? FechaModificacionEstado { get; private set; } = default!;
        public string? FechaRecepcionProducto { get; private set; } = default!;
        public string? NumeroGuiaRecepcion { get; private set; } = default!;
        public string? FechaEntregaProducto { get; private set; } = default!;
        public string? NumeroGuiaDespacho { get; private set; } = default!;
        public string? DescripcionRechazoOReparacion { get; private set; } = default!;
        public string? SkuProducto { get; private set; } = default!;
        public string? PrecioProducto { get; private set; } = default!;
        public string? FechaCreacionOrdenTrabajo { get; private set; } = default!;
        public string? NumeroOrdenTrabajoServicioTecnico { get; private set; } = default!;

        private EstadoOrdenTrabajo() { }

        public void DatosServicioTecnico(
            string? numeroServicioTecnico,
            string? numeroF11,
            string? codigoServicioTecnico,
            string? nombreServicioTecnico,
            string? telefonoServicioTecnico,
            string? sucursalServicioTecnico,
            string? numeroOrdenTrabajoServicioTecnico
            )
        {
            NumeroServicioTecnico = numeroServicioTecnico;
            NumeroF11 = numeroF11;
            CodigoServicioTecnico = codigoServicioTecnico;
            NombreServicioTecnico = nombreServicioTecnico;
            TelefonoServicioTecnico = telefonoServicioTecnico;
            SucursalServicioTecnico = sucursalServicioTecnico;
            NumeroOrdenTrabajoServicioTecnico = numeroOrdenTrabajoServicioTecnico;
        }

        public void DatosOrdenTrabajo(
            string? estadoOrden,
            string? fechaModificacionEstado,
            string? fechaCreacionOrden
            )
        {
            EstadoOrden = estadoOrden;
            FechaModificacionEstado = fechaModificacionEstado;
            FechaCreacionOrdenTrabajo = fechaCreacionOrden;
        }

        public void DatosProducto(
            string? fechaRecepcionProducto,
            string? numeroGuiaRecepcion,
            string? fechaEntregaProducto,
            string? numeroGuiaDespacho,
            string? descripcionRechazoOReparacion,
            string? skuProducto,
            string? precioProducto
            )
        {
            FechaRecepcionProducto = fechaRecepcionProducto;
            NumeroGuiaRecepcion = numeroGuiaRecepcion;
            FechaEntregaProducto = fechaEntregaProducto;
            NumeroGuiaDespacho = numeroGuiaDespacho;
            DescripcionRechazoOReparacion = descripcionRechazoOReparacion;
            SkuProducto = skuProducto;
            PrecioProducto = precioProducto;
        }

        // Método estático para crear una instancia inicial con valores por defecto
        public static EstadoOrdenTrabajo Crear()
        {
            return new EstadoOrdenTrabajo();
        }
    }
}
