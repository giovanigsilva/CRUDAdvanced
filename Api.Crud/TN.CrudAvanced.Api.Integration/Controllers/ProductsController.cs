using FluentValidation;
using FluentValidation.Results;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TN.CrudAdvanced.Infrastructure.Command;
using TN.CrudAdvanced.Infrastructure.Queries;
using TN.CrudAvanced.Api.Integration.Validation;

namespace TN.CrudAvanced.Api.Integration.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await _mediator.Send(new GetAllProductsQuery());
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var product = await _mediator.Send(new GetProductByIdQuery { Id = id });
            if (product == null)
                return NotFound();

            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateProductCommand command)
        {
            var createValidator = new CreateProductCommandValidator();
            ValidationResult createResult = createValidator.Validate(command);

            if (!createResult.IsValid)
            {
                return BadRequest(createResult.Errors);
            }

            var productId = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id = productId }, null);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, UpdateProductCommand command)
        {
            command.Id = id;

            var updateValidator = new UpdateProductCommandValidator();
            ValidationResult updateResult = updateValidator.Validate(command);

            if (!updateResult.IsValid)
            {
                return BadRequest(updateResult.Errors);
            }

            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _mediator.Send(new DeleteProductCommand { Id = id });
            return NoContent();
        }
    }
}
