using GeoPetAPI.Shared.Constants;
using GeoPetAPI.Shared.Contracts;

namespace GeoPetAPI.Services
{
    public class ViaCepService : IViaCepService
    {
        private readonly HttpClient _client;

        public ViaCepService(HttpClient client)
        {
            _client = client;
            _client.BaseAddress = new Uri(Defaults.URL_BASE_VIA_CEP);
        }
        public async Task<object?> FindCep(string cep)
        {
            if (cep is null || cep.Replace(" ", "").Length != 8)
                return null;
            var response = await _client.GetAsync($"ws/{cep}/json/");
            if (!response.IsSuccessStatusCode)
                return null;
            var result = await response.Content.ReadFromJsonAsync<object>();
            return result;
        }
    }
}
