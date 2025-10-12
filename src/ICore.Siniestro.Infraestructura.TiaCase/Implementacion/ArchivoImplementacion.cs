using ICore.Siniestro.Aplicacion.Contratos.Persistencia;
using ICore.Siniestro.Dominio.Entidades;
using Microsoft.Extensions.Logging;

namespace ICore.Siniestro.Infraestructura.TiaCase.Implementacion
{
    public class ArchivoImplementacion : IArchivoContract
    {
        private readonly ITiaCaseApi _tiaCaseApi;
        private readonly ILogger<ArchivoImplementacion> _logger;

        public ArchivoImplementacion(ILogger<ArchivoImplementacion> logger, ITiaCaseApi tiaCaseApi)
        {
            _logger = logger;
            _tiaCaseApi = tiaCaseApi;
        }

        public async Task<bool> GuardarArchivo(Archivo archivo)
        {
            bool guardado = false;
            try
            {
                //Buscar caso con numero de caso
                _logger.LogInformation("Obteniendo caso vinculado al siniestro de TIA.");

                var casos = await _tiaCaseApi.V1CaseItemsGetAsync(default, default, default, claimNo: archivo.NumeroCaso, default, default, default
                    , caseType: "CLDC", default, default, default, default, default, 1, 25, default);
                var caso = casos.Content.FirstOrDefault();
                _logger.LogInformation("Caso Id.{CasoId}", caso!.Id);

                //Subir archivo
                _logger.LogInformation("Guarda archivo en TIA.");
                using (Stream stream = new MemoryStream())
                {
                    await archivo.Data.CopyToAsync(stream);
                    stream.Seek(0, SeekOrigin.Begin);
                    FileParameter fileParameter = new FileParameter(stream, archivo.Data.FileName, archivo.Data.ContentType);
                    var resp = await _tiaCaseApi.V1AttachmentsFilesPostAsync(
                        id: caso.Id,
                        file: fileParameter
                    );
                    guardado = true;
                    _logger.LogInformation("Archivo Guardado {AttachmentId}.", resp.Content.AttachmentId);
                }


            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error en Guardar Archivo");
            }
            return guardado;
        }
    }
}
