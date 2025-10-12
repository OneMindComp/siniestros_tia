using System.Reflection;
using ICore.Siniestro.Aplicacion.Contratos.Core;
using ICore.Siniestro.Infraestructura.Tia.Implementacion;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sbins.Comunes.Excepciones;
using Sbins.Tia.Autenticacion.Cliente;

namespace ICore.Siniestro.Infraestructura.Tia
{
    public static class ConfigureServiceExtension
    {
        public static IServiceCollection AddTiaCommonInfraestructura(this IServiceCollection services, IConfiguration configuration)
        {
            TiaServicesSettings tiaServicesSettings = configuration.GetSection(nameof(TiaServicesSettings)).Get<TiaServicesSettings>()
                ?? throw new InfraestructureException("No se ha podido realizar AddImplementacionTia");

            services.AddScoped<ISiniestroContract, SiniestroImplementacion>();

            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            #region TokenAuth
            services.AddHttpClient().AddTiaAutheticationService(configuration);

            IServiceProvider serviceProvider = services.BuildServiceProvider();

            IAuthenticateClient authenticateClient = serviceProvider.GetRequiredService<IAuthenticateClient>();

            Token token = authenticateClient.GetToken().GetAwaiter().GetResult();

            services.AddHttpClient<ITiaApi, TiaApi>(cliente =>
            {

                cliente.BaseAddress = new Uri(tiaServicesSettings.CommonBasePath);

                cliente.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token.AccessToken);

            });
            #endregion

            return services;
        }
    }
}
