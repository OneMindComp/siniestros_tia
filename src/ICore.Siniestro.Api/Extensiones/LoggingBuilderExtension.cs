using NLog;
using NLog.Web;

namespace ICore.Siniestro.Api.Extensiones
{
    /// <summary>
    /// Configuracion de componentes de logging.
    /// </summary>        
    /// <returns></returns>
    public static class LoggingBuilderExtension
    {
        /// <summary>
        /// Configura el componente de logging en el programa.
        /// </summary>        
        /// <returns></returns>
        public static WebApplicationBuilder ConfigureLogging(this WebApplicationBuilder builder)
        {
            ArgumentNullException.ThrowIfNull(builder);

            builder.Logging.ClearProviders();
            builder.Host.UseNLog();
            builder.WebHost.UseSentry();

            return builder;
        }
    }

    /// <summary>
    /// Inicializacion de logger standalone para arranque del programa.
    /// </summary> 
    public static class Logging
    {
        /// <summary>
        /// Obtiene logger standalone para arranque del programa.
        /// </summary> 
        public static Logger GetCurrentLogger()
        {
            var logger = LogManager.Setup()
                .LoadConfigurationFromAppSettings()
                .GetCurrentClassLogger();

            return logger;
        }
    }
}
