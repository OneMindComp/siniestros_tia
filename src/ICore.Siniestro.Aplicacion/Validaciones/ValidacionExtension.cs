using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;

namespace ICore.Siniestro.Aplicacion.Validaciones
{
    /// <summary>
    /// Clase de configuracion fluent validation.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public static class ValidacionExtension
    {
        /// <summary>
        /// Constructor declara los servicios de fluet validation.
        /// </summary>
        public static void AddValidationExtension(this IServiceCollection services)
        {
            services.AddFluentValidationAutoValidation();
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
