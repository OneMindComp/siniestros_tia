using ICore.Siniestro.Dominio.Entidades.Soap;

namespace ICore.Siniestro.Aplicacion.Contratos.Persistencia
{
    public interface ISiniestroContract
    {
        Task<SiniestroPropuesto> CrearSiniestroSoap(SiniestroSoap siniestro);
        Task<SiniestroPropuesto> CrearSiniestroFalabella(ICore.Siniestro.Dominio.Entidades.Falabella.Siniestro siniestro);
        Task<SiniestroPropuesto> EnviarCourierFalabella(ICore.Siniestro.Dominio.Entidades.Falabella.Courier courier);
        Task<long?> ObtenerNumeroCaso(long numeroSiniestro);
        Task<long?> ObtenerNumeroCaso(string numeroSubsiniestro);
    }
}
