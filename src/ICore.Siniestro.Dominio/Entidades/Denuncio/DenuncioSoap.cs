using ICore.Siniestro.Dominio.Entidades.Denuncio.Soporte;
using ICore.Siniestro.Dominio.Enumeradores;

namespace ICore.Siniestro.Dominio.Entidades.Denuncio
{
    public class DenuncioSoap : DenuncioSiniestro
    {
        public override TipoSiniestro TipoSiniestro => TipoSiniestro.SOAP;
        public Poliza Poliza { get; private set; } = default!;
        public Denunciante Denunciante { get; private set; } = default!;
        public Vehiculo Vehiculo { get; private set; } = default!;
        public Conductor Conductor { get; private set; } = default!;
        public Lesionado? Lesionado { get; private set; }
        private DenuncioSoap()
        {
        }
        private DenuncioSoap(
        Poliza poliza,
        Denunciante denunciante,
        Vehiculo vehiculo,
        Conductor conductor,
        Lesionado? lesionado)
        {
            Poliza = poliza;
            Denunciante = denunciante;
            Vehiculo = vehiculo;
            Conductor = conductor;
            Lesionado = lesionado;
        }
        public static DenuncioSoap Crear(
        Poliza poliza,
        Denunciante denunciante,
        Vehiculo vehiculo,
        Conductor conductor,
        Lesionado? lesionado = null)
        {
            return new DenuncioSoap(poliza, denunciante, vehiculo, conductor, lesionado);
        }
    }
}
