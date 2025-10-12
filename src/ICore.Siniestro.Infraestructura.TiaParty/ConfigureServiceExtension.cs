using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sbins.Comunes.Excepciones;
using Sbins.Tia.Autenticacion.Cliente;

namespace ICore.Siniestro.Infraestructura.TiaParty
{
    public static class ConfigureServiceExtension
    {
        public static IServiceCollection AddTiaPartyInfraestructura(this IServiceCollection services, IConfiguration configuration)
        {
            TiaServicesSettings tiaPartyServicesSettings = configuration.GetSection(nameof(TiaServicesSettings)).Get<TiaServicesSettings>()
                ?? throw new InfraestructureException("No se ha podido realizar AddImplementacionTiaParty");

            #region TokenAuth
            services.AddHttpClient().AddTiaAutheticationService(configuration);

            IServiceProvider serviceProvider = services.BuildServiceProvider();

            IAuthenticateClient authenticateClient = serviceProvider.GetRequiredService<IAuthenticateClient>();

            Token token = authenticateClient.GetToken().GetAwaiter().GetResult();

            services.AddHttpClient<ITiaPartyClient, TiaPartyClient>(cliente =>
            {

                cliente.BaseAddress = new Uri(tiaPartyServicesSettings.PartyBasePath);

                cliente.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token.AccessToken);

            });
            #endregion

            return services;
        }
    }
}
