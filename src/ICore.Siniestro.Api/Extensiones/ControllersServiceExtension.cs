using Microsoft.AspNetCore.Mvc.ApplicationModels;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

namespace ICore.Siniestro.Api.Extensiones
{
    /// <summary>
    /// Configuracion para el uso de controladores.
    /// </summary>
    public static class ControllerServiceExtension
    {
        /// <summary>
        /// Inicializa en la coleccion de servicios los controladores.
        /// </summary>        
        /// <returns></returns>
        public static IServiceCollection ConfigureControllers(this IServiceCollection services)
        {
            ArgumentNullException.ThrowIfNull(services);

            services
                .AddControllers(options =>
                {
                    options.Conventions.Add(
                        new RouteTokenTransformerConvention(
                            new SlugifyParameterTransformer()
                        )
                    );
                })
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
                    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                });

            return services;
        }
    }

    /// <summary>
    /// Transformador de parametros a uso de minusculas y guion en rutas.
    /// </summary>
    internal class SlugifyParameterTransformer : IOutboundParameterTransformer
    {
        /// <summary>
        /// Transformacion de minusculas y guion.
        /// </summary>
        public string? TransformOutbound(object? value)
        {
            return value == null
                ? null
                : Regex.Replace(value.ToString()!, "([a-z])([A-Z])", "$1-$2", RegexOptions.None, TimeSpan.FromSeconds(1)).ToLowerInvariant();
        }
    }
}
