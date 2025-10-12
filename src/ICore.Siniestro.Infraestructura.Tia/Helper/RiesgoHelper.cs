using ICore.Siniestro.Dominio.Entidades.FraudKeeper;

namespace ICore.Siniestro.Infraestructura.Tia.Helper
{
    public class RiesgoHelper
    {
        public static Riesgo CrearRiesgo(
            int? numero,
            string? codigo,
            string? descripcion,
            List<string>? especificaciones
            )
        {
            return Riesgo.Crear(
                numero,
                codigo,
                descripcion,
                especificaciones
                );
        }
    }
}
