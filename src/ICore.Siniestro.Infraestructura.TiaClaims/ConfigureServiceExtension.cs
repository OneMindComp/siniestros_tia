using ICore.Siniestro.Aplicacion.Contratos.Persistencia;
using ICore.Siniestro.Infraestructura.TiaClaims.Implemetacion;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sbins.Comunes.Excepciones;
using Sbins.Tia.Autenticacion.Cliente;
using System.Reflection;

namespace ICore.Siniestro.Infraestructura.TiaClaims
{
    public static class ConfigureServiceExtension
    {
        public static IServiceCollection AddTiaClaimsInfraestructura(this IServiceCollection services, IConfiguration configuration)
        {
            TiaServicesSettings tiaClaimServicesSettings = configuration.GetSection(nameof(TiaServicesSettings)).Get<TiaServicesSettings>()
                ?? throw new InfraestructureException("No se ha podido realizar AddImplementacionTiaClaims");

            services.AddScoped<ISiniestroContract, SiniestroImplementacion>();

            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            #region TokenAuth
            services.AddHttpClient().AddTiaAutheticationService(configuration);

            IServiceProvider serviceProvider = services.BuildServiceProvider();

            IAuthenticateClient authenticateClient = serviceProvider.GetRequiredService<IAuthenticateClient>();

            Token token = authenticateClient.GetToken().GetAwaiter().GetResult();

            services.AddHttpClient<ITiaClaims, TiaClaims>(cliente =>
            {

                cliente.BaseAddress = new Uri(tiaClaimServicesSettings.ClaimsBasePath);

                cliente.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token.AccessToken);

            });
            #endregion

            return services;
        }
    }
}
