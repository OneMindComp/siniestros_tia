using ICore.Siniestro.Aplicacion.Contratos.Persistencia;
using ICore.Siniestro.Aplicacion.Dtos.Requests;
using ICore.Siniestro.Aplicacion.Dtos.Responses;
using ICore.Siniestro.Dominio.Entidades.Falabella;
using MediatR;
using Microsoft.Extensions.Logging;

namespace ICore.Siniestro.Aplicacion.Comandos
{
    /// <summary>
    /// Envia el courier de falabella.
    /// </summary>
    public class EnviarCourierCommand : IRequest<OrdenTrabajoResponse>
    {
        /// <summary>
        /// Request con data requerida para enviar el courier.
        /// </summary>
        public EnviarCourierRequest Courier { get; set; } = default!;
    }

    /// <summary>
    /// Maneja la logica para enviar el courier.
    /// </summary>
    public class EnviarCourierCommandHandler : IRequestHandler<EnviarCourierCommand, OrdenTrabajoResponse>
    {
        private readonly ISiniestroContract _siniestroContract;
        private readonly ILogger<EnviarCourierCommandHandler> _logger;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="siniestroContract"></param>
        /// <param name="logger"></param>
        public EnviarCourierCommandHandler(ISiniestroContract siniestroContract, ILogger<EnviarCourierCommandHandler> logger)
        {
            _siniestroContract = siniestroContract;
            _logger = logger;
        }

        /// <summary>
        /// Implementa la logica para enviar el courier.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<OrdenTrabajoResponse> Handle(EnviarCourierCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Se inicia el metodo EnviarCourierCommandHandler.");

            var courierFalabella = request.Courier;

            var courier = Courier.Crear(
                numeroSocio: courierFalabella.MemberNo,
                numeroCertificado: courierFalabella.CertificateNo,
                numeroOrdenTrabajo: courierFalabella.ExtWoNo,
                fechaEvento: courierFalabella.EventDate,
                idTransaccion: courierFalabella.TransactionId,
                idMensaje: courierFalabella.MessageId);

            var respuestaTia = await _siniestroContract.EnviarCourierFalabella(courier);

            var respuesta = new OrdenTrabajoResponse()
            {
                NumeroSiniestro = respuestaTia.NumeroSiniestro
            };

            return respuesta;
        }
    }
}
