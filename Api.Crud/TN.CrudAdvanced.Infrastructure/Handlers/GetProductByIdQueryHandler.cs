using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TN.CrudAdvanced.Domain.Entities;
using TN.CrudAdvanced.Domain.Interfaces.Repositories;
using TN.CrudAdvanced.Infrastructure.Queries;

namespace TN.CrudAdvanced.Infrastructure.Handlers
{
    public class GetPersonByIdQueryHandler : IRequestHandler<GetPersonByIdQuery, Person>
{
    private readonly IPersonRepository _repository;

    public GetPersonByIdQueryHandler(IPersonRepository repository)
    {
        _repository = repository;
    }

    public async Task<Person> Handle(GetPersonByIdQuery request, CancellationToken cancellationToken)
    {
        // Busca o produto pelo ID no repositório
        var product = await _repository.GetByIdAsync(request.Id);

        // Retorna o produto (ou null se não encontrado)
        return product;
    }
}

}
