using TN.CrudAdvanced.Domain.Entities;
using TN.CrudAdvanced.Domain.Interfaces.Repositories;

namespace TN.CrudAdvanced.Infrastructure.Repositories
{
    public class InMemoryPersonRepository : IPersonRepository
    {
        private readonly List<Person> _products = new List<Person>();

        private readonly List<Person> _transactionBuffer = new List<Person>();

        public Task<Person> GetByIdAsync(Guid id)
        {
            return Task.FromResult(_products.FirstOrDefault(p => p.Id == id));
        }

        public Task<IEnumerable<Person>> GetAllAsync()
        {
            return Task.FromResult(_products.Where(p => !p.IsDeleted));
        }


        public async Task AddAsync(Person person)
        {
            _transactionBuffer.Add(person);

            if (await SimulateSuccessAsync())
            {
                ApplyTransaction();
            }
            else
            {
                _transactionBuffer.Clear();
                throw new Exception("Falha ao adicionar a pessoa.");
            }
        }


        public async Task UpdateAsync(Person person)
        {
            var existingPerson = _products.FirstOrDefault(p => p.Id == person.Id);
            if (existingPerson != null)
            {
                _transactionBuffer.Add(person);

                if (await SimulateSuccessAsync())
                {
                    existingPerson.Name = person.Name;
                    existingPerson.Idade = person.Idade;
                    existingPerson.CepCode = person.CepCode;
                    existingPerson.Logradouro = person.Logradouro;
                    existingPerson.Complemento = person.Complemento;
                    existingPerson.Unidade = person.Unidade;
                    existingPerson.Bairro = person.Bairro;
                    existingPerson.Localidade = person.Localidade;
                    existingPerson.Uf = person.Uf;
                    existingPerson.Estado = person.Estado;
                    existingPerson.Regiao = person.Regiao;
                    existingPerson.Ibge = person.Ibge;
                    existingPerson.Gia = person.Gia;
                    existingPerson.Ddd = person.Ddd;
                    existingPerson.Siafi = person.Siafi;
                }
                else
                {
                    _transactionBuffer.Clear();
                    throw new Exception("Falha ao atualizar a pessoa.");
                }
            }
        }


        public async Task DeleteAsync(Guid id)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);
            if (product != null)
            {
                
                _transactionBuffer.Add(product);

                if (await SimulateSuccessAsync())
                {
                    
                    _products.Remove(product);
                    _transactionBuffer.Remove(product);  
                }
                else
                {
                    _transactionBuffer.Clear();
                    throw new Exception("Falha ao excluir o produto.");
                }
            }
        }


        private Task<bool> SimulateSuccessAsync()
        {
            return Task.FromResult(true);
        }

        private void ApplyTransaction()
        {
            foreach (var product in _transactionBuffer)
            {
                if (!_products.Any(p => p.Id == product.Id) && !product.IsDeleted)
                {
                    _products.Add(product);
                }
            }
            _transactionBuffer.Clear(); 
        }

    }
}
