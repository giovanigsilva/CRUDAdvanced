using MediatR;
using System.Reflection.Emit;
using System.Xml.Linq;
using TN.CrudAdvanced.Domain.Interfaces.Repositories;
using TN.CrudAdvanced.Infrastructure.Command;
using static System.Net.Mime.MediaTypeNames;

namespace TN.CrudAdvanced.Infrastructure.Handlers
{
    public class UpdatePersonCommandHandler : IRequestHandler<UpdatePersonCommand, Unit>
    {
        private readonly IPersonRepository _repository;

        public UpdatePersonCommandHandler(IPersonRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(UpdatePersonCommand request, CancellationToken cancellationToken)
        {
            var product = await _repository.GetByIdAsync(request.Id);

            if (product == null)
            {
                throw new Exception("Person not found");
            }

            product.Name = request.Name;
            product.Idade = request.Idade;
            product.CepCode = request.CepCode;
            product.Logradouro = request.Logradouro;
            product.Complemento = request.Complemento;
            product.Bairro = request.Bairro;
            product.Localidade = request.Localidade;
            product.Uf = request.Uf;
            product.Estado = request.Estado;
            product.Regiao = request.Regiao;
            product.Ibge = request.Ibge;
            product.Ddd = request.Ddd;
            product.Siafi = request.Siafi;


            await _repository.UpdateAsync(product);

            return Unit.Value;
        }
    }


}
