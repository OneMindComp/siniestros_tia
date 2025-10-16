using ICore.Siniestro.Dominio.Enumeradores;

namespace ICore.Siniestro.Dominio.Entidades.Denuncio
{
    public class DenuncioSoap : DenuncioSiniestro
    {
        public override TipoSiniestro TipoSiniestro => TipoSiniestro.SOAP;
        public Soporte.Poliza Poliza { get; private set; } = default!;
        public Soporte.Denunciante Denunciante { get; private set; } = default!;
        public Soporte.Vehiculo Vehiculo { get; private set; } = default!;
        public Soporte.Conductor Conductor { get; private set; } = default!;
        public Soporte.Lesionado? Lesionado { get; private set; }
        private DenuncioSoap()
        {
        }
        private DenuncioSoap(
        Soporte.Poliza poliza,
        Soporte.Denunciante denunciante,
        Soporte.Vehiculo vehiculo,
        Soporte.Conductor conductor,
        Soporte.Lesionado? lesionado)
        {
            Poliza = poliza;
            Denunciante = denunciante;
            Vehiculo = vehiculo;
            Conductor = conductor;
            Lesionado = lesionado;
        }
        public static DenuncioSoap Crear(
        Soporte.Poliza poliza,
        Soporte.Denunciante denunciante,
        Soporte.Vehiculo vehiculo,
        Soporte.Conductor conductor,
        Soporte.Lesionado? lesionado = null)
        {
            return new DenuncioSoap(poliza, denunciante, vehiculo, conductor, lesionado);
        }
    }
}