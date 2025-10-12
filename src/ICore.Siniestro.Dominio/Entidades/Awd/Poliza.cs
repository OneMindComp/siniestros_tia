namespace ICore.Siniestro.Dominio.Entidades.Awd
{
    public class Poliza
    {
        public string NumeroPoliza { get; private set; } = default!;
        public int NumeroCertificado { get; private set; }
        public string LineaNegocio { get; private set; } = default!;
        public DateTime InicioVigencia { get; private set; }
        public DateTime TerminoVigencia { get; private set; }
        public string Ramo { get; private set; } = default!;
        public Asegurado Asegurado { get; private set; } = default!;
        public Corredor Corredor { get; private set; } = default!;


        private Poliza()
        {
        }

        private Poliza(
            string numeroPoliza,
            int numeroCertificado,
            string lineaNegocio,
            DateTime inicioVigencia,
            DateTime terminoVigencia,
            string ramo,
            Asegurado asegurado,
            Corredor corredor
            )
        {
            NumeroPoliza = numeroPoliza;
            NumeroCertificado = numeroCertificado;
            LineaNegocio = lineaNegocio;
            InicioVigencia = inicioVigencia;
            TerminoVigencia = terminoVigencia;
            Ramo = ramo;
            Asegurado = asegurado;
            Corredor = corredor;
        }

        public static Poliza Crear(
            string numeroPoliza,
            int numeroCertificado,
            string lineaNegocio,
            DateTime inicioVigencia,
            DateTime terminoVigencia,
            string ramo,
            Asegurado asegurado,
            Corredor corredor
            )
        {
            return new Poliza(
                numeroPoliza,
                numeroCertificado,
                lineaNegocio,
                inicioVigencia,
                terminoVigencia,
                ramo,
                asegurado,
                corredor
                );
        }

    }
}
