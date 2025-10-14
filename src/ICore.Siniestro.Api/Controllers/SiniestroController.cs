using ICore.Siniestro.Api.Controllers.Base;
using ICore.Siniestro.Aplicacion.Comandos;
using ICore.Siniestro.Aplicacion.Consultas;
using ICore.Siniestro.Aplicacion.Dtos.Requests;
using ICore.Siniestro.Aplicacion.Dtos.Requests.Denuncio;
using ICore.Siniestro.Aplicacion.Dtos.Requests.Soap;
using ICore.Siniestro.Aplicacion.Dtos.Responses;
using ICore.Siniestro.Aplicacion.Dtos.Responses.Soap;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Sbins.Comunes.Api.Firmas;

namespace ICore.Siniestro.Api.Controllers
{
    /// <summary>
    /// Controlador para siniestros de Tia.
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    public class SiniestroController : CustomControllerBase
    {
        private readonly IMediator _mediator;

        /// <summary>
        /// Constructor.
        /// </summary>
        public SiniestroController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Crea siniestros en Tia.
        /// </summary>
        /// <param name="request"></param> 
        [HttpPost]
        [Produces("application/json")]
        [ProducesResponseType(typeof(ApiOkResponse<SiniestroPropuestoResponse>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Crear([FromBody] SiniestroSoapRequest request)
        {
            var crear = new CrearSiniestroCommand
            {
                Request = request
            };
            var resultado = await _mediator.Send(crear);
            return ObtenerRespuesta(resultado);
        }

        /// <summary>
        /// Obtiene siniestros desde Tia para AWD.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{NumeroSiniestro}")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(ApiOkResponse<List<ObtenerSiniestroAwdResponse>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Obtener([FromRoute] SiniestroRequest request)
        {
            var apiRespuesta = new ObtenerSiniestroAwdQuery()
            {
                NumeroSiniestro = request.NumeroSiniestro
            };

            var resultado = await _mediator.Send(apiRespuesta);

            return ObtenerRespuesta(resultado);
        }

        /// <summary>
        /// Obtiene siniestros desde Tia para FraudKeeper.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("SiniestrosTia")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(ApiOkResponse<List<ObtenerSiniestroFraudKeeperResponse>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> ObtenerSiniestro([FromQuery] SiniestroFraudKeeperRequest request)
        {
            var apiRespuesta = new ObtenerSiniestroFraudKeeperQuery()
            {
                Request = request
            };

            var resultado = await _mediator.Send(apiRespuesta);

            return ObtenerRespuesta(resultado);
        }

        /// <summary>
        /// Obtiene subsiniestro TIA para FraudKeeper.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("sub")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(ApiOkResponse<SubSiniestroResponse>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Obtener([FromQuery] SubSiniestroRequest request)
        {
            var apiRespuesta = new ObtenerSubSiniestroQuery()
            {
                Request = request
            };

            var resultado = await _mediator.Send(apiRespuesta);

            return ObtenerRespuesta(resultado);
        }

        /// <summary>
        /// Guarda archivo de siniestro en Core.
        /// </summary>
        /// <param name="queryParams"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("archivo")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(ApiOkResponse<GuardarArchivoResponse>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GuardarArchivo([FromForm] GuardarArchivoRequest queryParams)
        {
            var request = new GuardarArchivoCommand() { Request = queryParams };
            var respuesta = await _mediator.Send(request);

            return ObtenerRespuesta(respuesta);
        }

        /// <summary>
        /// Guarda archivo de subsiniestro en Core.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("sub/archivo")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(ApiOkResponse<GuardarArchivoSubsiniestroResponse>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GuardarArchivoSubsiniestro([FromForm] GuardarArchivoSubsiniestroRequest request)
        {
            var crear = new GuardarArchivoSubsiniestroCommand() { Request = request };
            var respuesta = await _mediator.Send(crear);

            return ObtenerRespuesta(respuesta);
        }

        /// <summary>
        /// Crea un denuncio de siniestro unificado en Tia
        /// </summary>
        /// <param name="request">Datos del denuncio de siniestro</param>
        /// <returns>Respuesta con el resultado de la creacion del siniestro</returns>
        [HttpPost]
        [Produces("application/json")]
        [ProducesResponseType(typeof(ApiOkResponse<SiniestroPropuestoResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Crear([FromBody] DenuncioSiniestroRequest request)
        {
            var crear = new CrearDenuncioSiniestroCommand
            {
                Request = request
            };
            var resultado = await _mediator.Send(crear);
            return ObtenerRespuesta(resultado);
        }
    }
}
