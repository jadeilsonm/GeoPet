using GeoPetAPI.Shared.Constants;
using GeoPetAPI.Shared.Contracts;

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

        public async Task<object> GetInfomatioByCep(string cep)
        {
            if (cep is null || cep.Replace(" ", "").Length != 8)
                return false;
            var response = await _client.GetAsync($"");
            if (!response.IsSuccessStatusCode)
                return false;
            var result = await response.Content.ReadFromJsonAsync<object>();
            return result!;
        }
    }
}
