using FluentValidation;
using FluentValidation.Results;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.ApplicationInsights;
using TN.CrudAdvanced.Infrastructure.Command;
using TN.CrudAdvanced.Infrastructure.Queries;
using TN.CrudAvanced.Api.Integration.Validation;
using System;

namespace TN.CrudAvanced.Api.Integration.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly TelemetryClient _telemetryClient;

        public ProductsController(IMediator mediator, TelemetryClient telemetryClient)
        {
            _mediator = mediator;
            _telemetryClient = telemetryClient;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var products = await _mediator.Send(new GetAllProductsQuery());
                return Ok(products);
            }
            catch (Exception ex)
            {
                Guid guid = Guid.NewGuid();
                _telemetryClient.TrackException(ex, new Dictionary<string, string> { { "Guid", guid.ToString() } });
                return StatusCode(500, new { Message = "An unexpected error occurred.", Protocol = guid });
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            try
            {
                var product = await _mediator.Send(new GetProductByIdQuery { Id = id });
                if (product == null)
                    return NotFound();

                return Ok(product);
            }
            catch (Exception ex)
            {
                Guid guid = Guid.NewGuid();
                _telemetryClient.TrackException(ex, new Dictionary<string, string> { { "Guid", guid.ToString() } });
                return StatusCode(500, new { Message = "An unexpected error occurred.", Protocol = guid });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateProductCommand command)
        {
            try
            {
                var createValidator = new CreateProductCommandValidator();
                ValidationResult createResult = createValidator.Validate(command);

                if (!createResult.IsValid)
                {
                    return BadRequest(createResult.Errors);
                }

                var productId = await _mediator.Send(command);

                return CreatedAtAction(nameof(GetById), new { id = productId }, new { Message = "Product successfully created.", ProductId = productId });
            }
            catch (Exception ex)
            {
                Guid guid = Guid.NewGuid();
                _telemetryClient.TrackException(ex, new Dictionary<string, string> { { "Guid", guid.ToString() } });
                return StatusCode(500, new { Message = "An unexpected error occurred.", Protocol = guid });
            }
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, UpdateProductCommand command)
        {
            try
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
            catch (Exception ex)
            {
                Guid guid = Guid.NewGuid();
                _telemetryClient.TrackException(ex, new Dictionary<string, string> { { "Guid", guid.ToString() } });
                return StatusCode(500, new { Message = "An unexpected error occurred.", Protocol = guid });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                await _mediator.Send(new DeleteProductCommand { Id = id });
                return NoContent();
            }
            catch (Exception ex)
            {
                Guid guid = Guid.NewGuid();
                _telemetryClient.TrackException(ex, new Dictionary<string, string> { { "Guid", guid.ToString() } });
                return StatusCode(500, new { Message = "An unexpected error occurred.", Protocol = guid });
            }
        }
    }
}
