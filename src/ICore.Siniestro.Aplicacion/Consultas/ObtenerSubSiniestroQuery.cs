using ICore.Siniestro.Aplicacion.Contratos.Persistencia;
using ICore.Siniestro.Aplicacion.Dtos.Requests;
using ICore.Siniestro.Aplicacion.Dtos.Responses;
using MediatR;
using Microsoft.Extensions.Logging;

namespace ICore.Siniestro.Aplicacion.Consultas
{
    /// <summary>
    /// Obtiene subsiniestro.
    /// </summary>
    public class ObtenerSubSiniestroQuery : IRequest<SubSiniestroResponse>
    {
        /// <summary>
        /// Datos del subsiniestro.
        /// </summary>
        public SubSiniestroRequest Request { get; set; } = default!;

    }

    /// <summary>
    /// Maneja la logica para consultar los sub-siniestros.
    /// </summary>
    public class ObtenerSubSiniestroQueryHandler : IRequestHandler<ObtenerSubSiniestroQuery, SubSiniestroResponse>
    {
        private readonly ISiniestroContract _siniestroContract;
        private readonly ILogger<ObtenerSubSiniestroQueryHandler> _logger;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="siniestroContract"></param>
        /// <param name="logger"></param>
        public ObtenerSubSiniestroQueryHandler(ISiniestroContract siniestroContract, ILogger<ObtenerSubSiniestroQueryHandler> logger)
        {
            _siniestroContract = siniestroContract;
            _logger = logger;
        }

        /// <summary>
        /// Implementa la logica para consultar los sub-siniestros.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="ApplicationException"></exception>
        public async Task<SubSiniestroResponse> Handle(ObtenerSubSiniestroQuery request, CancellationToken cancellationToken)
        {
            long? numeroCaso = null;
            try
            {
                if (request.Request.NumeroSubSiniestro != null)
                {
                    numeroCaso = await _siniestroContract.ObtenerNumeroCaso(request.Request.NumeroSubSiniestro);
                }
                else
                {
                    throw new ArgumentException("El numero de subsiniestro no puede ser vacio o nulo");
                }

                return new SubSiniestroResponse() { NumeroCaso = numeroCaso };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener numero de caso de un subsiniestro");
                throw new Sbins.Comunes.Excepciones.ApplicationException("Error al obtener el numero de caso del subsiniestro.");
            }
        }
    }
}
