using Microsoft.AspNetCore.Mvc;
using TN.CrudAdvanced.Domain.Interfaces.Services;

namespace TN.CrudAdvanced.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CepController : ControllerBase
    {
        private readonly ICepService _cepService;

        public CepController(ICepService cepService)
        {
            _cepService = cepService;
        }

        [HttpGet("{cep}")]
        public async Task<IActionResult> GetAddressByCep(string cep)
        {
            try
            {
                var result = await _cepService.GetAddressByCepAsync(cep);
                return Ok(result);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (HttpRequestException)
            {
                return StatusCode(500, "Erro ao consultar a API de CEP.");
            }
        }
    }
}
