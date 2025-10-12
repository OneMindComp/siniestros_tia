using AutoMapper;
using ICore.Siniestro.Aplicacion.Dtos.Responses;
using ICore.Siniestro.Dominio.Entidades.Falabella;

namespace ICore.Siniestro.Aplicacion.Mapeadores
{
    /// <summary>
    /// Perfil para el uso de automapper.
    /// </summary>
    public class EstadoOrdenTrabajoMapProfile : Profile
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        public EstadoOrdenTrabajoMapProfile()
        {
            CreateMap<EstadoServicioTecnicoResponse, EstadoOrdenTrabajo>()
                .ForMember(d => d.NumeroServicioTecnico, m => m.MapFrom(s => s.NumeroServicioTecnico))
                .ForMember(d => d.NumeroF11, m => m.MapFrom(s => s.NumeroF11))
                .ForMember(d => d.CodigoServicioTecnico, m => m.MapFrom(s => s.CodigoServicioTecnico))
                .ForMember(d => d.NombreServicioTecnico, m => m.MapFrom(s => s.NombreServicioTecnico))
                .ForMember(d => d.TelefonoServicioTecnico, m => m.MapFrom(s => s.TelefonoServicioTecnico))
                .ForMember(d => d.SucursalServicioTecnico, m => m.MapFrom(s => s.SucursalServicioTecnico))
                .ForMember(d => d.EstadoOrden, m => m.MapFrom(s => s.EstadoOrdenTrabajo))
                .ForMember(d => d.FechaModificacionEstado, m => m.MapFrom(s => s.FechaModificacionEstado))
                .ForMember(d => d.FechaRecepcionProducto, m => m.MapFrom(s => s.FechaRecepcionProducto))
                .ForMember(d => d.NumeroGuiaRecepcion, m => m.MapFrom(s => s.NumeroGuiaRecepcion))
                .ForMember(d => d.FechaEntregaProducto, m => m.MapFrom(s => s.FechaEntregaProducto))
                .ForMember(d => d.NumeroGuiaDespacho, m => m.MapFrom(s => s.NumeroGuiaDespacho))
                .ForMember(d => d.DescripcionRechazoOReparacion, m => m.MapFrom(s => s.DescripcionRechazoOReparacion))
                .ForMember(d => d.SkuProducto, m => m.MapFrom(s => s.SkuProducto))
                .ForMember(d => d.PrecioProducto, m => m.MapFrom(s => s.PrecioProducto))
                .ForMember(d => d.FechaCreacionOrdenTrabajo, m => m.MapFrom(s => s.FechaCreacionOT))
                .ForMember(d => d.NumeroOrdenTrabajoServicioTecnico, m => m.MapFrom(s => s.NumeroOTServicioTecnico))
                .ReverseMap();
        }
    }
}
