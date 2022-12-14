using GeoPetAPI.Shared.Constants;
using GeoPetAPI.Shared.Contracts;
using System.Reflection;

namespace GeoPetAPI.Services
{
    public class NominationService : INominatinService
    {
        private readonly HttpClient _client;
        public NominationService(HttpClient client)
        {
            _client = client;
            _client.BaseAddress = new Uri(Defaults.URL_BASE_NOMINATION);
        }

        public async Task<object> GetInfomatioByLatAndLon(string lat, string lon)
        {
            lat = lat.Trim();
            lon = lon.Trim();
            if (lat.Length == 0 || lon.Length == 0)
                throw new ArgumentNullException();
            AddUserAgent(_client);
            var response = await _client.GetAsync($"reverse?lat={lat}&lon={lon}&zoom=10&format=json");
            if (!response.IsSuccessStatusCode)
                throw new NullReferenceException();
            var result = await response.Content.ReadFromJsonAsync<object>();
            return result!;
        }

        private static void AddUserAgent(HttpClient httpClient)
        {
            httpClient.DefaultRequestHeaders.UserAgent.Clear();
            httpClient.DefaultRequestHeaders.UserAgent.Add(new System.Net.Http.Headers.ProductInfoHeaderValue("f1ana.Nominatim.API", 
                                                           Assembly.GetExecutingAssembly().GetName().Version.ToString()));
        }
    }
}
