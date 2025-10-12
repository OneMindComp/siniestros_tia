namespace ICore.Siniestro.Dominio.Entidades.Soap
{
    public class Poliza : Entidad<long>
    {
        public string NumeroPoliza { get; private set; } = default!;

        private Poliza()
        {
        }

        private Poliza(
            string numeroPoliza
            )
        {
            NumeroPoliza = numeroPoliza;
        }

        public static Poliza Crear(
            string numeroPoliza
            )
        {
            return new Poliza(
                numeroPoliza
                );
        }
    }
}
