namespace ICore.Siniestro.Dominio.Entidades.Soap
{
    public class SiniestroSoap
    {
        public DateTime Fecha { get; private set; }
        public string TipoEvento { get; private set; } = default!;
        public string Controlador { get; private set; } = default!;
        public long Liquidador { get; private set; } = default!;
        public Poliza Poliza { get; private set; } = default!;
        public Vehiculo Vehiculo { get; private set; } = default!;
        public Contratante Contratante { get; private set; } = default!;
        public Lesionado Lesionado { get; private set; } = default!;
        public PartePolicial? Parte { get; private set; } = default!;
        public InstitucionSalud InstitucionSalud { get; private set; } = default!;
        public Factura Factura { get; private set; } = default!;

        private SiniestroSoap()
        {
        }

        private SiniestroSoap(
            DateTime fecha,
            string tipoEvento,
            string controlador,
            long liquidador,
            Poliza poliza,
            Vehiculo vehiculo,
            Contratante contratante,
            Lesionado lesionado,
            PartePolicial? parte,
            InstitucionSalud institucionSalud,
            Factura factura
            )
        {
            Fecha = fecha;
            TipoEvento = tipoEvento;
            Controlador = controlador;
            Liquidador = liquidador;
            Poliza = poliza;
            Vehiculo = vehiculo;
            Contratante = contratante;
            Lesionado = lesionado;
            Parte = parte;
            InstitucionSalud = institucionSalud;
            Factura = factura;
        }

        public static SiniestroSoap Crear(
            DateTime fecha,
            string tipoEvento,
            string controlador,
            long liquidador,
            Poliza poliza,
            Vehiculo vehiculo,
            Contratante contratante,
            Lesionado lesionado,
            PartePolicial? parte,
            InstitucionSalud institucionSalud,
            Factura factura
            )
        {
            return new SiniestroSoap(
                fecha,
                tipoEvento,
                controlador,
                liquidador,
                poliza,
                vehiculo,
                contratante,
                lesionado,
                parte,
                institucionSalud,
                factura
                );
        }

    }
}
