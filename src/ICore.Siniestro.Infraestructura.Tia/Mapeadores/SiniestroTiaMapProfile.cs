using AutoMapper;
using ICore.Siniestro.Infraestructura.Tia.Dto;

namespace ICore.Siniestro.Infraestructura.Tia.Mapeadores
{
    public class SiniestroTiaMapProfile : Profile
    {
        public SiniestroTiaMapProfile()
        {
            CreateMap<SiniestroDto, ICore.Siniestro.Dominio.Entidades.Siniestro>().ReverseMap();

        }
    }
}
