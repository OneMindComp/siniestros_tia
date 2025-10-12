using AutoMapper;
using ICore.Siniestro.Aplicacion.Contratos.Core;
using ICore.Siniestro.Aplicacion.Dtos.Responses;
using MediatR;
using Microsoft.Extensions.Logging;

namespace ICore.Siniestro.Aplicacion.Consultas
{
    /// <summary>
    /// Obtiene los siniestros Awd desde Tia.
    /// </summary>
    public class ObtenerSiniestroAwdQuery : IRequest<List<ObtenerSiniestroAwdResponse>>
    {
        /// <summary>
        /// Numero de siniestro.
        /// </summary>
        public string NumeroSiniestro { get; set; } = default!;

    }

    /// <summary>
    /// Maneja la logica para consultar los siniestros.
    /// </summary>
    public class ObtenerSiniestroQueryHandler : IRequestHandler<ObtenerSiniestroAwdQuery, List<ObtenerSiniestroAwdResponse>>
    {
        private readonly ISiniestroContract _siniestro;
        private readonly ILogger<ObtenerSiniestroQueryHandler> _logger;
        private readonly IMapper _mapper;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="siniestro"></param>
        /// <param name="logger"></param>
        /// <param name="mapper"></param>
        public ObtenerSiniestroQueryHandler(ISiniestroContract siniestro, ILogger<ObtenerSiniestroQueryHandler> logger, IMapper mapper)
        {
            _siniestro = siniestro;
            _logger = logger;
            _mapper = mapper;
        }

        /// <summary>
        /// Implementa la logica para consultar los siniestros
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        public async Task<List<ObtenerSiniestroAwdResponse>> Handle(ObtenerSiniestroAwdQuery request, CancellationToken cancellationToken)
        {
            List<ObtenerSiniestroAwdResponse> listaSiniestros = new();

            try
            {
                string numeroSiniestro = request.NumeroSiniestro;
                var siniestros = await _siniestro.ObtenerSiniestros(numeroSiniestro);

                foreach (var siniestro in siniestros)
                {
                    var siniestroAWD = _mapper.Map<ObtenerSiniestroAwdResponse>(siniestro);

                    listaSiniestros.Add(siniestroAWD);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Hubo un error al tratar los siniestros awd");
                throw new InvalidOperationException("No se pudieron tratar los siniestros awd debido a un error.", ex);

            }
            return listaSiniestros;
        }
    }
}

