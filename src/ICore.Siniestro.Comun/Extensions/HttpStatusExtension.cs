using System.Net;

namespace ICore.Siniestro.Comun.Extensions
{
    public static class HttpStatusExtension
    {
        public static bool IsSuccessStatusCode(this HttpStatusCode statusCode)
        {

            return ((int)statusCode >= 200) && ((int)statusCode <= 299);
        }

        public static bool IsNotFoundStatusCode(this HttpStatusCode statusCode)
        {

            return ((int)statusCode == 404);
        }
    }
}
