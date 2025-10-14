namespace ICore.Siniestro.Dominio.Entidades.Denuncio.Soporte
{
    public class Poliza
    {
        public string NumeroPoliza { get; private set; } = default!;

        private Poliza() { }

        private Poliza(string numeroPoliza)
        {
            NumeroPoliza = numeroPoliza;
        }

        public static Poliza Crear(string numeroPoliza)
        {
            return new Poliza(numeroPoliza);
        }
    }
}
