using TN.CrudAdvanced.Domain.Entities;

namespace TN.CrudAdvanced.Domain.Interfaces.Repositories
{
    public interface IPersonRepository
    {
        Task<Person> GetByIdAsync(Guid id);
        Task<IEnumerable<Person>> GetAllAsync();
        Task AddAsync(Person person);
        Task UpdateAsync(Person person);
        Task DeleteAsync(Guid id);
    }
}
