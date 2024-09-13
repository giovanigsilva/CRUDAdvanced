namespace TN.CrudAdvanced.Domain.Interfaces.Services
{
    public interface ICepService
    {
        Task<string> GetAddressByCepAsync(string cep);
    }
}

