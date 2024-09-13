using TN.CrudAdvanced.Domain.Entities;
using TN.CrudAdvanced.Domain.Interfaces.Repositories;

namespace TN.CrudAdvanced.Infrastructure.Repositories
{
    public class InMemoryProductRepository : IProductRepository
    {
        private readonly List<Product> _products = new List<Product>();

        private readonly List<Product> _transactionBuffer = new List<Product>();

        public Task<Product> GetByIdAsync(Guid id)
        {
            return Task.FromResult(_products.FirstOrDefault(p => p.Id == id));
        }

        public Task<IEnumerable<Product>> GetAllAsync()
        {
            return Task.FromResult((IEnumerable<Product>)_products);
        }

        public async Task AddAsync(Product product)
        {
            _transactionBuffer.Add(product);

            if (await SimulateSuccessAsync())
            {
                ApplyTransaction();
            }
            else
            {
                _transactionBuffer.Clear();
                throw new Exception("Falha ao adicionar o produto.");
            }
        }

        public async Task UpdateAsync(Product product)
        {
            var existingProduct = _products.FirstOrDefault(p => p.Id == product.Id);
            if (existingProduct != null)
            {
                _transactionBuffer.Add(product);

                if (await SimulateSuccessAsync())
                {
                    existingProduct.Name = product.Name;
                    existingProduct.Price = product.Price;
                }
                else
                {
                    _transactionBuffer.Clear();
                    throw new Exception("Falha ao atualizar o produto.");
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
                if (!_products.Contains(product))
                {
                    _products.Add(product);
                }
            }
            _transactionBuffer.Clear(); 
        }
    }
}
