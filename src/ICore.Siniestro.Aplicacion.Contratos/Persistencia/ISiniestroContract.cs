using ICore.Siniestro.Dominio.Entidades.Denuncio;
using ICore.Siniestro.Dominio.Entidades.Soap;

namespace ICore.Siniestro.Aplicacion.Contratos.Persistencia
{
    public interface ISiniestroContract
    {
        Task<SiniestroPropuesto> CrearSiniestro(DenuncioSiniestroSoap denuncio);
        Task<SiniestroPropuesto> CrearSiniestroSoap(SiniestroSoap siniestro);
        Task<SiniestroPropuesto> CrearSiniestroFalabella(Dominio.Entidades.Falabella.Siniestro siniestro);
        Task<SiniestroPropuesto> EnviarCourierFalabella(Dominio.Entidades.Falabella.Courier courier);
        Task<long?> ObtenerNumeroCaso(long numeroSiniestro);
        Task<long?> ObtenerNumeroCaso(string numeroSubsiniestro);
    }
}
