using System.Text.Json;
using System.Text.RegularExpressions;

namespace ICore.Siniestro.Comun.Helpers
{
    public static class StringHelper
    {
        public static bool EsFormatoFechaValido(string fecha)
        {

            return Regex.IsMatch(fecha, @"^\d{4}-\d{2}-\d{2}T\d{2}:\d{2}:\d{2}\.\d{3}Z$");
        }

        public static bool EsFormatoTelefonoValido(string telefono)
        {
            return Regex.IsMatch(telefono, @"^[+0-9]+$");
        }

        public static bool EsFormatoTelefonoChileValido(string telefono)
        {
            return Regex.IsMatch(telefono, @"^(\+?56)(9)\d{7,8}$");
        }

        public static bool EsFormatoEmailValido(string emailAddress)
        {
            var pattern = @"^[a-zA-Z0-9.!#$%&'*+-/=?^_`{|}~]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$";
            var regex = new Regex(pattern);

            return regex.IsMatch(emailAddress);
        }

        public static bool EsFormatoNumeroPolizaValido(string numeroPoliza)
        {

            return Regex.IsMatch(numeroPoliza, @"^\d{1,10}-\d{1,7}$");
        }

        public static string ModoOracion(string original)
        {
            string[] split = Regex.Split(original, @"(?<!^)(?=[A-Z])");
            var cleanedSplit = split.Select(s => s.Trim()).ToList();

            return string.Join(" ", cleanedSplit).ToLowerInvariant();
        }

        public static string CamelCaseSerialization(object input)
        {
            JsonSerializerOptions options = new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };

            return JsonSerializer.Serialize(input, options);
        }
    }
}
