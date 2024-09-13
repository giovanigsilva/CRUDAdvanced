using System.Net.Http;
using System.Threading.Tasks;
using TN.CrudAdvanced.Domain.Interfaces.Services;

namespace TN.CrudAdvanced.Infrastructure.Services
{
    public class CepService : ICepService
    {
        private readonly HttpClient _httpClient;

        public CepService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> GetAddressByCepAsync(string cep)
        {
            if (string.IsNullOrWhiteSpace(cep))
                throw new ArgumentException("CEP não pode ser vazio.", nameof(cep));

            cep = cep.Replace("-", "").Trim();

            var response = await _httpClient.GetAsync($"https://viacep.com.br/ws/{cep}/json/");

            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException("Erro ao consultar a API de CEP.");
            }

            return await response.Content.ReadAsStringAsync();
        }
    }
}
