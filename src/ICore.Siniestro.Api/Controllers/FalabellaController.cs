using ICore.Siniestro.Api.Controllers.Base;
using ICore.Siniestro.Aplicacion.Comandos;
using ICore.Siniestro.Aplicacion.Consultas;
using ICore.Siniestro.Aplicacion.Dtos.Requests;
using ICore.Siniestro.Aplicacion.Dtos.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Sbins.Comunes.Api.Firmas;

namespace ICore.Siniestro.Api.Controllers
{
    /// <summary>
    /// Controlador para el envio de ordenes de trabajo de falabella a Tia.
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    public class FalabellaController : CustomControllerBase
    {
        private readonly IMediator _mediator;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="mediator"></param>
        public FalabellaController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Obtiene estado de servicio tecnico desde Tia para Falabella.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("estado")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(ApiOkResponse<EstadoServicioTecnicoResponse>), StatusCodes.Status200OK)]
        public async Task<IActionResult> EstadoServicioTecnico([FromQuery] EstadoServicioTecnicoRequest request)
        {
            var apiRespuesta = new ObtenerEstadoServicioTecnicoQuery()
            {
                RequestEstado = request
            };

            var resultado = await _mediator.Send(apiRespuesta);

            return ObtenerRespuesta(resultado);
        }

        /// <summary>
        /// Crea orden de trabajo de falabella en Tia.
        /// </summary>
        /// <param name="request"></param> 
        [HttpPost("orden-trabajo")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(ApiOkResponse<OrdenTrabajoResponse>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Crear([FromBody] OrdenTrabajoRequest request)
        {
            var crear = new CrearOrdenTrabajoCommand
            {
                OrdenTrabajo = request
            };

            var resultado = await _mediator.Send(crear);
            return ObtenerRespuesta(resultado);
        }

        /// <summary>
        /// Envia courier de orden de trabajo falabella en Tia.
        /// </summary>
        /// <param name="request"></param> 
        [HttpPost]
        [Route("courier")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(ApiOkResponse<OrdenTrabajoResponse>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Crear([FromBody] EnviarCourierRequest request)
        {
            var crear = new EnviarCourierCommand
            {
                Courier = request
            };

            var resultado = await _mediator.Send(crear);
            return ObtenerRespuesta(resultado);
        }
    }
}
