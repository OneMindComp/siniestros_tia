using ICore.Siniestro.Aplicacion.Contratos.Persistencia;
using ICore.Siniestro.Aplicacion.Dtos.Requests;
using ICore.Siniestro.Aplicacion.Dtos.Responses;
using ICore.Siniestro.Dominio.Entidades;
using MediatR;
using Microsoft.Extensions.Logging;

namespace ICore.Siniestro.Aplicacion.Comandos
{
    /// <summary>
    /// Guarda un archivo de siniestro en el core.
    /// </summary>
    public class GuardarArchivoCommand : IRequest<GuardarArchivoResponse>
    {
        /// <summary>
        /// Request con data requerida para guardar archivo de siniestro.
        /// </summary>
        public GuardarArchivoRequest Request { get; set; } = default!;
    }

    /// <summary>
    /// Maneja la logica para guardar archivo de siniestro en el core.
    /// </summary>
    public class GuardarArchivoCommandHandler : IRequestHandler<GuardarArchivoCommand, GuardarArchivoResponse>
    {
        private readonly ISiniestroContract _siniestroContract;
        private readonly IArchivoContract _archivoContract;
        private readonly ILogger<GuardarArchivoCommandHandler> _logger;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="archivoContract"></param>
        /// <param name="siniestroContract"></param>
        /// <param name="logger"></param>
        public GuardarArchivoCommandHandler(IArchivoContract archivoContract, ISiniestroContract siniestroContract, ILogger<GuardarArchivoCommandHandler> logger)
        {
            _archivoContract = archivoContract;
            _siniestroContract = siniestroContract;
            _logger = logger;
        }

        /// <summary>
        /// Implementa la logica para guardar archivo de siniestro en el core.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="Sbins.Comunes.Excepciones.ApplicationException"></exception>
        public async Task<GuardarArchivoResponse> Handle(GuardarArchivoCommand request, CancellationToken cancellationToken)
        {
            try
            {
                //Obtiene numero de caso
                _logger.LogInformation("Iniciando proceso de guardado de archivo de siniestro numero: {NumeroSiniestro}", request.Request.NumeroSiniestro);
                long? numeroCaso = await _siniestroContract.ObtenerNumeroCaso(request.Request.NumeroSiniestro);
                if (numeroCaso == null) {
                    _logger.LogError("No se encuentra el caso asociado al siniestro numero: {NumeroSiniestro}", request.Request.NumeroSiniestro);
                    throw new ArgumentException("No se encuentra el caso asociado al siniestro numero: {NumeroSubsiniestro}",request.Request.NumeroSiniestro.ToString());
                }

                Archivo archivo = Archivo.Crear(request.Request.NumeroSiniestro,numeroCaso);
                archivo.EstablecerContenido(request.Request.Data);
                bool respuesta = await _archivoContract.GuardarArchivo(archivo);
                var guardaArchivoResponse = new GuardarArchivoResponse();
                guardaArchivoResponse.NumeroSiniestro = request.Request.NumeroSiniestro.ToString();
                guardaArchivoResponse.IdCaso = numeroCaso.ToString()!;
                guardaArchivoResponse.ArchivoGuardado = respuesta;
                if (respuesta)
                {
                    _logger.LogInformation("Archivo de siniestro {NumeroSiniestro} guardado correctamente.", request.Request.NumeroSiniestro);
                    guardaArchivoResponse.Mensaje = "Archivo de siniestro guardado correctamente.";
                }
                else
                {
                    _logger.LogError("Error al guardar el archivo de siniestro {NumeroSiniestro}.", request.Request.NumeroSiniestro);
                    guardaArchivoResponse.Mensaje = "Error, no se pudo guardar el archivo de siniestro.";
                }
                return guardaArchivoResponse;

            }
            catch (Exception ex)
            {
                throw new Sbins.Comunes.Excepciones.ApplicationException(ex.Message);
            }
        }
    }
}
