using ICore.Siniestro.Dominio.Enumeradores;

namespace ICore.Siniestro.Dominio.Entidades.Denuncio
{
    public abstract class DenuncioSiniestro : IDenuncioSiniestro
    {
        public abstract TipoSiniestro TipoSiniestro { get; }
        public Siniestro Siniestro { get; set; }=default!;

    }
}
