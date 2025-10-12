using Microsoft.OpenApi.Models;

namespace ICore.Siniestro.Api.Extensiones
{
    /// <summary>
    /// Configuracion de Swagger.
    /// </summary>
    public static class SwaggerServiceExtension
    {
        private const string RUTA_APIDOC = "api-doc";

        /// <summary>
        /// Genera interfaz Swagger.
        /// </summary>
        /// <param name="services"></param>
        /// <param name="name"></param>
        /// <param name="info"></param>
        /// <returns></returns>
        public static IServiceCollection AddSbinsSwaggerGen(this IServiceCollection services, string name, OpenApiInfo info)
        {
            services.AddSwaggerGen(options =>
            {
                options.UseInlineDefinitionsForEnums();
                options.UseAllOfToExtendReferenceSchemas();
                options.SupportNonNullableReferenceTypes();

                string[] xmlFiles = Directory.GetFiles(AppContext.BaseDirectory, "*.xml", SearchOption.TopDirectoryOnly);
                xmlFiles.AsParallel().ForAll(m => options.IncludeXmlComments(m));

                options.SwaggerDoc(name, info);
            });

            return services;
        }

        /// <summary>
        /// Agrega Swagger UI para acceder a API.
        /// </summary>
        /// <param name="app"></param>
        /// <returns></returns>
        public static IApplicationBuilder UseSbinsSwagger(this IApplicationBuilder app)
        {
            var version = typeof(SwaggerServiceExtension).Assembly.GetName().Version!.ToString()[..5];

            app.UseSwagger(c =>
            {
                c.RouteTemplate = RUTA_APIDOC + "/{documentname}/swagger.json";
            });
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint($"v{version}/swagger.json", "Siniestro API SBINS");
                c.RoutePrefix = RUTA_APIDOC;
            });

            return app;
        }
    }
}
