using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TN.CrudAdvanced.Domain.Interfaces.Repositories;
using TN.CrudAdvanced.Infrastructure.Command;

namespace TN.CrudAdvanced.Infrastructure.Handlers
{
   public class DeletePersonCommandHandler : IRequestHandler<DeletePersonCommand, Unit>
{
    private readonly IPersonRepository _repository;

    public DeletePersonCommandHandler(IPersonRepository repository)
    {
        _repository = repository;
    }

    public async Task<Unit> Handle(DeletePersonCommand request, CancellationToken cancellationToken)
    {
        await _repository.DeleteAsync(request.Id);
        return Unit.Value; 
    }
}


}
