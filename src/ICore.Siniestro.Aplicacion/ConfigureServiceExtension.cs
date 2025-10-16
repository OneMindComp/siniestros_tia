using ICore.Siniestro.Aplicacion.Validaciones;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace ICore.Siniestro.Aplicacion
{
    /// <summary>
    /// Configura servicios de la capa aplicacion.
    /// </summary>
    public static class ConfigureServiceExtension
    {
        /// <summary>
        /// Agrega servicios de aplicacion al contenedor de servicios.
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddAplicacion(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddMediatR(configuration =>
                configuration.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly())
            );
            //services.AddScoped<IValidacionDenuncios, ValidacionDenuncios>();
            //services.AddScoped<IDenuncioSiniestro, DenuncioSiniestro>();
            //services.AddScoped<Interfaces.IDenuncioSiniestro, DenuncioSiniestroRequest>();
            services.AddValidationExtension();

            return services;
        }
    }
}
