using ICore.Siniestro.Dominio.Entidades.Denuncio.Soporte;
using ICore.Siniestro.Dominio.Enumeradores;

namespace ICore.Siniestro.Dominio.Entidades.Denuncio
{
    public class DenuncioSoap : DenuncioSiniestro
    {
        public override TipoSiniestro TipoSiniestro => TipoSiniestro.SOAP;
        public Poliza Poliza { get; set; } = default!;
        public Denunciante Denunciante { get; set; } = default!;
        public Vehiculo Vehiculo { get; set; } = default!;
        public Conductor Conductor { get; set; } = default!;
        public Lesionado? Lesionado { get; set; }
    }
}
