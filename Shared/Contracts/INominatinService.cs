namespace GeoPetAPI.Shared.Contracts
{
    public interface INominatinService
    {
        Task<object> GetInfomatioByLatAndLon(string lat, string lon);
    }
}
