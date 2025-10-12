using ICore.Siniestro.Aplicacion.Contratos.Persistencia;
using ICore.Siniestro.Aplicacion.Dtos.Requests;
using ICore.Siniestro.Aplicacion.Dtos.Responses;
using ICore.Siniestro.Dominio.Entidades.Falabella;
using MediatR;
using Microsoft.Extensions.Logging;

namespace ICore.Siniestro.Aplicacion.Comandos
{
    /// <summary>
    /// Crea siniestro de falabella.
    /// </summary>
    public class CrearOrdenTrabajoCommand : IRequest<OrdenTrabajoResponse>
    {
        /// <summary>
        /// Request con data requerida para crear siniestro.
        /// </summary>
        public OrdenTrabajoRequest OrdenTrabajo { get; set; } = default!;
    }

    /// <summary>
    /// Maneja la logica para crear siniestro de falabella.
    /// </summary>
    public class CrearSiniestroFalabellaCommandHandler : IRequestHandler<CrearOrdenTrabajoCommand, OrdenTrabajoResponse>
    {
        private readonly ISiniestroContract _siniestroContract;
        private readonly ILogger<CrearSiniestroFalabellaCommandHandler> _logger;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="siniestroContract"></param>
        /// <param name="logger"></param>
        public CrearSiniestroFalabellaCommandHandler(
            ISiniestroContract siniestroContract,
            ILogger<CrearSiniestroFalabellaCommandHandler> logger
            )
        {
            _siniestroContract = siniestroContract;
            _logger = logger;
        }

        /// <summary>
        /// Implementa la logica para crear un siniestro de falabella en TIA.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<OrdenTrabajoResponse> Handle(CrearOrdenTrabajoCommand request, CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation("Se inicia el metodo CrearSiniestroFalabellaCommand.");
                var pgeFalabella = request.OrdenTrabajo;

                var personaFalabella = ICore.Siniestro.Dominio.Entidades.Falabella.Persona.Crear();

                personaFalabella.AsignarContacto(pgeFalabella.C28, pgeFalabella.C26);
                personaFalabella.AsignarDireccionComercial(pgeFalabella.C29);
                personaFalabella.AsignarDatosPersonales(null, pgeFalabella.C24, null, null, null, null);



                var riesgoFalabella = Riesgo.Crear(
                    Convert.ToInt32(pgeFalabella.RiskNo), null, null, null, pgeFalabella.SubriskNo, pgeFalabella.FiledBy);

                List<Riesgo> riesgosFalabella = new();
                riesgosFalabella.Add(riesgoFalabella);



                var exposicion = ICore.Siniestro.Dominio.Entidades.Falabella.Exposicion.Crear();
                exposicion.AsignarRiesgos(riesgosFalabella);

                List<Exposicion> exposicionFalabella = new();
                exposicionFalabella.Add(exposicion);



                var participante = Participante.Crear(null, personaFalabella, null);

                List<Participante> participantesFalabella = new();
                participantesFalabella.Add(participante);



                var siniestroFalabella = ICore.Siniestro.Dominio.Entidades.Falabella.Siniestro.Crear();

                siniestroFalabella.AsignarDatosC(personaFalabella.DireccionComercialCliente, pgeFalabella.C903);
                siniestroFalabella.AsignarPerdidaBono(pgeFalabella.LossOfBonus);
                siniestroFalabella.AsignarFechas(Convert.ToDateTime(pgeFalabella.IncidentDate), Convert.ToDateTime(pgeFalabella.NotificationDate));
                siniestroFalabella.AsignarEvento(pgeFalabella.EventType, pgeFalabella.CauseType, pgeFalabella.SubcauseType);
                siniestroFalabella.AsignarExposiciones(exposicionFalabella);
                siniestroFalabella.AsignarGestor(pgeFalabella.Handler);
                siniestroFalabella.AsignarDescripcion(pgeFalabella.Description);
                siniestroFalabella.AsignarEstado(pgeFalabella.Status);
                siniestroFalabella.AsignarEsFechaExacta(pgeFalabella.IsExactIncidentDate);
                siniestroFalabella.AsignarInformante(pgeFalabella.InformerType, pgeFalabella.InformerName);
                siniestroFalabella.AsignarNumeroCertificado(pgeFalabella.CertificateNo);
                siniestroFalabella.AsignarNumeroRegistroCompania(pgeFalabella.CompanyRegistrationNo);
                siniestroFalabella.AsignarParticipantes(participantesFalabella);
                siniestroFalabella.AsignarTipoLugar(pgeFalabella.PlaceType);
                siniestroFalabella.AsignarDireccion(pgeFalabella.Address);

                var respuestaTia = await _siniestroContract.CrearSiniestroFalabella(siniestroFalabella);

                var res = new OrdenTrabajoResponse()
                {
                    NumeroSiniestro = respuestaTia.NumeroSiniestro
                };

                return res;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error en el envio de datos a TIA {Message}", ex.Message);
                throw new Sbins.Comunes.Excepciones.ApplicationException(ex.Message);
            }
        }
    }
}
