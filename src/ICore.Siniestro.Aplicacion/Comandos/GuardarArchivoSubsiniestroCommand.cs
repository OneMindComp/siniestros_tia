using ICore.Siniestro.Aplicacion.Contratos.Persistencia;
using ICore.Siniestro.Aplicacion.Dtos.Requests;
using ICore.Siniestro.Aplicacion.Dtos.Responses;
using ICore.Siniestro.Dominio.Entidades;
using MediatR;
using Microsoft.Extensions.Logging;

namespace ICore.Siniestro.Aplicacion.Comandos
{
    /// <summary>
    /// Guarda un archivo de subsiniestro en el core.
    /// </summary>
    public class GuardarArchivoSubsiniestroCommand : IRequest<GuardarArchivoSubsiniestroResponse>
    {
        /// <summary>
        /// Request con data requerida para guardar archivo de subsiniestro.
        /// </summary>
        public GuardarArchivoSubsiniestroRequest Request { get; set; } = default!;
    }

    /// <summary>
    /// Maneja la logica para guardar archivo de subsiniestro en el core.
    /// </summary>
    public class GuardarArchivoSubsiniestroCommandHandler : IRequestHandler<GuardarArchivoSubsiniestroCommand, GuardarArchivoSubsiniestroResponse>
    {
        private readonly ISiniestroContract _siniestroContract;
        private readonly IArchivoContract _archivoContract;
        private readonly ILogger<GuardarArchivoSubsiniestroCommandHandler> _logger;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="archivoContract"></param>
        /// <param name="siniestroContract"></param>
        /// <param name="logger"></param>
        public GuardarArchivoSubsiniestroCommandHandler(IArchivoContract archivoContract, ISiniestroContract siniestroContract,ILogger<GuardarArchivoSubsiniestroCommandHandler> logger)
        {
            _archivoContract = archivoContract;
            _siniestroContract = siniestroContract;
            _logger = logger;
        }

        /// <summary>
        /// Implementa la logica para guardar archivo de subsiniestro en el core.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="Sbins.Comunes.Excepciones.ApplicationException"></exception>
        public async Task<GuardarArchivoSubsiniestroResponse> Handle(GuardarArchivoSubsiniestroCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var numeroSubsiniestro = request.Request.NumeroSubsiniestro;
                _logger.LogInformation("Iniciando proceso de guardado de archivo de subsiniestro numero: {NumeroSubsiniestro}", numeroSubsiniestro);                
                bool contieneguion = numeroSubsiniestro.Contains("-");
                var numeroSiniestro = long.Parse(contieneguion ? numeroSubsiniestro.Split('-')[0] : numeroSubsiniestro);
                
                //Obtiene numero de caso
                var numeroCaso = contieneguion ? await _siniestroContract.ObtenerNumeroCaso( numeroSubsiniestro): await _siniestroContract.ObtenerNumeroCaso(numeroSiniestro);

                if (numeroCaso == null)
                {
                    throw new ArgumentException($"No se encuentra el caso asociado al subsiniestro numero: {numeroSubsiniestro}");
                }

                Archivo archivo = Archivo.Crear(numeroSiniestro, numeroCaso);
                archivo.EstablecerContenido(request.Request.Data);
                bool respuesta = await _archivoContract.GuardarArchivo(archivo);
                var guardaArchivoResponse = new GuardarArchivoSubsiniestroResponse();
                guardaArchivoResponse.NumeroSubsiniestro = request.Request.NumeroSubsiniestro;
                guardaArchivoResponse.IdCaso = numeroCaso.ToString()!;
                guardaArchivoResponse.ArchivoGuardado = respuesta;
                if (respuesta)
                {
                    _logger.LogInformation("Archivo de subsiniestro numero: {NumeroSubsiniestro} guardado correctamente.", request.Request.NumeroSubsiniestro);
                    guardaArchivoResponse.Mensaje = "Archivo de subsiniestro guardado correctamente.";
                }
                else
                {
                    _logger.LogError("Error al guardar el archivo de subsiniestro numero: {NumeroSubsiniestro}", request.Request.NumeroSubsiniestro);
                    guardaArchivoResponse.Mensaje = "Error, no se pudo guardar el archivo de subsiniestro.";
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
