using MediatR;
using TN.CrudAdvanced.Domain.Entities;
using TN.CrudAdvanced.Domain.Interfaces.Repositories;
using TN.CrudAdvanced.Infrastructure.Queries;

namespace TN.CrudAdvanced.Infrastructure.Handlers
{
    public class GetAllPersonsQueryHandler : IRequestHandler<GetAllPersonsQuery, IEnumerable<Person>>
    {
        private readonly IPersonRepository _repository;

        public GetAllPersonsQueryHandler(IPersonRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Person>> Handle(GetAllPersonsQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetAllAsync();
        }
    }
}
