using AutoMapper;
using ICore.Siniestro.Infraestructura.Tia.Dto;
using ICore.Siniestro.Dominio.Entidades.Awd;

namespace ICore.Siniestro.Infraestructura.Tia.Mapeadores
{
    public class AseguradoMapProfile : Profile
    {
        public AseguradoMapProfile()
        {
            CreateMap<AseguradoDto, Asegurado>().ReverseMap();
        }
    }
}
