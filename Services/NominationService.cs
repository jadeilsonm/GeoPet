﻿using GeoPetAPI.Shared.Constants;
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

        public async Task<object> GetInfomatioByLatAndLon(string lat, string lon)
        {
            if (lat is null || lon is null)
                return false;
            var response = await _client.GetAsync($"reverse?format=jsonv2&lat={lat}&lon={lon}");
            if (!response.IsSuccessStatusCode)
                return false;
            var result = await response.Content.ReadFromJsonAsync<object>();
            Console.WriteLine(result!.GetHashCode());
            return result!.GetHashCode();
        }
    }
}
