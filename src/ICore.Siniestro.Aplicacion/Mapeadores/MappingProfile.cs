using System.Reflection;
using AutoMapper;

namespace ICore.Siniestro.Aplicacion.Mapeadores
{
    /// <summary>
    /// Configuracion de perfil para automaper..
    /// </summary>
    public class MappingProfile : Profile
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        public MappingProfile()
        {
            AplicarMappingDesdeEnsamblado(Assembly.GetExecutingAssembly());
        }

        private void AplicarMappingDesdeEnsamblado(Assembly assembly)
        {
            var tipoDesde = typeof(IMapFrom<>);
            var metodoMapping = nameof(IMapFrom<object>.Mapping);

            bool PoseeInterfaz(Type t) => t.IsGenericType && t.GetGenericTypeDefinition() == tipoDesde;

            var tipos = assembly.GetExportedTypes().Where(t => t.GetInterfaces().Any(PoseeInterfaz)).ToList();

            var tiposArgumento = new Type[] { typeof(Profile) };

            foreach (var tipo in tipos)
            {
                var instancia = Activator.CreateInstance(tipo);
                var infoMetodo = tipo.GetMethod(metodoMapping);

                if (infoMetodo != null)
                {
                    infoMetodo.Invoke(instancia, new object[] { this });
                }
                else
                {
                    var interfaces = tipo.GetInterfaces().Where(PoseeInterfaz).ToList();

                    if (interfaces.Count > 0)
                    {
                        foreach (var @interface in interfaces)
                        {
                            var infoMetodoInterface = @interface.GetMethod(metodoMapping, tiposArgumento);
                            infoMetodoInterface?.Invoke(instancia, new object[] { this });
                        }
                    }
                }
            }
        }
    }
}
