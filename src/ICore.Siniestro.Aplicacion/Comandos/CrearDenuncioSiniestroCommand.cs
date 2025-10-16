using AutoMapper;
using ICore.Siniestro.Aplicacion.Contratos.Persistencia;
using ICore.Siniestro.Aplicacion.Dtos.Requests.Denuncio;
using ICore.Siniestro.Aplicacion.Dtos.Responses.Soap;
using ICore.Siniestro.Aplicacion.Mapeadores;
using ICore.Siniestro.Dominio.Entidades.Denuncio;
using ICore.Siniestro.Dominio.Entidades.Soap;
using MediatR;
using Microsoft.Extensions.Logging;

namespace ICore.Siniestro.Aplicacion.Comandos
{
    /// <summary>
    /// Crea siniestro.
    /// </summary>
    public class CrearDenuncioSiniestroCommand : IRequest<SiniestroPropuestoResponse>
    {
        /// <summary>
        /// Request con data requerida para crear siniestro.
        /// </summary>
        public DenuncioSiniestroRequest Request { get; set; } = default!;
    }
    /// <summary>
    /// Maneja la logica para crear siniestro.
    /// </summary>
    public class CrearDenuncioSiniestroCommandHandler : IRequestHandler<CrearDenuncioSiniestroCommand, SiniestroPropuestoResponse>
    {
        private readonly ISiniestroContract _siniestro;
        private readonly IMapper _mapper;
        private readonly ILogger<CrearDenuncioSiniestroCommandHandler> _logger;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="siniestro"></param>
        /// <param name="mapper"></param>
        /// <param name="logger"></param>
        public CrearDenuncioSiniestroCommandHandler(ISiniestroContract siniestro, IMapper mapper, ILogger<CrearDenuncioSiniestroCommandHandler> logger)
        {
            _siniestro = siniestro;
            _mapper = mapper;
            _logger = logger;
        }
        /// <summary>
        /// Implementa la logica para crear un siniestro.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="Sbins.Comunes.Excepciones.ApplicationException"></exception>
        public async Task<SiniestroPropuestoResponse> Handle(CrearDenuncioSiniestroCommand request, CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation("Se inicia el metodo CrearDenuncioSiniestroCommand ");

                //var errores = _validacionDenuncios.Validar(request.Request);

                //if (errores.Count > 0)
                //{
                //    throw new InvalidOperationException($"Errores de validacion: {string.Join(", ", errores)}");
                //}

                SiniestroPropuesto response;

                switch (request.Request)
                {
                    case DenuncioSiniestroSoapRequest soap:
                        DenuncioSiniestroSoap denuncio = DenuncioSoapMapper.MapearDesdeRequest(soap);
                        response = await _siniestro.CrearSiniestro(denuncio);
                        break;

                    default:
                        throw new InvalidOperationException($"Tipo de denuncio no soportado: {request.Request.GetType().Name}");
                }
                var respuesta = _mapper.Map<SiniestroPropuestoResponse>(response);

                return respuesta;

            }
            catch (Exception ex)
            {

                throw new InvalidOperationException("An error occurred in CrearSiniestroCommandHandler", ex);

            }
        }


    }
}
