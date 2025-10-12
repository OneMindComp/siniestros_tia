namespace ICore.Siniestro.Dominio.Entidades.Soap
{
    public class SiniestroPropuesto
    {
        public long NumeroSiniestro { get; private set; } = default!;

        private SiniestroPropuesto()
        {
        }

        private SiniestroPropuesto(long numeroSiniestro)
        {
            NumeroSiniestro = numeroSiniestro;
        }

        public static SiniestroPropuesto Crear(long numeroSiniestro)
        {
            return new SiniestroPropuesto(numeroSiniestro);
        }
    }
}
