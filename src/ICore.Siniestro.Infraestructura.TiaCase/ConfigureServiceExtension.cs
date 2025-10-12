using ICore.Siniestro.Aplicacion.Contratos.Persistencia;
using ICore.Siniestro.Infraestructura.TiaCase.Implementacion;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sbins.Comunes.Excepciones;
using Sbins.Tia.Autenticacion.Cliente;

namespace ICore.Siniestro.Infraestructura.TiaCase
{
    public static class ConfigureServiceExtension
    {
        public static IServiceCollection AddTiaCaseInfraestructura(this IServiceCollection services, IConfiguration configuration)
        {
            TiaServicesSettings tiaServicesSettings = configuration.GetSection(nameof(TiaServicesSettings)).Get<TiaServicesSettings>()
                ?? throw new InfraestructureException("No se ha podido realizar AddImplementacionTia");

            services.AddScoped<IArchivoContract, ArchivoImplementacion>();

            #region TokenAuth
            services.AddHttpClient().AddTiaAutheticationService(configuration);

            IServiceProvider serviceProvider = services.BuildServiceProvider();

            IAuthenticateClient authenticateClient = serviceProvider.GetRequiredService<IAuthenticateClient>();

            Token token = authenticateClient.GetToken().GetAwaiter().GetResult();

            services.AddHttpClient<ITiaCaseApi, TiaCaseApi>(cliente =>
            {

                cliente.BaseAddress = new Uri(tiaServicesSettings.CaseBasePath!);

                cliente.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token.AccessToken);

            });

            #endregion

            return services;
        }
    }
}
