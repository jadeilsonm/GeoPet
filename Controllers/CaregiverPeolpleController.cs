using GeoPetAPI.Models;
using GeoPetAPI.Services;
using GeoPetAPI.Shared.Contracts;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace GeoPetAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CaregiverPeolpleController : ControllerBase
    {
        private readonly IViaCepService _clientCep;
        private readonly IGeoPetRepository _repository;
        private readonly JsonSerializerOptions _options = new()
        {
            ReferenceHandler = ReferenceHandler.IgnoreCycles,
            WriteIndented = true
        };

        public CaregiverPeolpleController(IGeoPetRepository repository, IViaCepService clientCep)
        {
            _repository = repository;
            _clientCep = clientCep;
        }

        [HttpPost("NewPeople")]
        public async Task<IActionResult> NewPeople(People people)
        {
            var resultcep = await _clientCep.FindCep(people.Cep);
            if (resultcep == null)
                return NotFound("CEP Invalido");
            _repository.AddPeople(people);
            var token = new TokenGenerator().Generate(people);
            return Ok(token);
        }

        [HttpGet("GetPeople")]
        public IActionResult getPeople()
        {

            var result = _repository.GetPeoples();

            return Ok(JsonSerializer.Serialize(result, _options));
        }
    }
}
