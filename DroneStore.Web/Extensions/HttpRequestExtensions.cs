using Microsoft.AspNetCore.Http;

namespace DroneStore.Web.Extensions
{
    public static class HttpRequestExtensions
    {
        public static string GetPathAndQuery(this HttpRequest request) =>
            $"{request.Path}{request.QueryString}";
    }
}
