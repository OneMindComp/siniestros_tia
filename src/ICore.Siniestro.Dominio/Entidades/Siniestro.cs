using ICore.Siniestro.Dominio.Entidades.Awd;

namespace ICore.Siniestro.Dominio.Entidades
{
    public class Siniestro : Entidad<long>
    {
        public int NumeroSiniestro { get; private set; } = default!;
        public string EstadoSiniestro { get; private set; } = default!;
        public string CodigoEstado { get; private set; } = default!;
        public string Ajustador { get; private set; } = default!;
        public DateTime FechaPerdida { get; private set; }
        public string LugarPerdida { get; private set; } = default!;
        public string DescripcionPerdida { get; private set; } = default!;
        public string CodigoCatastrofe { get; private set; } = default!;
        public DateTime FechaReporteSiniestro { get; private set; }
        public DateTime FechaCreacion { get; private set; }
        public string Moneda { get; private set; } = default!;
        public int ReservaIndemnizacion { get; private set; }
        public int ReservaHonorarios { get; private set; }
        public int PorcentajeSeguidor { get; private set; }
        public Afectado Afectado { get; private set; } = default!;
        public Liquidador Liquidador { get; private set; } = default!;
        public Poliza Poliza { get; private set; } = default!;


        private Siniestro()
        {
        }

        private Siniestro(
            int numeroSiniestro,
            string estadoSiniestro,
            string codigoEstado,
            string ajustador,
            DateTime fechaPerdida,
            string lugarPerdida,
            string descripcionPerdida,
            string codigoCatastrofe,
            DateTime fechaReporteSiniestro,
            DateTime fechaCreacion,
            string moneda,
            int reservaIndemnizacion,
            int reservaHonorarios,
            int porcentajeSeguidor,
            Poliza poliza,
            Afectado afectado,
            Liquidador liquidador
            )
        {
            NumeroSiniestro = numeroSiniestro;
            EstadoSiniestro = estadoSiniestro;
            CodigoEstado = codigoEstado;
            FechaPerdida = fechaPerdida;
            Ajustador = ajustador;
            LugarPerdida = lugarPerdida;
            DescripcionPerdida = descripcionPerdida;
            CodigoCatastrofe = codigoCatastrofe;
            FechaReporteSiniestro = fechaReporteSiniestro;
            FechaCreacion = fechaCreacion;
            Moneda = moneda;
            ReservaIndemnizacion = reservaIndemnizacion;
            ReservaHonorarios = reservaHonorarios;
            PorcentajeSeguidor = porcentajeSeguidor;
            Poliza = poliza;
            Afectado = afectado;
            Liquidador = liquidador;
        }

        public static Siniestro Crear(
            int numeroSiniestro,
            string estadoSiniestro,
            string codigoEstado,
            string ajustador,
            DateTime fechaPerdida,
            string lugarPerdida,
            string descripcionPerdida,
            string codigoCatastrofe,
            DateTime fechaReporteSiniestro,
            DateTime fechaCreacion,
            string moneda,
            int reservaIndemnizacion,
            int reservaHonorarios,
            int porcentajeSeguidor,
            Poliza poliza,
            Afectado afectado,
            Liquidador liquidador
            )
        {
            return new Siniestro(
                numeroSiniestro,
                estadoSiniestro,
                codigoEstado,
                ajustador,
                fechaPerdida,
                lugarPerdida,
                descripcionPerdida,
                codigoCatastrofe,
                fechaReporteSiniestro,
                fechaCreacion,
                moneda,
                reservaIndemnizacion,
                reservaHonorarios,
                porcentajeSeguidor,
                poliza,
                afectado,
                liquidador
                );
        }
    }
}
