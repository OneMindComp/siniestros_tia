using System.Text.Json;

namespace ICore.Siniestro.Comun.Extensions
{
    public static class JsonExtension
    {
        public static T ToObject<T>(this JsonElement element)
        {
            var json = element.GetRawText();
            return JsonSerializer.Deserialize<T>(json)!;
        }
        public static T ToObject<T>(this JsonDocument document)
        {
            var json = document.RootElement.GetRawText();
            return JsonSerializer.Deserialize<T>(json)!;
        }

        public static JsonDocument ToJsonDocument<T>(T entidad)
        {
            string json = JsonSerializer.Serialize(entidad);
            return JsonDocument.Parse(json);
        }
    }
}
