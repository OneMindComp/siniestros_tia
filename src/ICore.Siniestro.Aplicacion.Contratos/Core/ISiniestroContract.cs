using ICore.Siniestro.Dominio.Entidades.Falabella;

namespace ICore.Siniestro.Aplicacion.Contratos.Core
{
    public interface ISiniestroContract
    {
        Task<List<Dominio.Entidades.Siniestro>> ObtenerSiniestros(string numeroSiniestro);
        Task<List<Dominio.Entidades.FraudKeeper.Siniestro>> ObtenerSiniestroFraudKepper(string numeroCaso);
        Task<List<EstadoOrdenTrabajo>> ObtenerEstadoOrdenTrabajo(string numeroOrden);
    }
}
