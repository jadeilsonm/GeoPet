namespace GeoPetAPI.Shared.Contracts
{
    public interface IViaCepService
    {
        Task<object> FindCep(string cep);
    }
}
