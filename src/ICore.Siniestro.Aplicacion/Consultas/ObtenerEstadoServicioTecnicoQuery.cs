using AutoMapper;
using ICore.Siniestro.Aplicacion.Contratos.Core;
using ICore.Siniestro.Aplicacion.Dtos.Requests;
using ICore.Siniestro.Aplicacion.Dtos.Responses;
using MediatR;
using Microsoft.Extensions.Logging;

namespace ICore.Siniestro.Aplicacion.Consultas
{
    /// <summary>
    /// Obtiene el estado del servicio tecnico desde Tia.
    /// </summary>
    public class ObtenerEstadoServicioTecnicoQuery : IRequest<EstadoServicioTecnicoResponse>
    {
        /// <summary>
        /// Datos del estado. 
        /// </summary>
        public EstadoServicioTecnicoRequest RequestEstado { get; set; } = default!;
    }

    /// <summary>
    /// Maneja la logica para obtener el estado del servicio tecnico desde Tia.
    /// </summary>
    public class ObtenerEstadoServicioTecnicoQueryHandler : IRequestHandler<ObtenerEstadoServicioTecnicoQuery, EstadoServicioTecnicoResponse>
    {
        private readonly ISiniestroContract _siniestroContract;
        private readonly ILogger<ObtenerEstadoServicioTecnicoQueryHandler> _logger;
        private readonly IMapper _mapper;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="siniestroContract"></param>
        /// <param name="logger"></param>
        /// <param name="mapper"></param>
        public ObtenerEstadoServicioTecnicoQueryHandler(
            ISiniestroContract siniestroContract,
            ILogger<ObtenerEstadoServicioTecnicoQueryHandler> logger,
            IMapper mapper
            )
        {
            _siniestroContract = siniestroContract;
            _logger = logger;
            _mapper = mapper;
        }

        /// <summary>
        /// Implementa la logica para obtener el estado del servicio tecnico desde Tia.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<EstadoServicioTecnicoResponse> Handle(ObtenerEstadoServicioTecnicoQuery request, CancellationToken cancellationToken)
        {
            try
            {
                string numeroCaso = request.RequestEstado.ClaimCaseNo.ToString();

                var estadoRespuesta = await _siniestroContract.ObtenerEstadoOrdenTrabajo(numeroCaso);

                var estado = estadoRespuesta.FirstOrDefault();

                var estadoOrden = _mapper.Map<EstadoServicioTecnicoResponse>(estado);

                return estadoOrden;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error en ObtenerEstadoServicioTecnicoQueryHandler: {Message}", ex.Message);
                throw new Sbins.Comunes.Excepciones.ApplicationException(ex.Message);
            }
        }
    }
}
