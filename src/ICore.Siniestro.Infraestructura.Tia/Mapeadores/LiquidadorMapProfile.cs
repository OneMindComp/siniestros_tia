using AutoMapper;
using ICore.Siniestro.Infraestructura.Tia.Dto;
using ICore.Siniestro.Dominio.Entidades.Awd;

namespace ICore.Siniestro.Infraestructura.Tia.Mapeadores
{
    public class LiquidadorMapProfile : Profile
    {
        public LiquidadorMapProfile()
        {
            CreateMap<LiquidadorDto, Liquidador>().ReverseMap();
        }
    }
}
