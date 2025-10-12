namespace ICore.Siniestro.Comun.Helpers
{
    public static class MessageHelper
    {
        public static string ConstruirMensajeErrorValidacion(string propiedad, string contenido)
        {
            string texto = $@"Error para propiedad {propiedad}: {contenido}.";

            return texto;
        }

        public static string ConstruirMensajeErrorReglaNegocio(string propiedad, string contenido)
        {
            string texto = $@"Error para la regla de {propiedad}: {contenido}.";

            return texto;
        }

        public static string ConstruirMensajeErrorGenerico(string operacion, string motivo)
        {
            string texto = $@"Error en {operacion}: {motivo}.";

            return texto;
        }
    }
}
