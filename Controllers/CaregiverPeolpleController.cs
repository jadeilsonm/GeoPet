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
        private readonly IGeoPetRepository _repository;
        private JsonSerializerOptions _options = new()
        {
            ReferenceHandler = ReferenceHandler.IgnoreCycles,
            WriteIndented = true
        };

        public CaregiverPeolpleController(IGeoPetRepository repository)
        {
            _repository = repository;
        }

        [HttpPost("NewPeople")]
        public IActionResult NewPeople(People people)
        {
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
