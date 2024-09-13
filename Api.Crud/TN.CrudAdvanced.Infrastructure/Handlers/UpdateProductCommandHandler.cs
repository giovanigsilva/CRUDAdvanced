﻿using MediatR;
using TN.CrudAdvanced.Domain.Interfaces.Repositories;
using TN.CrudAdvanced.Infrastructure.Command;

namespace TN.CrudAdvanced.Infrastructure.Handlers
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, Unit>
{
    private readonly IProductRepository _repository;

    public UpdateProductCommandHandler(IProductRepository repository)
    {
        _repository = repository;
    }

    public async Task<Unit> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var product = await _repository.GetByIdAsync(request.Id);

        if (product == null)
        {
            throw new Exception("Product not found");
        }

        product.Name = request.Name;
        product.Price = request.Price;

        await _repository.UpdateAsync(product);

        return Unit.Value;
    }
}


}
