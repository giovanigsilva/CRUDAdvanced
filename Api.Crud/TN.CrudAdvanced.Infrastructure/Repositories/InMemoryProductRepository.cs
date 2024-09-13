using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TN.CrudAdvanced.Domain.Entities;
using TN.CrudAdvanced.Domain.Interfaces.Repositories;

namespace TN.CrudAdvanced.Infrastructure.Repositories
{
    public class InMemoryProductRepository : IProductRepository
{
    private readonly List<Product> _products = new List<Product>();

    public Task<Product> GetByIdAsync(Guid id)
    {
        return Task.FromResult(_products.FirstOrDefault(p => p.Id == id));
    }

    public Task<IEnumerable<Product>> GetAllAsync()
    {
        return Task.FromResult((IEnumerable<Product>)_products);
    }

    public Task AddAsync(Product product)
    {
        _products.Add(product);
        return Task.CompletedTask;
    }

    public Task UpdateAsync(Product product)
    {
        var existingProduct = _products.FirstOrDefault(p => p.Id == product.Id);
        if (existingProduct != null)
        {
            existingProduct.Name = product.Name;
            existingProduct.Price = product.Price;
        }
        return Task.CompletedTask;
    }

    public Task DeleteAsync(Guid id)
    {
        var product = _products.FirstOrDefault(p => p.Id == id);
        if (product != null)
        {
            _products.Remove(product);
        }
        return Task.CompletedTask;
    }
}

}
