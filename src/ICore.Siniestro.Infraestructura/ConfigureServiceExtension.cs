using ICore.Siniestro.Infraestructura.Tia;
using ICore.Siniestro.Infraestructura.TiaCase;
using ICore.Siniestro.Infraestructura.TiaClaims;
using ICore.Siniestro.Infraestructura.TiaParty;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sbins.Tia.Autenticacion.Cliente;
using System.Reflection;

namespace ICore.Siniestro.Infraestructura
{
    public static class ConfigureServiceExtension
    {
        public static IServiceCollection AddInfraestructura(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.Configure<TiaServicesSettings>(options => configuration.GetSection(nameof(TiaServicesSettings)).Bind(options));
            services.AddHttpClient().AddTiaAutheticationService(configuration);

            services.AddTiaCommonInfraestructura(configuration);
            services.AddTiaCaseInfraestructura(configuration);
            services.AddTiaClaimsInfraestructura(configuration);

            services.AddTiaPartyInfraestructura(configuration);
            return services;
        }


    }
}
