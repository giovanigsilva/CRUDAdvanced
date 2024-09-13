using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TN.CrudAdvanced.Domain.Entities;
using TN.CrudAdvanced.Domain.Interfaces.Repositories;
using TN.CrudAdvanced.Infrastructure.Command;

namespace TN.CrudAdvanced.Infrastructure.Handlers
{
    public class CreatePersonCommandHandler : IRequestHandler<CreatePersonCommand, Guid>
    {
        private readonly IPersonRepository _repository;

        public CreatePersonCommandHandler(IPersonRepository repository)
        {
            _repository = repository;
        }

        public async Task<Guid> Handle(CreatePersonCommand request, CancellationToken cancellationToken)
        {
            var product = new Person
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                Idade = request.Idade,
                CepCode = request.CepCode,
                Logradouro = request.Logradouro,
                Complemento = request.Complemento,
                Bairro = request.Bairro,
                Localidade = request.Localidade,
                Uf = request.Uf,
                Estado = request.Estado,
                Regiao = request.Regiao,
                Ibge = request.Ibge,
                Ddd = request.Ddd,
                Siafi = request.Siafi

            };

            await _repository.AddAsync(product);
            return product.Id;
        }
    }

}

