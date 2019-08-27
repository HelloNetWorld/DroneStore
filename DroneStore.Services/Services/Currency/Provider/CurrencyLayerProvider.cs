using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace DroneStore.Services.Currency.Provider
{
    public class ApiLayerCurrencyProvider : ICurrencyProvider
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ApiLayerCurrencyProvider(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public string Name { get => "CurrencyLayer.com"; }

        public Dictionary<string, double> GetQuotes()
        {
            const string url = "http://apilayer.net/api/live?access_key=88985a41267d6ca36569e935367da6ab";

            var response = DownloadAsString(url).Result;
            if (response != null)
            {
                return JsonConvert.DeserializeObject<CurrencyLayerObject>(response).Quotes;
            }

            return new Dictionary<string, double>();
        }

        public async Task<string> DownloadAsString(string url)
        {
            var client = _httpClientFactory.CreateClient();
            using (var result = await client.GetAsync(url))
            {  
                if (result.IsSuccessStatusCode)
                {
                    return await result.Content.ReadAsStringAsync();
                }
            }

            return null;
        }
    }

    public class CurrencyLayerObject
    {
        public bool Success { get; set; }
        public string Terms { get; set; }
        public string Privacy { get; set; }
        public int Timestamp { get; set; }
        public string Source { get; set; }
        public Dictionary<string, double> Quotes { get; set; }
    }
}
