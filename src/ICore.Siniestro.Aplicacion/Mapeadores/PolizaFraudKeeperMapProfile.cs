using AutoMapper;
using ICore.Siniestro.Aplicacion.Dtos.Responses.Fields.FraudKeeper;
using ICore.Siniestro.Dominio.Entidades.FraudKeeper;

namespace ICore.Siniestro.Aplicacion.Mapeadores
{
    /// <summary>
    /// Perfil para el uso de automapper.
    /// </summary>
    public class PolizaFraudKeeperMapProfile : Profile
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        public PolizaFraudKeeperMapProfile()
        {
            CreateMap<ObtenerSiniestroFraudKeeperFieldPolizaResponse, Poliza>()
                .ForMember(d => d.NumeroPoliza, m => m.MapFrom(s => s.NumeroPoliza))
                .ForMember(d => d.FechaCreacion, m => m.MapFrom(s => s.FechaCreacion))
                .ForMember(d => d.FechaInicio, m => m.MapFrom(s => s.FechaInicio))
                .ForMember(d => d.FechaExpiracion, m => m.MapFrom(s => s.FechaExpiracion))
                .ForMember(d => d.FechaCancelacion, m => m.MapFrom(s => s.FechaCancelacion))
                .ForMember(d => d.FechaRehabilitacion, m => m.MapFrom(s => s.FechaRehabilitacion))
                .ForMember(d => d.CodigoProducto, m => m.MapFrom(s => s.CodigoProducto))
                .ForMember(d => d.CodigoProductor, m => m.MapFrom(s => s.CodigoProductor))
                .ForMember(d => d.TextoAdicional, m => m.MapFrom(s => s.TextoAdicional))
                .ForMember(d => d.MetodoVenta, m => m.MapFrom(s => s.MetodoVenta))
                .ForMember(d => d.Prima, m => m.MapFrom(s => s.Prima))
                .ForMember(d => d.PrimaConImpuestos, m => m.MapFrom(s => s.PrimaConImpuestos))
                .ReverseMap();
        }
    }
}
