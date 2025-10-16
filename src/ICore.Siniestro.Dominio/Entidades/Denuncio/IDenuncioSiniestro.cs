using ICore.Siniestro.Dominio.Enumeradores;

namespace ICore.Siniestro.Dominio.Entidades.Denuncio
{
    public interface IDenuncioSiniestro
    {
        TipoSiniestro TipoSiniestro { get; }
        Soporte.Siniestro Siniestro { get; set; }
    }
}
