namespace GeoPetAPI.Shared.Contracts
{
    public interface INominatinService
    {
        Task<object> GetInfomatioByCep(string cep);
    }
}
