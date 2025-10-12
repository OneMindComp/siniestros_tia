namespace ICore.Siniestro.Dominio.Entidades.Falabella
{
    /// <summary>
    /// Siniestro.
    /// </summary>
    public class Siniestro : Entidad<long>
    {
        // Propiedades de Siniestro
        public DateTime? FechaAcontecimiento { get; private set; }
        public DateTime? FechaNotificacion { get; private set; }
        public string? Descripcion { get; private set; }
        public string? Direccion { get; private set; }

        public string? NumeroCertificado { get; private set; }
        public string? NumeroRegistroCompania { get; private set; }

        public string? EstadoSiniestro { get; private set; }

        public string? TipoEvento { get; private set; }
        public string? TipoCausa { get; private set; }
        public string? SubTipoCausa { get; private set; }

        public string? EsFechaExacta { get; private set; }
        public string? TipoLugar { get; private set; }
        public string? Gestor { get; private set; }
        public string? TipoInformante { get; private set; }
        public string? NombreInformante { get; private set; }

        public string? PerdidaBono { get; private set; }
        public string? C29 { get; private set; }
        public string? C903 { get; private set; }

        // Colecciones relacionadas
        public List<Exposicion>? Exposiciones { get; private set; }
        public List<Participante>? Participantes { get; private set; }

        private Siniestro() { }


        // Metodos de asignacion de propiedades
        public void AsignarFechas(DateTime? fechaAcontecimiento, DateTime? fechaNotificacion)
        {
            FechaAcontecimiento = fechaAcontecimiento;
            FechaNotificacion = fechaNotificacion;
        }

        public void AsignarDescripcion(string? descripcion)
        {
            Descripcion = descripcion;
        }

        public void AsignarDireccion(string? direccion)
        {
            Direccion = direccion;
        }

        public void AsignarEstado(string? estado)
        {
            EstadoSiniestro = estado;
        }

        public void AsignarNumeroCertificado(string? numeroCertificado)
        {
            NumeroCertificado = numeroCertificado;
        }

        public void AsignarNumeroRegistroCompania(string? numeroRegistroCompania)
        {
            NumeroRegistroCompania = numeroRegistroCompania;
        }

        public void AsignarEvento(string? tipoEvento, string? tipoCausa, string? subTipoCausa)
        {
            TipoEvento = tipoEvento;
            TipoCausa = tipoCausa;
            SubTipoCausa = subTipoCausa;
        }

        public void AsignarEsFechaExacta(string? esFechaExacta)
        {
            EsFechaExacta = esFechaExacta;
        }

        public void AsignarTipoLugar(string? tipoLugar)
        {
            TipoLugar = tipoLugar;
        }

        public void AsignarGestor(string? gestor)
        {
            Gestor = gestor;
        }

        public void AsignarInformante(string? tipoInformante, string? nombreInformante)
        {
            TipoInformante = tipoInformante;
            NombreInformante = nombreInformante;
        }

        public void AsignarPerdidaBono(string? perdidaBono)
        {
            PerdidaBono = perdidaBono;
        }

        public void AsignarDatosC(string? c29, string? c903)
        {
            C29 = c29;
            C903 = c903;
        }

        public void AsignarExposiciones(List<Exposicion> exposiciones)
        {
            Exposiciones = exposiciones;
        }

        public void AsignarParticipantes(List<Participante> participantes)
        {
            Participantes = participantes;
        }

        // Metodo estatico para crear una instancia inicial con valores por defecto
        public static Siniestro Crear()
        {
            return new Siniestro();
        }
    }
}
