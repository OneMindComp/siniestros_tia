namespace ICore.Siniestro.Dominio.Entidades.FraudKeeper
{
    /// <summary>
    /// Siniestro.
    /// </summary>
    public class Siniestro : Entidad<long>
    {
        /// <summary>
        /// Fecha de creacion del siniestro.
        /// </summary>
        public DateTime? FechaCreacion { get; private set; }

        /// <summary>
        /// Identificador siniestro + subsiniestro.
        /// </summary>
        public string? IdPublico { get; private set; }

        /// <summary>
        /// Numero del siniestro.
        /// </summary>
        public string? NumeroSiniestro { get; private set; }

        /// <summary>
        /// Fecha que ocurrio el siniestro.
        /// </summary>
        public DateTime? FechaAcontecimiento { get; private set; }

        /// <summary>
        /// Fecha de apertura del siniestro.
        /// </summary>
        public DateTime? FechaApertura { get; private set; }

        /// <summary>
        /// Fecha de notificacion del siniestro.
        /// </summary>
        public DateTime? FechaNotificacion { get; private set; }

        /// <summary>
        /// Descripcion del siniestro.
        /// </summary>
        public string? Descripcion { get; private set; }

        /// <summary>
        /// Causa primaria del siniestro.
        /// </summary>
        public string? CausaPrimaria { get; private set; }

        /// <summary>
        /// Direccion donde ocurrio el siniestro.
        /// </summary>
        public string? Direccion { get; private set; }

        /// <summary>
        /// Pais donde ocurrio del siniestro.
        /// </summary>
        public string? Pais { get; private set; }

        /// <summary>
        /// Indicador de importancia del siniestro.
        /// </summary>
        public bool? TieneImportancia { get; private set; }

        /// <summary>
        /// Cobertura en custion.
        /// </summary>
        public bool? CoberturaEnCuestion { get; private set; }

        /// <summary>
        /// Nota adicional.
        /// </summary>
        public string? NotaAdicional { get; private set; }

        /// <summary>
        /// Administrador del reclamo.
        /// </summary>
        public string? AdministradorReclamos { get; private set; }

        /// <summary>
        /// Numero de Vehiculos.
        /// </summary>
        public int? NumeroDeVehiculos { get; private set; }

        /// <summary>
        /// Numero de Testigos.
        /// </summary>
        public int? NumeroDeTestigos { get; private set; }

        /// <summary>
        /// Total monto reclamado.
        /// </summary>
        public decimal? MontoTotalReclamo { get; private set; }

        /// <summary>
        /// Variable Major line en el sistema.
        /// </summary>
        public string? CodigoGrupoRama { get; private set; }

        /// <summary>
        /// Variables Major line cd + Minor line + Class profile cd.
        /// </summary>
        public string? DescripcionGrupoRama { get; private set; }

        /// <summary>
        /// Informacion Externa.
        /// </summary>
        public List<string>? InformacionExterna { get; private set; }

        /// <summary>
        /// Lenguajes.
        /// </summary>
        public List<string>? Lenguajes { get; private set; }

        /// <summary>
        /// Archivos.
        /// </summary>
        public List<string>? Archivos { get; private set; }

        /// <summary>
        /// Poliza.
        /// </summary>
        public Poliza? Poliza { get; private set; }

        /// <summary>
        /// Exposiciones.
        /// </summary>
        public List<Exposicion>? Exposiciones { get; private set; }

        /// <summary>
        /// Datos adicionales.
        /// </summary>
        public List<DatosAdicionales>? DatosAdicionales { get; private set; }

        /// <summary>
        /// Entidad particpante del siniestro (demandante, Afectado, Liquidador, etc).
        /// </summary>
        public List<Participante>? Participantes { get; private set; }


        //---------------------- AWD --------------------------------//
        /// <summary>
        /// Estado de siniestro.
        /// </summary>
        public string? EstadoSiniestro { get; private set; }

        /// <summary>
        /// Codigo de estado.
        /// </summary>
        public string? CodigoEstado { get; private set; }

        /// <summary>
        /// Nombre ajustador.
        /// </summary>
        public string? Ajustador { get; private set; }

        /// <summary>
        /// Codigo de catastrofe.
        /// </summary>
        public string? CodigoCatastrofe { get; private set; }

        /// <summary>
        /// Fecha reporte de siniestro.
        /// </summary>
        public DateTime? FechaReporteSiniestro { get; private set; }

        /// <summary>
        /// Tipo moneda.
        /// </summary>
        public string? Moneda { get; private set; }

        /// <summary>
        /// Reserva de indemnizacion.
        /// </summary>
        public int? ReservaIndemnizacion { get; private set; }

        /// <summary>
        /// Reserva de honorarios.
        /// </summary>
        public int? ReservaHonorarios { get; private set; }

        /// <summary>
        /// Porcentaje seguidor.
        /// </summary>
        public int? PorcentajeSeguidor { get; private set; }


        private Siniestro() { }

        private Siniestro(
            DateTime? fechaCreacion,
            string? idPublico,
            string? numeroSiniestro,
            DateTime? fechaAcontecimiento,
            DateTime? fechaApertura,
            DateTime? fechaNotificacion,
            string? descripcion,
            string? causaPrimaria,
            string? direccion,
            string? pais,
            bool? hasMatters,
            bool? coberturaEnCuestion,
            string? notasAdicionales,
            string? administradorReclamos,
            int? numeroDeVehiculos,
            int? numeroDeTestigos,
            decimal? montoTotalReclamo,
            List<string>? informacionExterna,
            Poliza? poliza,
            List<Exposicion>? exposiciones,
            List<Participante>? participante,
            List<DatosAdicionales>? dataAdicional,
            List<string>? lenguaje,
            List<string>? archivos,
            string? branchGroupCode,
            string? branchGroupDescription,
            //AWD
            string? estadoSiniestro,
            string? codigoEstado,
            string? ajustador,
            string? codigoCatastrofe,
            DateTime? fechaReporteSiniestro,
            string? moneda,
            int? reservaIndemnizacion,
            int? reservaHonorarios,
            int? porcentajeSeguidor
            )
        {
            FechaCreacion = fechaCreacion;
            IdPublico = idPublico;
            NumeroSiniestro = numeroSiniestro;
            FechaAcontecimiento = fechaAcontecimiento;
            FechaApertura = fechaApertura;
            FechaNotificacion = fechaNotificacion;
            Descripcion = descripcion;
            CausaPrimaria = causaPrimaria;
            Direccion = direccion;
            Pais = pais;
            TieneImportancia = hasMatters;
            CoberturaEnCuestion = coberturaEnCuestion;
            NotaAdicional = notasAdicionales;
            AdministradorReclamos = administradorReclamos;
            NumeroDeVehiculos = numeroDeVehiculos;
            NumeroDeTestigos = numeroDeTestigos;
            MontoTotalReclamo = montoTotalReclamo;
            InformacionExterna = informacionExterna;
            Poliza = poliza;
            Exposiciones = exposiciones;
            Participantes = participante;
            DatosAdicionales = dataAdicional;
            Lenguajes = lenguaje;
            Archivos = archivos;
            CodigoGrupoRama = branchGroupCode;
            DescripcionGrupoRama = branchGroupDescription;
            //AWD
            EstadoSiniestro = estadoSiniestro;
            CodigoEstado = codigoEstado;
            Ajustador = ajustador;
            CodigoCatastrofe = codigoCatastrofe;
            FechaReporteSiniestro = fechaReporteSiniestro;
            Moneda = moneda;
            ReservaIndemnizacion = reservaIndemnizacion;
            ReservaHonorarios = reservaHonorarios;
            PorcentajeSeguidor = porcentajeSeguidor;
        }

        public static Siniestro Crear(
            DateTime? fechaCreacion,
            string? idPublico,
            string? numeroSiniestro,
            DateTime? fechaAcontecimiento,
            DateTime? fechaApertura,
            DateTime? fechaNotificacion,
            string? descripcion,
            string? causaPrimaria,
            string? direccion,
            string? pais,
            bool? hasMatters,
            bool? coberturaEnCuestion,
            string? notasAdicionales,
            string? administradorReclamos,
            int? numeroDeVehiculos,
            int? numeroDeTestigos,
            decimal? montoTotalReclamo,
            List<string>? informacionExterna,
            Poliza? poliza,
            List<Exposicion>? exposiciones,
            List<Participante> participantes,
            List<DatosAdicionales>? dataAdicional,
            List<string>? lenguaje,
            List<string>? archivos,
            string? branchGroupCode,
            string? branchGroupDescription,
            string? estadoSiniestro,
            string? codigoEstado,
            string? ajustador,
            string? codigoCatastrofe,
            DateTime? fechaReporteSiniestro,
            string? moneda,
            int? reservaIndemnizacion,
            int? reservaHonorarios,
            int? porcentajeSeguidor
            )
        {
            return new Siniestro(
                fechaCreacion,
                idPublico,
                numeroSiniestro,
                fechaAcontecimiento,
                fechaApertura,
                fechaNotificacion,
                descripcion,
                causaPrimaria,
                direccion,
                pais,
                hasMatters,
                coberturaEnCuestion,
                notasAdicionales,
                administradorReclamos,
                numeroDeVehiculos,
                numeroDeTestigos,
                montoTotalReclamo,
                informacionExterna,
                poliza,
                exposiciones,
                participantes,
                dataAdicional,
                lenguaje,
                archivos,
                branchGroupCode,
                branchGroupDescription,
                //AWD
                estadoSiniestro,
                codigoEstado,
                ajustador,
                codigoCatastrofe,
                fechaReporteSiniestro,
                moneda,
                reservaIndemnizacion,
                reservaHonorarios,
                porcentajeSeguidor
                );
        }

        public void AgregarParticipantes(List<Participante> participantes)
        {
            Participantes?.AddRange(participantes);
        }

        public void AgregarExposiciones(List<Exposicion> exposiciones)
        {
            Exposiciones?.AddRange(exposiciones);
        }
    }
}
